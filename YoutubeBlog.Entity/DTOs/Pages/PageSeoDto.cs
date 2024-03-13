using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Pages
{
    public class PageSeoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public string Page { get; set; }


    }
}
