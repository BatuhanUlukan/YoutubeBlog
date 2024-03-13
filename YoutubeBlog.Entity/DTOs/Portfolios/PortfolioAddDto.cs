using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.DTOs.Categories;

namespace YoutubeBlog.Entity.DTOs.Portfolios
{
    public class PortfolioAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }

        public Guid CategoryId { get; set; }

        public IList<IFormFile> Photos { get; set; }

        public IList<CategoryDto> Categories { get; set; }
    }
}
