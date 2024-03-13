using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllCategoriesNonDeleted();
        Task<List<CategoryDto>> GetAllMainCategories();
        Task<List<CategoryDto>> GetAllSubCategories();
        Task<List<CategoryDto>> GetAllCategoriesNonDeletedTake24();
        Task<List<CategoryDto>> GetAllCategoriesDeleted();
        Task CreateCategoryAsync(CategoryAddDto categoryAddDto);
        Task<Category> GetCategoryByGuid(string categoryName);
        Task<string> UpdateCategoryAsync(CategoryUpdateDto categoryUpdateDto);
        Task<string> SafeDeleteCategoryAsync(string categoryName);
        Task<string> UndoDeleteCategoryAsync(string categoryName);
        Task<string> HardDeleteCategoryAsync(string categoryName);
        Task<Dictionary<string, int>> GetArticleCountByCategory();
    }
}
