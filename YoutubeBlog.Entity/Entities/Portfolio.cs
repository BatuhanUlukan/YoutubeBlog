using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Portfolio : EntityBase
    {
        public Portfolio()
        {
            PortfolioImages = new HashSet<PortfolioImage>();
        }

        public Portfolio(string title, string content, string link, Guid userId, string createdBy, Guid categoryId)
        {
            Title = title;
            Content = content;
            UserId = userId;
            CategoryId = categoryId;
            CreatedBy = createdBy;
            Link = link;
            PortfolioImages = new HashSet<PortfolioImage>();
        }

        public string Title { get; set; }
        public string? Slug { get; set; }

        public string Link { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<PortfolioImage> PortfolioImages { get; set; }  // Retained the relationship

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<PortfolioVisitor> PortfolioVisitors { get; set; }
    }
}
