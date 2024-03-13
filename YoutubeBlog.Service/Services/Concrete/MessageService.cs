using AutoMapper;
using MailKit.Net.Pop3;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using MimeKit;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Slug;
using YoutubeBlog.Service.Services.Abstractions;





namespace YoutubeBlog.Service.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISmtpService smtpService;
        private readonly IMapper mapper;
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly SmtpClient smtpClient;
        private readonly IWebHostEnvironment _hostingEnvironment;



        public MessageService(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment, SmtpClient smtpClient, ISmtpService smtpService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.smtpService = smtpService;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _hostingEnvironment = hostingEnvironment;
            this.smtpClient = smtpClient;
        }

        public async Task<string> HardDeleteMessageAsync(string secName)
        {
            var message = await unitOfWork.GetRepository<Message>().GetAsync(x => x.SecName == secName, y => y.AttachmentRecords);

            if (message != null)
            {
                // Remove the entity from the repository
                await unitOfWork.GetRepository<Message>().DeleteAsync(message);

                await unitOfWork.SaveAsync();

                return message.Name;
            }

            // If the headquarter with the specified ID doesn't exist, you can handle the error or return an appropriate value.
            return null; // Or throw an exception, depending on your error handling strategy.
        }
        public async Task CreateMessageAsync(MessageAddDto messageAddDto)
        {


            Message message = mapper.Map<Message>(messageAddDto);
            message.CreatedBy = messageAddDto.Name;
            message.IsInbox = true;

            await unitOfWork.GetRepository<Message>().AddAsync(message);
            await unitOfWork.SaveAsync();
        }
        public async Task<Message> GetMessageByGuid(string secName)
        {
            var message = await unitOfWork.GetRepository<Message>().GetAsync(x => x.SecName == secName, y => y.AttachmentRecords);
            return message;
        }

        public async Task<List<MessageDto>> GetLast4MessagesAsync()
        {
            // Fetch the latest 4 messages from the database, ordered by creation date in descending order
            var messages = await unitOfWork.GetRepository<Message>()
                .GetAllAsync(x => x.IsInbox);

            var orderedMessages = messages
                .OrderByDescending(m => m.CreatedDate)
                .Take(4);

            // Materialize the query by calling ToList to execute the LINQ query
            var orderedMessagesList = orderedMessages.ToList();

            // Map the entity messages to the MessageDto using AutoMapper
            var messageDtos = mapper.Map<List<MessageDto>>(orderedMessagesList);

            return messageDtos;
        }
        public async Task<int> GetTotalMessagesInLast12HoursAsync()
        {
            // Son 12 saat içinde oluşturulmuş mesajların sayısını almak için bir zaman aralığı belirleyin
            var twelveHoursAgo = DateTime.Now - TimeSpan.FromHours(12);

            // Veritabanından 12 saat içinde oluşturulmuş mesajları alın
            var messages = await unitOfWork.GetRepository<Message>()
                .GetAllAsync();

            var messageCount = messages
                .Where(m => m.CreatedDate >= twelveHoursAgo)
                .Count();

            return messageCount;
        }



        public async Task SendEmailAsync(string toEmail, string toCC, string subject, string body, List<AttachmentInfo> attachments = null)
        {
            try
            {
                var smtpSettings = await smtpService.GetSmtpSetting("SMTP");

                string fromAddress = smtpSettings.Username;
                string fromPassword = smtpSettings.Password;
                string smtpServer = smtpSettings.OutgoingServer;
                int smtpPort = smtpSettings.SMTPPort;

                using (MailMessage mail = new MailMessage())
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    mail.From = new MailAddress(fromAddress);
                    mail.To.Add(toEmail);

                    if (!string.IsNullOrEmpty(toCC))
                    {
                        foreach (var ccAddress in toCC.Split(',').Select(cc => cc.Trim()))
                        {
                            mail.CC.Add(ccAddress);
                        }
                    }

                    mail.Subject = subject;
                    mail.Body = body;

                    if (attachments != null && attachments.Any())
                    {
                        foreach (var attachmentInfo in attachments)
                        {
                            if (attachmentInfo.Stream != null)
                            {
                                var attachment = new Attachment(attachmentInfo.Stream, attachmentInfo.FileName);
                                mail.Attachments.Add(attachment);
                            }
                        }
                    }

                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                    smtp.EnableSsl = true;


                    await smtp.SendMailAsync(mail);

                    await SaveSendedEmailAsync(toEmail, subject, body, attachments);
                }
            }
            catch (Exception ex)
            {
                // Log the exception using a logging library or save it to a database
                Console.WriteLine("Error sending email: " + ex.Message);
                throw; // Re-throw the exception to propagate it
            }
        }


        public async Task<List<MessageDto>> ReceiveEmail()
        {
            var emails = new List<MessageDto>();
            try
            {
                var _smtpSettings = await smtpService.GetSmtpSetting("SMTP");

                using var emailClient = new Pop3Client();

                emailClient.Connect(_smtpSettings.IncomingServer, _smtpSettings.IMAPPort,true);

                emailClient.Authenticate(_smtpSettings.Username, _smtpSettings.Password);

                for (int i = 0; i < emailClient.Count; i++)
                {
                    try
                    {
                        var message = await emailClient.GetMessageAsync(i);

                        var emailViewModel = new MessageDto
                        {
                            Subject = message.Subject,
                            Name = message.Sender?.Name ?? message.Sender?.Address ?? "Unknown", // Use the Name or Address property of MailboxAddress
                            Email = message.From.ToString(),
                            Content = message.TextBody,
                            CreatedDate = message.Date
                        };


                        foreach (var attachment in message.Attachments)
                        {
                            if (attachment is MimePart mimePart)
                            {
                                using (var memoryStream = new MemoryStream())
                                {
                                    await mimePart.Content.DecodeToAsync(memoryStream);
                                    var attachmentContent = memoryStream.ToArray();

                                    var contentDisposition = mimePart.ContentDisposition;

                                    emailViewModel.Attachments.Add(new EmailAttachmentViewModel
                                    {
                                        FileName = contentDisposition?.FileName ?? "UnknownFileName",
                                        ContentType = attachment.ContentType.MediaType,
                                        Content = attachmentContent
                                    });
                                }
                            }
                        }

                        emails.Add(emailViewModel);
                    }
                    catch (Exception ex)
                    {
                        // Log the exception for each email, and continue with the next one
                        Console.WriteLine($"Error processing email {i + 1}: {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the overall exception
                Console.WriteLine($"Error: {ex.Message}");
            }

            return emails;
        }



        public async Task<List<MessageDto>> GetMessagesAsync(string category, string? searchTerm)
        {
            var messageDtos = new List<MessageDto>();

            if (category == "ınbox")
            {
                // Retrieve emails using ReceiveEmail
                var emails = await ReceiveEmail();

                // Convert emails to MessageDto and add to the result
                foreach (var email in emails)
                {
                    var messageDto = new MessageDto
                    {
                        Name = email.Name,
                        Subject = email.Subject,
                        Email = email.Email,
                        Content = email.Content,
                        CreatedDate = email.CreatedDate
                    };

                    // Retrieve attachments for the email and map to EmailAttachmentViewModel
                    foreach (var attachment in email.Attachments)
                    {
                        var attachmentViewModel = new EmailAttachmentViewModel
                        {
                            FileName = attachment.FileName,
                            ContentType = attachment.ContentType,
                            Content = attachment.Content
                        };

                        messageDto.Attachments.Add(attachmentViewModel);
                    }

                    messageDtos.Add(messageDto);
                }
            }

            else
            {
                // Retrieve messages from the repository based on category and searchTerm
                var messages = await unitOfWork.GetRepository<Message>().GetAllAsync(x =>
                    ((category == "sent" && x.IsSended && !x.IsDeleted) || (category == "form" && x.IsInbox && !x.IsDeleted) || (category == "deleted" && x.IsDeleted)) &&
                    (string.IsNullOrEmpty(searchTerm) || x.Subject.Contains(searchTerm) || x.Content.Contains(searchTerm) || x.Email.Contains(searchTerm) || x.Name.Contains(searchTerm)),
                     x => x.AttachmentRecords);

                // Convert messages to MessageDto and add to the result
                messageDtos.AddRange(mapper.Map<List<MessageDto>>(messages));
            }

            return messageDtos;
        }


        private async Task SaveSendedEmailAsync(string toEmail, string subject, string body, List<AttachmentInfo> attachments = null)
        {
            var secName = UniqStr.GuidToRandomName(Guid.NewGuid().ToString(), 6, 8);

            // Save email details to the database
            Message message = new Message
            {
                SecName = secName,
                Subject = subject,
                Content = body,
                Name = toEmail,
                Email = toEmail,
                IsSended = true,
                CreatedDate = DateTime.Now,
            };

            await unitOfWork.GetRepository<Message>().AddAsync(message);
            await unitOfWork.SaveAsync();

            // Save attachments to wwwroot directory
            if (attachments != null && attachments.Count > 0)
            {
                var attachmentsPath = Path.Combine(_hostingEnvironment.WebRootPath, "attachments");

                // Create the attachments directory if it doesn't exist
                if (!Directory.Exists(attachmentsPath))
                {
                    Directory.CreateDirectory(attachmentsPath);
                }

                foreach (var attachmentInfo in attachments)
                {
                    // Use the original filename without appending the current date and time
                    var fileName = attachmentInfo.FileName.Replace(" ", "_");
                    var filePath = Path.Combine(attachmentsPath, fileName);

                    // Save the attachment to the wwwroot/attachments directory
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await attachmentInfo.Stream.CopyToAsync(fileStream);
                    }

                    // Save information about the attachment to the database
                    var attachmentRecord = new AttachmentRecord
                    {
                        MessageId = message.Id, // Assuming you have an Id property in your Message model
                        FileName = fileName,
                        FilePath = filePath,
                    };

                    await unitOfWork.GetRepository<AttachmentRecord>().AddAsync(attachmentRecord);
                    await unitOfWork.SaveAsync();
                }
            }
        }
        public async Task<string> SafeDeleteMessageAsync(string secName)
        {
            var userEmail = _user.GetLoggedInEmail();
            var emails = await unitOfWork.GetRepository<Message>().GetAsync(x => x.SecName == secName);

            emails.IsDeleted = true;
            emails.DeletedDate = DateTime.Now;
            emails.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Message>().UpdateAsync(emails);
            await unitOfWork.SaveAsync();

            return emails.Name;
        }






    }


}















