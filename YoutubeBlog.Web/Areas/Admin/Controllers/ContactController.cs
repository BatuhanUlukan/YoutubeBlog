using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
    public class ContactController : Controller
    {
        private readonly IHeadquarterService headquarterService;
        private readonly IMessageService messageService;
        private readonly IValidator<Headquarter> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public ContactController(IHeadquarterService headquarterService, IMessageService messageService, IValidator<Headquarter> validator, IMapper mapper, IToastNotification toast)
        {
            this.headquarterService = headquarterService;
            this.messageService = messageService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }


        [Route("contacts")]
        [HttpGet]
        public async Task<IActionResult> Contacts()
        {
            var headquarters = await headquarterService.GetAllHeadquartersNonDeleted();
            return View(headquarters);
        }


        [Route("deleted-contact")]
        [HttpGet]
        public async Task<IActionResult> DeletedContact()
        {
            var headquarters = await headquarterService.GetAllHeadquartersDeleted();
            return View(headquarters);
        }



        [Route("contact-add")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("contact-add")]
        [HttpPost]
        public async Task<IActionResult> Add(HeadquarterAddDto headquarterAddDto)
        {
            try
            {
                await headquarterService.CreateHeadquarterAsync(headquarterAddDto);
                toast.AddSuccessToastMessage(Messages.Headquarter.Add(headquarterAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Contacts");
            }
            catch (InvalidOperationException)
            {
                toast.AddErrorToastMessage("İletişim alanı eklenemedi, ana harita için seçilmiş iletişim alanı bulunmaktadır.", new ToastrOptions { Title = "Hata" });
                return View();
            }
        }

        [Route("contact-add-with-ajax")]
        [HttpPost]
        public async Task<IActionResult> AddWithAjax([FromBody] HeadquarterAddDto headquarterAddDto)
        {
            var map = mapper.Map<Headquarter>(headquarterAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await headquarterService.CreateHeadquarterAsync(headquarterAddDto);
                toast.AddSuccessToastMessage(Messages.Headquarter.Add(headquarterAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Messages.Headquarter.Add(headquarterAddDto.Name));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [Route("contact-update/{headquarterName}")]
        [HttpGet]
        public async Task<IActionResult> Update(string headquarterName)
        {
            var headquarter = await headquarterService.GetHeadquarterByGuid(headquarterName);
            var map = mapper.Map<Headquarter, HeadquarterUpdateDto>(headquarter);

            return View(map);
        }

        [Route("contact-update/{headquarterName}")]
        [HttpPost]
        public async Task<IActionResult> Update(HeadquarterUpdateDto headquarterUpdateDto)
        {
            var map = mapper.Map<Headquarter>(headquarterUpdateDto);

            try
            {
                await headquarterService.UpdateHeadquarterAsync(headquarterUpdateDto);
                toast.AddSuccessToastMessage(Messages.Headquarter.Update(headquarterUpdateDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Contacts");
            }
            catch (InvalidOperationException)
            {
                toast.AddErrorToastMessage("İletişim alanı eklenemedi, ana harita için seçilmiş iletişim alanı bulunmaktadır.", new ToastrOptions { Title = "Hata" });
                return View();
            }
        }

        [Route("contact-delete/{headquarterName}")]
        [HttpGet]
        public async Task<IActionResult> Delete(string headquarterName)
        {
            var name = await headquarterService.SafeDeleteHeadquarterAsync(headquarterName);
            toast.AddSuccessToastMessage(Messages.Headquarter.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Contacts");
        }

        [Route("contact-undo-delete/{headquarterName}")]
        [HttpGet]
        public async Task<IActionResult> UndoDelete(string headquarterName)
        {
            var name = await headquarterService.UndoDeleteHeadquarterAsync(headquarterName);
            toast.AddSuccessToastMessage(Messages.Headquarter.UndoDelete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Contacts");
        }

        [Route("contact-hard-delete/{headquarterName}")]
        [HttpGet]
        public async Task<IActionResult> HardDelete(string headquarterName)
        {
            var title = await headquarterService.HardDeleteHeadquarterAsync(headquarterName);
            toast.AddSuccessToastMessage(Messages.Headquarter.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedContact");
        }


    }
}
