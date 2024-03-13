using Microsoft.AspNetCore.Http;

namespace YoutubeBlog.Entity.DTOs.Clients
{
    public class ClientAddDto
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }


        public IList<IFormFile> Photos { get; set; }
    }
}
