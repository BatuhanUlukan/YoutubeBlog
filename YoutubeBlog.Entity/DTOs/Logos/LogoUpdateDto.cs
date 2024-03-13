
using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Logos
{
    public class LogoUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public ICollection<LogoImage> LogoImages { get; set; }
        public IList<IFormFile> Photos { get; set; }


    }
}