using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly ILogger<PortfolioController> _logger;
        private readonly IPortfolioService portfolioService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;

        public PortfolioController(ILogger<PortfolioController> logger, IPortfolioService portfolioService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.portfolioService = portfolioService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
        }
        [Route("portfolio")]
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            var portfolios = await portfolioService.GetAllByPagingAsync(categoryId, currentPage, pageSize, isAscending);
            return View(portfolios);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("portfolio/{slug}")]
        public async Task<IActionResult> Detail(string slug)


        {
            // Get the IP address of the visitor
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            // Fetch the portfolio using the given ID. If not found, return a NotFound result.
            if (string.IsNullOrWhiteSpace(slug))
            {
                return BadRequest();
            }

            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => x.Slug == slug);
            if (portfolio == null)
            {
                return NotFound();
            }
            var portfolioId = portfolio.Id;
            var portfolioTitle = portfolio.Title;
            var portfolioSlug = portfolio.Slug;

            // Fetch detailed portfolio data (with category and non-deleted condition)
            var result = await portfolioService.GetPortfolioWithCategoryNonDeletedAsync(portfolioSlug);


            // Try to fetch the visitor from the database using the IP address
            var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            if (visitor == null)
            {
                // TODO: Handle the case where the visitor does not exist in your database.
                // You may want to add them, or handle this in some other manner.
                return View(result);
            }

            // Check if the visitor has already viewed this portfolio
            var hasVisited = await unitOfWork.GetRepository<PortfolioVisitor>().AnyAsync(x => x.VisitorId == visitor.Id && x.PortfolioId == portfolio.Id);

            if (!hasVisited)
            {
                // If not visited, add a new entry to PortfolioVisitor and increase the view count for the portfolio
                var addPortfolioVisitors = new PortfolioVisitor(portfolio.Id, visitor.Id);
                await unitOfWork.GetRepository<PortfolioVisitor>().AddAsync(addPortfolioVisitors);

                portfolio.ViewCount += 1;
                await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);

                await unitOfWork.SaveAsync();
            }

            return View(result);
        }


    }
}