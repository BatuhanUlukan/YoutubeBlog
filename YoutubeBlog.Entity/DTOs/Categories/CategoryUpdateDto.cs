using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.DTOs.Categories
{
    public class CategoryUpdateDto : EntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; } // Eklenen Type alanı
    }
}
