using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IValidator<Category> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;

        public CategoryController(ICategoryService categoryService, IValidator<Category> validator, IMapper mapper, IToastNotification toast)
        {
            this.categoryService = categoryService;
            this.validator = validator;
            this.mapper = mapper;
            this.toast = toast;
        }

        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesNonDeleted();
            return View(categories);
        }

        [Route("deleted-category")]
        [HttpGet]
        public async Task<IActionResult> DeletedCategory()
        {
            var categories = await categoryService.GetAllCategoriesDeleted();
            return View(categories);
        }

        [Route("add-category")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add-category")]
        [HttpPost]
        public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }


        [Route("category-add-with-ajax")]
        [HttpPost]
        public async Task<IActionResult> AddWithAjax(CategoryAddDto categoryAddDto)
        {
            var map = mapper.Map<Category>(categoryAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await categoryService.CreateCategoryAsync(categoryAddDto);
                toast.AddSuccessToastMessage(Messages.Category.Add(categoryAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return Json(Messages.Category.Add(categoryAddDto.Name));
            }
            else
            {
                toast.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [Route("update-category/{secName}")]
        [HttpGet]
        public async Task<IActionResult> Update(string secName)
        {
            var category = await categoryService.GetCategoryByGuid(secName);
            var map = mapper.Map<Category, CategoryUpdateDto>(category);

            return View(map);
        }

        [Route("update-category/{secName}")]
        [HttpPost]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var map = mapper.Map<Category>(categoryUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await categoryService.UpdateCategoryAsync(categoryUpdateDto);
                toast.AddSuccessToastMessage(Messages.Category.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Index", "Category");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("category-delete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> Delete(string secName)
        {
            var name = await categoryService.SafeDeleteCategoryAsync(secName);
            toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Category");
        }

        [Route("category-undo-delete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> UndoDelete(string secName)
        {
            var name = await categoryService.UndoDeleteCategoryAsync(secName);
            toast.AddSuccessToastMessage(Messages.Category.Delete(name), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Index", "Category");
        }
        [Route("category-hard-delete/{secName}")]
        [HttpGet]
        public async Task<IActionResult> HardDelete(string secName)
        {
            var title = await categoryService.HardDeleteCategoryAsync(secName);
            toast.AddSuccessToastMessage(Messages.Category.Delete(title), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("DeletedCategory", "Category", new { Area = "Admin" });
        }
    }
}
