using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.DTOs.Categories
{
    public class CategoryDto : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; } // Ana veya Alt Kategori olduğunu belirtmek için
        public int ArticleCount { get; set; }

        // Bu alt kategorileri temsil edecek bir koleksiyon
        public ICollection<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}
