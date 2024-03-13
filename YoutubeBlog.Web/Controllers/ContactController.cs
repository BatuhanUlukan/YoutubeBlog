using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;
using YoutubeBlog.Web.ResultMessages;

public class ContactController : Controller
{
    private readonly IHeadquarterService headquarterService;
    private readonly IUserService userService;
    private readonly IMessageService messageService;
    private readonly IMapper mapper;
    private readonly IValidator<Message> validator;
    private readonly IUnitOfWork unitOfWork;
    private readonly IToastNotification toast;
    private string V = "Contact";

    public ContactController(IUnitOfWork unitOfWork, IUserService userService, IHeadquarterService headquarterService, IValidator<Message> validator, IMapper mapper, IMessageService messageService, IToastNotification toast)
    {
        this.headquarterService = headquarterService;
        this.messageService = messageService;
        this.toast = toast;
        this.validator = validator;
        this.mapper = mapper;
        this.userService = userService;
        this.unitOfWork = unitOfWork;


    }

    [Route("contact")]
    public async Task<IActionResult> Index()
    {
        var headquarters = await headquarterService.GetAllHeadquarteersMaınPage();
        var socials = await userService.GetMaınPageSocials();
        var pageSeo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == V);

        var viewModel = new ContactIndexViewModel
        {
            Headquarters = headquarters,
            Socials = socials,
            PageSeos = pageSeo

        };
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Send([Bind(Prefix = "Message")] MessageAddDto messageAddDto)
    {
        var map = mapper.Map<Message>(messageAddDto);
        var result = await validator.ValidateAsync(map);

        if (result.IsValid)
        {
            await messageService.CreateMessageAsync(messageAddDto);
            toast.AddSuccessToastMessage(Messages.Message.Add(messageAddDto.Subject), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("Index", "Contact");
        }

        result.AddToModelState(this.ModelState);
        return View();
    }




}

