using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Facts
{
    public class FactDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }


    }
}
