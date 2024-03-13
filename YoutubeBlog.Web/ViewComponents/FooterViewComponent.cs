using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{

    public class FooterViewComponent : ViewComponent
    {
        private string V = "Footer";
        private readonly IDashbordService dashbordService;
        private readonly IWebHostEnvironment _environment;
        private readonly IUnitOfWork unitOfWork;
        private readonly IUserService userService;
        private readonly IHeadquarterService headquarterService;


        public FooterViewComponent(IDashbordService dashbordService, IWebHostEnvironment environment, IUserService userService, IUnitOfWork unitOfWork, IHeadquarterService headquarterService)
        {
            this.dashbordService = dashbordService;
            _environment = environment;
            this.unitOfWork = unitOfWork;
            this.userService = userService;
            this.headquarterService = headquarterService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var logo = await unitOfWork.GetRepository<Logo>().GetAsync(x => x.Title == V, x => x.LogoImages);
            var socials = await userService.GetMaınPageSocials();
            var headquarters = await headquarterService.GetAllHeadquarteersMaınPage();



            var viewModel = new HeaderModel
            {
                Logos = logo,
                Socials = socials,
                Headquarters = headquarters,

            };
            return View(viewModel);
        }
    }

}
