
using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Web.ViewComponents
{

    [ViewComponent(Name = "RandomArticles")]
    public class RandomArticlesViewComponent : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly IWebHostEnvironment _environment;

        public RandomArticlesViewComponent(IArticleService articleService, IWebHostEnvironment environment)
        {
            this._articleService = articleService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid categoryId)
        {
            var randomArticles = await _articleService.GetRandomArticlesInCategoryAsync(categoryId, 6);

            return View(randomArticles);
        }
    }
}
