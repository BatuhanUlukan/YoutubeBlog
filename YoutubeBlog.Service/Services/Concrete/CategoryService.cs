using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }
        public async Task<Dictionary<string, int>> GetArticleCountByCategory()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);

            var articleCountByCategory = new Dictionary<string, int>();

            foreach (var category in categories)
            {
                var activeArticleCount = await unitOfWork.GetRepository<Article>().CountAsync(article =>
                    article.CategoryId == category.Id && article.IsActive && !article.IsDeleted);

                articleCountByCategory.Add(category.Name, activeArticleCount);
            }

            return articleCountByCategory;
        }


        public async Task<List<CategoryDto>> GetAllCategoriesNonDeleted()
        {

            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }
        public async Task<List<CategoryDto>> GetAllMainCategories()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted && x.Type == CategoryType.Main);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }

        public async Task<List<CategoryDto>> GetAllSubCategories()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted && x.Type == CategoryType.Sub);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map.Take(24).ToList();
        }





        public async Task CreateCategoryAsync(CategoryAddDto categoryAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Category category = new Category(categoryAddDto.Name, userEmail, categoryAddDto.Type);

            await unitOfWork.GetRepository<Category>().AddAsync(category);
            await unitOfWork.SaveAsync();
        }


        public async Task<Category> GetCategoryByGuid(string secName)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => x.SecName == secName);
            return category;
        }
        public async Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => !x.IsDeleted && x.SecName == categoryUpdateDto.SecName);

            category.Name = categoryUpdateDto.Name;
            category.Type = categoryUpdateDto.Type;


            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();


            return category.Name;
        }

        public async Task<string> SafeDeleteCategoryAsync(string secName)
        {
            var userEmail = _user.GetLoggedInEmail();
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => x.SecName == secName);

            category.IsDeleted = true;
            category.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }

        public async Task<List<CategoryDto>> GetAllCategoriesDeleted()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<CategoryDto>>(categories);

            return map;
        }

        public async Task<string> UndoDeleteCategoryAsync(string categoryName)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => x.Name == categoryName);

            category.IsDeleted = false;
            category.DeletedDate = null;
            category.DeletedBy = null;

            await unitOfWork.GetRepository<Category>().UpdateAsync(category);
            await unitOfWork.SaveAsync();

            return category.Name;
        }
        public async Task<string> HardDeleteCategoryAsync(string categoryName)
        {
            var category = await unitOfWork.GetRepository<Category>().GetAsync(x => x.Name == categoryName);

            if (category != null)
            {
                // Remove the entity from the repository
                await unitOfWork.GetRepository<Category>().DeleteAsync(category);
                await unitOfWork.SaveAsync();

                return category.Name;
            }

            // If the headquarter with the specified ID doesn't exist, you can handle the error or return an appropriate value.
            return null; // Or throw an exception, depending on your error handling strategy.
        }

    }
}
