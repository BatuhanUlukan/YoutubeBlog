using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Articles
{
    public class ArticleDto : EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public ICollection<CategoryDto> Categories { get; set; } = new List<CategoryDto>();

        public ICollection<ArticleImage> ArticleImages { get; set; } = new List<ArticleImage>();
        public AppUser User { get; set; }
        public bool IsSliderIsActive { get; set; }
        public int ViewCount { get; set; }


    }
}
