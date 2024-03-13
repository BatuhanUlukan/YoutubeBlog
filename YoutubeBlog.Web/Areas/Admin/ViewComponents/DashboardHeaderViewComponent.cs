using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Areas.Admin.Models;

namespace YoutubeBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IMessageService messageService;
        private readonly IUserService userService;
        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor httpContextAccessor;



        public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMessageService messageService, IMapper mapper, IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;
            this.messageService = messageService;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var loggedInUser = await userManager.GetUserAsync(HttpContext.User);
            var map = mapper.Map<UserDto>(loggedInUser);

            var user = await userService.GetAppUserByIdAsync(userId);
            var last4Messages = await messageService.GetLast4MessagesAsync();
            var last12HoursMessageCount = await messageService.GetTotalMessagesInLast12HoursAsync();

            var role = string.Join("", await userManager.GetRolesAsync(loggedInUser));
            map.Role = role;
            map.UserImagess = user.UserImagess;

            var model = new UserPageModel
            {
                User = map,
                Last4Messages = last4Messages,
                Last12HoursMessageCount = last12HoursMessageCount
            };

            return View(model);
        }


    }
}
