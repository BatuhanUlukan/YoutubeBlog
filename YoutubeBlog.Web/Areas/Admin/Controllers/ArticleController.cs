using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ArticleController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Article> validator;
        private readonly IToastNotification toast;

        public ICategoryService CategoryService => categoryService;

        public ArticleController(IArticleService articleService, ICategoryService categoryService, IMapper mapper, IValidator<Article> validator, IToastNotification toast)
        {
            this.articleService = articleService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }

        [Route("approve-article/{articleSlug}")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Approve(string articleSlug)
        {
            var title = await articleService.ApproveArticle(articleSlug);
            toast.AddSuccessToastMessage(Messages.Article.Approve(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Articles", "Article", new { Area = "Admin" });
        }

        [Route("reject-article/{articleSlug}")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Reject(string articleSlug)
        {
            var title = await articleService.RejectArticle(articleSlug);
            toast.AddSuccessToastMessage(Messages.Article.Reject(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Articles", "Article", new { Area = "Admin" });
        }

        [Route("articles")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Articles(int page = 1) // Varsayılan olarak 1. sayfa
        {
            var articles = await articleService.GetAllArticlesWithCategoryNonDeletedAsync();


            int pageSize = 16;
            int totalArticles = articles.Count;
            int totalPages = (int)Math.Ceiling((double)totalArticles / pageSize);

            var pagedArticles = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new ArticlePageModel
            {
                Articles = pagedArticles,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        [Route("deleted-articles")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> DeletedArticle(int page = 1) // Varsayılan olarak 1. sayfa
        {
            var articles = await articleService.GetAllArticlesWithCategoryDeletedAsync();


            int pageSize = 12;
            int totalArticles = articles.Count;
            int totalPages = (int)Math.Ceiling((double)totalArticles / pageSize);

            var pagedArticles = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new ArticlePageModel
            {
                Articles = pagedArticles,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        [Route("articles/search")]
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            var articles = await articleService.SearchAsync(keyword, currentPage, pageSize, isAscending);

            return View(articles);
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Add()
        {
            var mainCategories = await CategoryService.GetAllMainCategories();
            var subCategories = await CategoryService.GetAllSubCategories();
            var categories = await CategoryService.GetAllCategoriesNonDeleted();


            return View(categories);
        }

        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
        {
            var map = mapper.Map<Article>(articleAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await articleService.CreateArticleAsync(articleAddDto);
                toast.AddSuccessToastMessage(Messages.Article.Add(articleAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });

                return RedirectToAction("Articles", "Article", new { Area = "Admin" });
            }

            result.AddToModelState(this.ModelState);

            // Hata durumunda, aynı view'i döndürerek kullanıcının bilgilerini korumak için ArticleAddDto nesnesini doldurun
            var mainCategories = await CategoryService.GetAllMainCategories();
            var subCategories = await CategoryService.GetAllSubCategories();

            var categories = await CategoryService.GetAllCategoriesNonDeleted();
            articleAddDto.Categories = categories;

            return View(articleAddDto);
        }


        [Route("update-article/{articleSlug}")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Update(string? articleSlug, string? articleTitle, Guid? articleId)
        {
            var article = await articleService.GetArticleWithCategoryNonDeletedAsync(articleSlug, articleTitle,articleId);

            var mainCategories = await CategoryService.GetAllMainCategories();
            var subCategories = await CategoryService.GetAllSubCategories();
            var categories = await CategoryService.GetAllCategoriesNonDeleted();

            var articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
            articleUpdateDto.Categories = categories;

            return View(articleUpdateDto);
        }


        [Route("update-article/{articleSlug}")]
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
        {
            var map = mapper.Map<Article>(articleUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await articleService.UpdateArticleAsync(articleUpdateDto);
                toast.AddSuccessToastMessage(Messages.Article.Update(title), new ToastrOptions() { Title = "İşlem Başarılı" });
                return RedirectToAction("Articles", "Article", new { Area = "Admin" });
            }
            else
            {
                // Doğrulama başarısız olduğunda, ModelState'a hataları ekle
                result.AddToModelState(this.ModelState);

                // Ana ve alt kategorileri tekrar alın
                var mainCategories = await CategoryService.GetAllMainCategories();
                var subCategories = await CategoryService.GetAllSubCategories();
                var categoriesdto = await CategoryService.GetAllCategoriesNonDeleted();

                // ArticleUpdateDto nesnesini oluşturun ve view'e gönderin
                var categories = new ArticleUpdateDto
                {
                    Categories = categoriesdto
                };

                return View(categories);

            }

        }

        [Route("delete-article/{articleSlug}")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> Delete(string articleSlug)
        {
            var title = await articleService.SafeDeleteArticleAsync(articleSlug);
            toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Articles", "Article", new { Area = "Admin" });
        }

        [Route("undo-delete-article/{articleSlug}")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> UndoDelete(string articleSlug)
        {
            var title = await articleService.UndoDeleteArticleAsync(articleSlug);
            toast.AddSuccessToastMessage(Messages.Article.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedArticle", "Article", new { Area = "Admin" });
        }

        [Route("hard-delete-article/{articleSlug}")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        public async Task<IActionResult> HardDelete(string articleSlug)
        {
            var title = await articleService.HardDeleteArticleAsync(articleSlug);
            toast.AddSuccessToastMessage(Messages.Article.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedArticle", "Article", new { Area = "Admin" });
        }

    }
}
