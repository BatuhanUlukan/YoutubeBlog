using YoutubeBlog.Core.Entities;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Portfolios
{
    public class PortfolioDto : EntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Link { get; set; }
        public string Slug { get; set; }

        public CategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; }

        // Birden fazla Image olabileceği için Images adında bir ICollection olarak değiştirilmiştir.
        public ICollection<PortfolioImage> PortfolioImages { get; set; } = new List<PortfolioImage>();

        public AppUser User { get; set; }

        public int ViewCount { get; set; }
    }
}
