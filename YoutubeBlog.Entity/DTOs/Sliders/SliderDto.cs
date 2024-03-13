using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Sliders
{
    public class SliderDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }

        public ICollection<SliderImage> SliderImages { get; set; }
        public IList<IFormFile> Photos { get; set; }

    }
}
