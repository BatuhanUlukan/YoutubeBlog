using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Entity.DTOs.Categories
{
    public class CategoryAddDto  : EntityBase
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; } // Eklenen Type alanı

    }
}
