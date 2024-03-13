using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Article : EntityBase
    {
        public Article()
        {
            ArticleImages = new HashSet<ArticleImage>();

        }
        public Article(string title, string slug, string description, string content, Guid userId, string createdBy, Guid categoryId)
        {
            Title = title;
            Slug = slug;
            Description = description;
            Content = content;
            UserId = userId;
            CreatedBy = createdBy;
            CategoryId = categoryId;
            ArticleImages = new HashSet<ArticleImage>();

        }

        public string Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }
        public bool? IsSliderIsActive { get; set; }

        public string Content { get; set; }
        public int ViewCount { get; set; } = 0;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<ArticleImage> ArticleImages { get; set; }  // Retained the relationship

        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<ArticleVisitor> ArticleVisitors { get; set; }
        public ICollection<Comment> Comments { get; set; }






    }
}