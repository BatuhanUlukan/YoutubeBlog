using Microsoft.AspNetCore.Http;

namespace YoutubeBlog.Entity.DTOs.Sliders
{
    public class SliderAddDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string SubContent { get; set; }


        public IList<IFormFile> Photos { get; set; }
    }
}
