using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Abouts
{
    public class AboutUpdateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Name2 { get; set; }
        public string? Content { get; set; }
        public string? SubContent { get; set; }
        public ICollection<AboutImage> AboutImages { get; set; } = new List<AboutImage>();
        public IList<IFormFile> Photos { get; set; } = new List<IFormFile>();
    }
}
