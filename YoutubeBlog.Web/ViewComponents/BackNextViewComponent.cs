using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{

    public class BackNextViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly IWebHostEnvironment _environment;


        public BackNextViewComponent(IArticleService articleService, IWebHostEnvironment environment)
        {
            this._articleService = articleService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync(string slug)
        {
            var previousArticleDto = await _articleService.GetAdjacentArticleAsync(slug, ArticleDirection.Previous);
            var nextArticleDto = await _articleService.GetAdjacentArticleAsync(slug, ArticleDirection.Next);

            var model = new AdjacentArticleViewModel
            {
                PreviousArticle = previousArticleDto,
                NextArticle = nextArticleDto
            };

            return View(model);
        }

    }


}
