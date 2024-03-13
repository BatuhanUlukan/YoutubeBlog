using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Areas.Admin.Models;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService portfolioService;
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;
        private readonly IValidator<Portfolio> validator;
        private readonly IToastNotification toast;

        public PortfolioController(IPortfolioService portfolioService, ICategoryService categoryService, IMapper mapper, IValidator<Portfolio> validator, IToastNotification toast)
        {
            this.portfolioService = portfolioService;
            this.categoryService = categoryService;
            this.mapper = mapper;
            this.validator = validator;
            this.toast = toast;
        }


        [Route("portfolios")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Portfolios(int page = 1) // Varsayılan olarak 1. sayfa
        {
            var portfolios = await portfolioService.GetAllPortfoliosWithCategoryNonDeletedAsync();

            // Burada toplam sayfa sayısını hesaplama ve diğer gereklilikleri eklemelisiniz.
            // Örnek olarak, her sayfada 10 makale olduğunu varsayalım:
            int pageSize = 12;
            int totalPortfolios = portfolios.Count;
            int totalPages = (int)Math.Ceiling((double)totalPortfolios / pageSize);

            var pagedPortfolio = portfolios.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new PortfolioPageModel
            {
                Portfolios = pagedPortfolio,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }


        [Route("deleted-portfolio")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> DeletedPortfolio(int page = 1) // Varsayılan olarak 1. sayfa
        {
            var portfolios = await portfolioService.GetAllPortfoliosWithCategoryDeletedAsync();

            // Burada toplam sayfa sayısını hesaplama ve diğer gereklilikleri eklemelisiniz.
            // Örnek olarak, her sayfada 10 makale olduğunu varsayalım:
            int pageSize = 12;
            int totalPortfolios = portfolios.Count;
            int totalPages = (int)Math.Ceiling((double)totalPortfolios / pageSize);

            var pagedPortfolio = portfolios.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var model = new PortfolioPageModel
            {
                Portfolios = pagedPortfolio,
                CurrentPage = page,
                TotalPages = totalPages
            };

            return View(model);
        }

        [Route("portfolio-add")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new PortfolioAddDto { Categories = categories });
        }

        [Route("portfolio-add")]
        [HttpPost]
        public async Task<IActionResult> Add(PortfolioAddDto portfolioAddDto)
        {
            var map = mapper.Map<Portfolio>(portfolioAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await portfolioService.CreatePortfolioAsync(portfolioAddDto);
                toast.AddSuccessToastMessage(Messages.Portfolio.Add(portfolioAddDto.Title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Portfolios");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(new PortfolioAddDto { Categories = categories });
        }

        [Route("portfolio-update/{portfolioSlug}")]
        [HttpGet]
        public async Task<IActionResult> Update(string portfolioSlug)
        {
            var portfolio = await portfolioService.GetPortfolioWithCategoryNonDeletedAsync(portfolioSlug);
            var categories = await categoryService.GetAllCategoriesNonDeleted();

            var portfolioUpdateDto = mapper.Map<PortfolioUpdateDto>(portfolio);
            portfolioUpdateDto.Categories = categories;

            return View(portfolioUpdateDto);
        }

        [Route("portfolio-update/{portfolioSlug}")]
        [HttpPost]
        public async Task<IActionResult> Update(PortfolioUpdateDto portfolioUpdateDto)
        {
            var map = mapper.Map<Portfolio>(portfolioUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var title = await portfolioService.UpdatePortfolioAsync(portfolioUpdateDto);
                toast.AddSuccessToastMessage(Messages.Portfolio.Update(title), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Portfolios");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            var categories = await categoryService.GetAllCategoriesNonDeleted();
            portfolioUpdateDto.Categories = categories;
            return View(portfolioUpdateDto);
        }

        [Route("portfolio-delete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> Delete(string secName)
        {
            var title = await portfolioService.SafeDeletePortfolioAsync(secName);
            toast.AddSuccessToastMessage(Messages.Portfolio.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Portfolios");
        }

        [Route("portfolio-undo-delete/{portfolioSlug}")]
        [HttpGet]
        public async Task<IActionResult> UndoDelete(string portfolioSlug)
        {
            var title = await portfolioService.UndoDeletePortfolioAsync(portfolioSlug);
            toast.AddSuccessToastMessage(Messages.Portfolio.UndoDelete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedPortfolio");
        }

        [Route("portfolio-hard-delete/{portfolioSlug}")]
        [HttpGet]
        public async Task<IActionResult> HardDelete(string portfolioSlug)
        {
            var title = await portfolioService.HardDeletePortfolioAsync(portfolioSlug);
            toast.AddSuccessToastMessage(Messages.Portfolio.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedPortfolio");
        }
    }
}
