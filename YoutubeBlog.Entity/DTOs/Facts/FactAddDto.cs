using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Facts
{
    public class FactAddDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
    }
}
