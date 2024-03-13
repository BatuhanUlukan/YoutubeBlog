using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Web.ViewComponents
{

    [ViewComponent(Name = "RandomPortfolios")]
    public class RandomPortfoliosViewComponent : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IWebHostEnvironment _environment;
        public RandomPortfoliosViewComponent(IPortfolioService portfolioService, IWebHostEnvironment environment)
        {
            this._portfolioService = portfolioService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var randomPortfolios = await _portfolioService.GetRandomPortfoliosAsync(6);

            return View(randomPortfolios);
        }
    }

}
