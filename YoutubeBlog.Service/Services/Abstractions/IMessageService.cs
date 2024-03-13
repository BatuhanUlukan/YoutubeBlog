
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.Entities;


namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessagesAsync(string category, string? searchTerm);
        Task CreateMessageAsync(MessageAddDto messageAddDto);
        Task<Message> GetMessageByGuid(string secName);
        Task<List<MessageDto>> GetLast4MessagesAsync();
        Task<int> GetTotalMessagesInLast12HoursAsync();
        Task<string> HardDeleteMessageAsync(string secName);
        Task<string> SafeDeleteMessageAsync(string secName);
        Task SendEmailAsync(string toEmail, string toCC, string subject, string body, List<AttachmentInfo> attachments = null);

        //Task<List<MessageDto>> ReceiveEmail();

    }

}
