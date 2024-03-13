using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Net.Mail;
using System.Xml.Linq;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.DTOs.Logos;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Pages;
using YoutubeBlog.Entity.DTOs.Sliders;
using YoutubeBlog.Entity.DTOs.SmtpSettings;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;


namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IPageSeoService pageSeoService;
        private readonly IDashbordService dashbordService;
        private readonly IMessageService messageService;
        private readonly ISmtpService smtpService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<PageSeo> validator;
        private readonly IValidator<Logo> logovalidator;
        private readonly IValidator<Slider> slidervalidator;
        private readonly IValidator<Fact> factvalidator;
        private readonly IValidator<About> aboutvalidator;
        private readonly IValidator<SmtpSetting> smtpvalidator;


        public HomeController(IUnitOfWork unitOfWork, IValidator<About> aboutvalidator, IValidator<Fact> factvalidator, IValidator<SmtpSetting> smtpvalidator, IValidator<Slider> slidervalidator, IMessageService messageService, ISmtpService smtpService, IArticleService articleService, IDashbordService dashbordService, IPageSeoService pageSeoService, IMapper mapper, IToastNotification toast, IValidator<PageSeo> validator, IValidator<Logo> logovalidator)
        {
            this.articleService = articleService;
            this.unitOfWork = unitOfWork;
            this.dashbordService = dashbordService;
            this.pageSeoService = pageSeoService;
            this.smtpService = smtpService;
            this.messageService = messageService;
            this.mapper = mapper;
            this.toast = toast;
            this.validator = validator;
            this.logovalidator = logovalidator;
            this.slidervalidator = slidervalidator;
            this.aboutvalidator = aboutvalidator;
            this.factvalidator = factvalidator;
            this.smtpvalidator = smtpvalidator;

        }

        [HttpGet]
        public async Task<IActionResult> YearlyArticleCounts()
        {
            var count = await dashbordService.GetYearlyArticleCounts();
            return Json(JsonConvert.SerializeObject(count));
        }
        [HttpGet]
        public async Task<IActionResult> TotalArticleCount()
        {
            var count = await dashbordService.GetTotalArticleCount();
            return Json(count);
        }
        [HttpGet]
        public async Task<IActionResult> TotalSliderCount()
        {
            var count = await dashbordService.GetTotalCategoryCount();
            return Json(count);
        }
        [Route("update-pageseo/{pageName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSeo(string pageName)
        {
            var pageSeo = await pageSeoService.GetSeoPage(pageName);
            var map = mapper.Map<PageSeo, PageSeoUpdateDto>(pageSeo);

            return View(map);
        }
        [Route("update-pageseo/{pageName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSeo(PageSeoUpdateDto pageSeoUpdateDto)
        {
            var map = mapper.Map<PageSeo>(pageSeoUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await pageSeoService.UpdatePageSeoAsync(pageSeoUpdateDto);
                toast.AddSuccessToastMessage(Messages.PageSeo.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageSeos", "Home", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("pageseos")]
        [HttpGet]
        public async Task<IActionResult> PageSeos()
        {
            var pageSeos = await pageSeoService.GetAllSeoPage();
            return View(pageSeos);
        }



        [Route("update-logos/{logoName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateLogo(string logoName)
        {
            var logos = await dashbordService.GetLogo(logoName);
            var map = mapper.Map<Logo, LogoUpdateDto>(logos);

            return View(map);
        }

        [Route("update-logos/{logoName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateLogo(LogoUpdateDto logoUpdate)
        {
            var map = mapper.Map<Logo>(logoUpdate);
            var result = await logovalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await dashbordService.UpdateLogoImages(logoUpdate);
                toast.AddSuccessToastMessage(Messages.Logos.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageLogos", "Home", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("logos")]
        [HttpGet]
        public async Task<IActionResult> PageLogos()
        {
            var logos = await dashbordService.GetAllLogos();
            return View(logos);
        }

        [Route("sliders")]
        [HttpGet]
        public async Task<IActionResult> PageSliders()
        {
            var sliders = await dashbordService.GetSliders();
            return View(sliders);
        }



        //SLİDERS

        [Route("add-slider")]
        [HttpGet]
        public IActionResult AddSlider()
        {
            return View();
        }

        [Route("add-slider")]
        [HttpPost]
        public async Task<IActionResult> AddSlider(SliderAddDto sliderAddDto)
        {
            var map = mapper.Map<Slider>(sliderAddDto);
            var result = await slidervalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                await dashbordService.CreateSliderAsync(sliderAddDto);
                toast.AddSuccessToastMessage(Messages.Slider.Add(sliderAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageSliders", "Home");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }
        [Route("update-slider/{sliderName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSlider(string sliderName)
        {
            var slider = await dashbordService.GetSlider(sliderName);
            var map = mapper.Map<Slider, SliderUpdateDto>(slider);

            return View(map);
        }

        [Route("update-slider/{sliderName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSlider(SliderUpdateDto sliderUpdateDto)
        {
            var map = mapper.Map<Slider>(sliderUpdateDto);
            var result = await slidervalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await dashbordService.UpdateSliderAsync(sliderUpdateDto);
                toast.AddSuccessToastMessage(Messages.Slider.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageSliders", "Home");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("slider-delete/{sliderName}")]
        [HttpGet]
        public async Task<IActionResult> DeleteSlider(string sliderName)
        {
            var name = await dashbordService.HardDeleteSliderAsync(sliderName);
            toast.AddSuccessToastMessage(Messages.Slider.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("PageSliders", "Home");
        }


        //ABOUTS

        [Route("admin/base")]
        [HttpGet]
        public async Task<IActionResult> ABase()
        {
            var abouts = await dashbordService.GetAbout();
            return View(abouts);
        }


        [Route("update-about/{aboutName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string aboutName)
        {
            var about = await dashbordService.GetAbout(aboutName);
            var map = mapper.Map<About, AboutUpdateDto>(about);

            return View(map);
        }

        [Route("update-about/{aboutName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(AboutUpdateDto aboutUpdateDto)
        {
            var map = mapper.Map<About>(aboutUpdateDto);
            var result = await aboutvalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await dashbordService.UpdateAboutAsync(aboutUpdateDto);
                toast.AddSuccessToastMessage(Messages.About.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("ABase", "Home", new { area = "Admin" });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }


        //FACTS

        [Route("facts")]
        [HttpGet]
        public async Task<IActionResult> PageFacts()
        {
            var facts = await dashbordService.GetFacts();
            return View(facts);
        }


        [Route("add-fact")]
        [HttpGet]
        public IActionResult AddFact()
        {
            return View();
        }


        [Route("add-fact")]
        [HttpPost]
        public async Task<IActionResult> AddFact(FactAddDto factAddDto)
        {
            var map = mapper.Map<Fact>(factAddDto);
            var result = await factvalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                await dashbordService.CreateFactAsync(factAddDto);
                toast.AddSuccessToastMessage(Messages.Fact.Add(factAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageFacts", "Home");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }
        [Route("update-fact/{factName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateFact(string factName)
        {
            var fact = await dashbordService.GetFactName(factName);
            var map = mapper.Map<Fact, FactUpdateDto>(fact);

            return View(map);
        }

        [Route("update-fact/{factName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateFact(FactUpdateDto factUpdateDto)
        {
            var map = mapper.Map<Fact>(factUpdateDto);
            var result = await factvalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await dashbordService.UpdateFactAsync(factUpdateDto);
                toast.AddSuccessToastMessage(Messages.Fact.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("PageFacts", "Home");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("fact-delete/{factName}")]
        [HttpGet]
        public async Task<IActionResult> DeleteFact(string factName)
        {
            var name = await dashbordService.HardDeleteFactAsync(factName);
            toast.AddSuccessToastMessage(Messages.Fact.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("PageFacts", "Home");
        }



        [Route("smtpsettings")]
        [HttpGet]
        public async Task<IActionResult> SmtpSettings()
        {
            var smtpSettings = await smtpService.GetAllSmtpSettings();
            return View(smtpSettings);
        }


        [Route("update-smtp/{smtpName}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSmtpSettings(string smtpName)
        {
            var smtp = await smtpService.GetSmtpSetting(smtpName);
            var map = mapper.Map<SmtpSetting, SmtpSettingsUpdateDto>(smtp);

            return View(map);
        }

        [Route("update-smtp/{smtpName}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSmtpSettings(SmtpSettingsUpdateDto smtpSettingsUpdateDto)
        {
            var map = mapper.Map<SmtpSetting>(smtpSettingsUpdateDto);

            var result = await smtpvalidator.ValidateAsync(map);


            if (result.IsValid)
            {
                var name = await smtpService.UpdateSmtpSetting(smtpSettingsUpdateDto);
                toast.AddSuccessToastMessage(Messages.SmtpSetting.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("SmtpSettings", "Home");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }
        public class MessageCounts
        {
            public int SentCount { get; set; }
            public int TakedCount { get; set; }
            public int TrashCount { get; set; }
        }

        [Route("e-mail/{category}")]
        public async Task<IActionResult> Email(string category, string? searchTerm)
        {
            var messages = await messageService.GetMessagesAsync(category, searchTerm);

            var takedCount = await unitOfWork.GetRepository<Message>().CountAsync(x => x.IsInbox && !x.IsDeleted);
            var sentCount = await unitOfWork.GetRepository<Message>().CountAsync(x => x.IsSended && !x.IsDeleted);
            var trashCount = await unitOfWork.GetRepository<Message>().CountAsync(x => x.IsDeleted);

            var messageCounts = new MessageCounts
            {
                SentCount = sentCount,
                TakedCount = takedCount,
                TrashCount = trashCount
            };

            var model = new Tuple<List<MessageDto>, MessageCounts>(messages, messageCounts);

            return View(model);
        }


        [HttpPost]
        [Route("send-e/mail")]
        public async Task<IActionResult> SendEmail(string toEmail, string toCC, string subject, string body, List<IFormFile> attachments)
        {
            try
            {
                List<AttachmentInfo> attachmentList = new List<AttachmentInfo>();

                if (attachments != null && attachments.Count > 0)
                {
                    foreach (var attachment in attachments)
                    {
                        MemoryStream attachmentStream = new MemoryStream();
                        await attachment.CopyToAsync(attachmentStream);
                        attachmentStream.Position = 0;

                        attachmentList.Add(new AttachmentInfo
                        {
                            Stream = attachmentStream,
                            FileName = attachment.FileName
                        });
                    }
                }

                await messageService.SendEmailAsync(toEmail, toCC, subject, body, attachmentList);

                toast.AddSuccessToastMessage(Messages.Email.Sended(toEmail), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Email", "Home", new { category = "ınbox" });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                toast.AddErrorToastMessage("Email gönderilemiyor. Daha sonra tekrar deneyiniz.", new ToastrOptions { Title = "İşlem Başarısız" });
                return RedirectToAction("Email", "Home", new { category = "ınbox" });
            }
        }


        [HttpGet("attachments/{attachmentId}")]
        public async Task<IActionResult> DownloadAttachment(Guid attachmentId)
        {
            var attachmentRecord = await unitOfWork.GetRepository<AttachmentRecord>().GetAsync(a => a.Id == attachmentId);

            if (attachmentRecord == null)
            {
                return NotFound();
            }

            string filePath = attachmentRecord.FilePath;
            string fileName = attachmentRecord.FileName;

            // Provide the file for download
            return PhysicalFile(filePath, "application/octet-stream", fileName);
        }
        [Route("email-harddelete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> HardMessageDelete(string secName)
        {
            var name = await messageService.HardDeleteMessageAsync(secName);
            toast.AddSuccessToastMessage(Messages.Message.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Email", "Home", new { category = "ınbox" });
        }

        [Route("email-delete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> SafeMessageDelete(string secName)
        {
            var name = await messageService.SafeDeleteMessageAsync(secName);
            toast.AddSuccessToastMessage(Messages.Message.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Email", "Home", new { category = "ınbox" });
        }

        [Route("email-view/{secName}")]
        [HttpGet]
        public async Task<IActionResult> View(string secName)
        {
            var message = await messageService.GetMessageByGuid(secName);
            var map = mapper.Map<Message, MessageDto>(message);

            return View(map);
        }
    }


}

