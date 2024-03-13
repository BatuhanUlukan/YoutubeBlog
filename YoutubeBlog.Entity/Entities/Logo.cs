using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Logo : EntityBase
    {
        public Logo()
        {
            LogoImages = new HashSet<LogoImage>();

        }
        public Logo(string title, string slug)
        {
            Title = title;
            Slug = slug;
            LogoImages = new HashSet<LogoImage>();

        }

        public string Title { get; set; }
        public string? Slug { get; set; }
        public string? Description { get; set; }

        public ICollection<LogoImage> LogoImages { get; set; }  // Retained the relationship

    }
}