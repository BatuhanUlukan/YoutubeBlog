using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{

    public class HeaderViewComponent : ViewComponent
    {
        private string V = "Header";
        private readonly IDashbordService dashbordService;
        private readonly IWebHostEnvironment _environment;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IMapper mapper;




        public HeaderViewComponent(IDashbordService dashbordService, IMapper mapper, IWebHostEnvironment environment, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.dashbordService = dashbordService;
            _environment = environment;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this._user = httpContextAccessor.HttpContext.User;
        }
        public async Task<IViewComponentResult> InvokeAsync(HeaderModel errorModel = null)
        {
            HeaderModel viewModel;

            if (_user.Identity.IsAuthenticated)
            {
                var userId = _user.GetLoggedInUserId();
                var user = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, i => i.UserImagess);

                var logos = await unitOfWork.GetRepository<Logo>().GetAsync(x => x.Title == V, x => x.LogoImages);

                viewModel = new HeaderModel
                {
                    Logos = logos,
                    Users = user,
                    // Assign errorModel if not null
                    EmailError = errorModel?.EmailError,
                    PasswordError = errorModel?.PasswordError
                };
            }
            else
            {
                var logos = await unitOfWork.GetRepository<Logo>().GetAsync(x => x.Title == V, x => x.LogoImages);

                viewModel = new HeaderModel
                {
                    Logos = logos,
                    // Assign errorModel if not null
                    EmailError = errorModel?.EmailError,
                    PasswordError = errorModel?.PasswordError
                };
            }

            return View(viewModel);
        }


    }

}
