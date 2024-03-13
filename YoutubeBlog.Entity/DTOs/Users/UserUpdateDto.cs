using Microsoft.AspNetCore.Http;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Users
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? SecName { get; set; }
        public string About { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string NewPassword { get; set; }
        public ICollection<UserImage> UserImages { get; set; } = new List<UserImage>();
        public IList<IFormFile> Photos { get; set; } = new List<IFormFile>();
        public Guid RoleId { get; set; }
        public List<AppRole> Roles { get; set; }
    }
}
