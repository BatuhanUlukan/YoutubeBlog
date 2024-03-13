using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Portfolios
{
    public class PortfolioUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Slug { get; set; }
        public bool IsActive { get; set; }

        public Guid CategoryId { get; set; }

        // Birden fazla resim olacağı için list yapıda olmalı
        public ICollection<PortfolioImage> PortfolioImages { get; set; } = new List<PortfolioImage>();
        public IList<IFormFile> Photos { get; set; } = new List<IFormFile>();

        public IList<CategoryDto> Categories { get; set; }
    }
}
