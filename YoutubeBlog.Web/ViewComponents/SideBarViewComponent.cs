using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly IPortfolioService portfolioService;
        private readonly ICommentService commentService;
        private readonly IWebHostEnvironment _environment;

        public SideBarViewComponent(ICommentService commentService, ICategoryService categoryService, IPortfolioService portfolioService, IWebHostEnvironment environment)
        {
            this.categoryService = categoryService;
            this.portfolioService = portfolioService;
            this.commentService = commentService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await categoryService.GetAllCategoriesNonDeletedTake24();

            // Her kategoriye ait makale sayısını hesapla ve kategoriye ekle
            foreach (var category in categories)
            {
                string categoryName = category.Name;
                var articleCountByCategory = await categoryService.GetArticleCountByCategory();

                // Check if the category name exists in the dictionary
                if (articleCountByCategory.ContainsKey(categoryName))
                {
                    // Assign the article count for the current category
                    category.ArticleCount = articleCountByCategory[categoryName];
                }
                else
                {
                    // Handle the case when the category name is not found in the dictionary
                    category.ArticleCount = 0; // Or any default value you want
                }
            }

            // Filter categories with article count greater than 1
            var filteredCategories = categories.Where(c => c.ArticleCount >= 1).ToList();

            var portfolios = await portfolioService.GetRandomPortfoliosAsync(3);
            var comments = await commentService.GetRandomComments(3);

            var viewModel = new SideBarViewModel
            {
                Categories = filteredCategories,
                Portfolios = portfolios,
                Comments = comments
            };

            return View(viewModel);
        }
    }
}
