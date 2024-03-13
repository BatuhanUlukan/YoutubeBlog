using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Areas.Admin.Models;
using YoutubeBlog.Web.Consts;
using static YoutubeBlog.Web.ResultMessages.Messages;

namespace YoutubeBlog.Web.Areas.Admin.ViewComponents
{
    public class AdmınViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AdmınViewComponent(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userService = userService;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            // Assuming unitOfWork is an instance of your unit of work class
            var user = await unitOfWork.GetRepository<AppUser>()
                .GetAsync(x => x.Id == userId, i => i.UserImagess, i => i.Duties);  // Include Duties here
            var map = mapper.Map<AppUser>(user);

            return map;
        }


        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        public async Task<bool> GetRole()
        {

            bool falsetrue;

            var userEmail = _user.GetLoggedInEmail();
            var user = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Email == userEmail);
            var userRole = await GetUserRoleAsync(user);

            // Check if the user has either "Admin" or "SuperAdmin" role
            if (userRole == "Admin" || userRole == "Superadmin")
            {
                falsetrue = true;
            }
            else
            {
                falsetrue = false;
            }

            return falsetrue;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Await the asynchronous GetRole method
            var role = await GetRole();

            // Create the model
            var model = new AdminModel
            {
                role = role.ToString() // Convert the boolean role to string
            };

            // Return the model with the view
            return View(model);
        }



    }
}
