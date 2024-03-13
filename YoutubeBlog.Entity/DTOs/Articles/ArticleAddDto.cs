using Microsoft.AspNetCore.Http;
using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Articles
{
    public class ArticleAddDto : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public bool IsSliderIsActive { get; set; }
        public Guid CategoryId { get; set; }
        public IList<CategoryDto> Categories { get; set; }
        public ICollection<ArticleImage> ArticleImages { get; set; }
        public IList<IFormFile> Photos { get; set; }
    }
}
