using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Diagnostics;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Models;
using YoutubeBlog.Web.ResultMessages;


namespace YoutubeBlog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
        private readonly IUserService userService;
        private readonly ICommentService commentService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<Comment> validator;
        private ICommentService CommentService => commentService;
        public HomeController(IUserService userService, IValidator<Comment> validator, ILogger<HomeController> logger, ICommentService commentService, IArticleService articleService, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toast)
        {
            _logger = logger;
            this.articleService = articleService;
            this.httpContextAccessor = httpContextAccessor;
            this.unitOfWork = unitOfWork;
            this.commentService = commentService;
            this.userService = userService;
            this.toast = toast;
            this.mapper = mapper;
            this.validator = validator;

        }

        [Route("about-me/{user}")]
        [HttpGet]
        public async Task<IActionResult> About(string user)
        {
            var users = await userService.GetAppUserAsync(user);

            if (users == null)
            {
                // Handle the case where the user is not found
                return NotFound();
            }

            var map = mapper.Map<AppUser>(users);

            // Explicitly set the properties after mapping.
            map.UserImagess = users.UserImagess;
            map.Duties = users.Duties;

            return View(map);
        }

        [Route("blog")]
        [HttpGet]
        public async Task<IActionResult> Index(string? categoryName, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            var articles = await articleService.GetAllByPagingAsync(categoryName, currentPage, pageSize, isAscending);
            return View(articles);
        }
        [Route("blog/category/{categoryName?}")]
        [HttpGet]
        public async Task<IActionResult> Category(string categoryName, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            var articles = await articleService.GetAllByPagingAsync(categoryName, currentPage, pageSize, isAscending);
            return View(articles);
        }


        [Route("blog/search")]
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            var articles = await articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);

            return View(articles);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("blog/{slug}")]
        [HttpGet]
        public async Task<IActionResult> Detail(string slug)


        {
            // Get the IP address of the visitor
            var ipAddress = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();

            // Fetch the article using the given ID. If not found, return a NotFound result.
            if (string.IsNullOrWhiteSpace(slug))
            {
                return BadRequest();
            }

            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == slug);
            if (article == null)
            {
                return NotFound();
            }

            var articleId = article.Id;
            var articleTitle = article.Title;

            // Fetch detailed article data (with category and non-deleted condition)
            var result = await articleService.GetArticleWithCategoryNonDeletedAsync(slug, articleTitle, articleId);


            // Try to fetch the visitor from the database using the IP address
            var visitor = await unitOfWork.GetRepository<Visitor>().GetAsync(x => x.IpAddress == ipAddress);

            if (visitor == null)
            {

                return View(result);
            }

            // Check if the visitor has already viewed this article
            var hasVisited = await unitOfWork.GetRepository<ArticleVisitor>().AnyAsync(x => x.VisitorId == visitor.Id && x.ArticleId == article.Id);

            if (!hasVisited)
            {
                // If not visited, add a new entry to ArticleVisitor and increase the view count for the article
                var addArticleVisitors = new ArticleVisitor(article.Id, visitor.Id);
                await unitOfWork.GetRepository<ArticleVisitor>().AddAsync(addArticleVisitors);

                article.ViewCount += 1;
                await unitOfWork.GetRepository<Article>().UpdateAsync(article);

                await unitOfWork.SaveAsync();
            }

            var viewModel = new HomeIndexViewModel
            {
                ArticleId = result.Id,
                Article = result,
            };

            return View(viewModel);
        }

        [Route("blog/comment")]
        [HttpPost]
        public async Task<IActionResult> Comment([Bind(Prefix = "Comment")] CommentAddDto commentAddDto)
        {
            var map = mapper.Map<Comment>(commentAddDto);
            Guid articleId = commentAddDto.ArticleId;
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Id == articleId);

            string slug = article.Slug;

            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await CommentService.CreateCommentAsync(commentAddDto);
                toast.AddSuccessToastMessage(Messages.Comment.Add(commentAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Detail", "Home", new { slug });
            }

            result.AddToModelState(this.ModelState);
            return View();
        }




    }
}