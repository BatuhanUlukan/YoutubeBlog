using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Clients
{
    public class ClientDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public ICollection<ClientImage> ClientImages { get; set; }
        public IList<IFormFile> Photos { get; set; }

    }
}
