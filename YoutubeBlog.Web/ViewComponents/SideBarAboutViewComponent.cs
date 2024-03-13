using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{

    public class SideBarAboutViewComponent : ViewComponent
    {
        private readonly IArticleService articleService;
        private readonly IUserService userService;
        private readonly IWebHostEnvironment _environment;

        public SideBarAboutViewComponent(IArticleService articleService, IUserService userService, IWebHostEnvironment environment)
        {
            this.articleService = articleService;
            this.userService = userService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid articleId, Guid userId)
        {
            var authorInfo = await articleService.GetAuthorInfoAsync(articleId);

            var socialInfo = await userService.GetSocialProfilesForUser(userId);

            var viewModel = new SideBarAboutViewModel
            {
                User = authorInfo,
                Socials = socialInfo
            };

            return View(viewModel);
        }
    }


}
