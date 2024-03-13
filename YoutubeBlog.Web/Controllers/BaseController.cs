using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        private readonly IClientService clientService;
        private readonly IArticleService articleService;
        private readonly IPortfolioService portfolioService;
        private readonly IUserService userService;
        private readonly IDashbordService dashboardService;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUnitOfWork unitOfWork;
        private string V = "Base";
        private readonly IMapper mapper;


        public BaseController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService, IDashbordService dashboardService, IArticleService articleService, IClientService clientService, IMapper mapper, IPortfolioService portfolioService, IUnitOfWork unitOfWork)
        {
            this.articleService = articleService;
            this.clientService = clientService;
            this.mapper = mapper;
            this.portfolioService = portfolioService;
            this.userService = userService;
            this.dashboardService = dashboardService;
            this.unitOfWork = unitOfWork;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Route("/")]
        [Route("base")]
        public async Task<IActionResult> Index()
        {
            // Fetch all non-deleted and active portfolios along with their categories
            var clients = await unitOfWork.GetRepository<Client>().GetAllAsync(
                x => !x.IsDeleted,
                i => i.ClientImages
            );

            var map = mapper.Map<List<ClientDto>>(clients);

            var articles = await articleService.GetRandomArticlesAsync(8);
            var portfolios = await portfolioService.GetRandomPortfoliosAsync(8);
            var services = await userService.GetAllServicesForMains();
            var sliders = await dashboardService.GetSliders();
            var facts = await dashboardService.GetFacts();
            var about = await dashboardService.GetAbout();
            var pageSeo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == V);


            var viewModel = new BasePageViewModel
            {
                Clients = map,
                Services = services,
                Articles = articles,
                Sliders = sliders,
                Facts = facts,
                Abouts = about,
                Portfolios = portfolios,
                PageSeos = pageSeo

            };

            return View(viewModel);
        }



    }
}
