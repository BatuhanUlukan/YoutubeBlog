using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Clients
{
    public class ClientUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }


        public ICollection<ClientImage> ClientImages { get; set; } = new List<ClientImage>();
        public IList<IFormFile> Photos { get; set; } = new List<IFormFile>();
    }
}
