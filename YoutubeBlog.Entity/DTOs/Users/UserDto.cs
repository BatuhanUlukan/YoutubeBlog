using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string About { get; set; }
        public string? SecName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool EmailConfirmed { get; set; }
        public int AccessFailedCount { get; set; }
        public string Role { get; set; }
        public ICollection<UserImage> UserImagess { get; set; } = new List<UserImage>();
        public ICollection<Duty> Duties { get; set; }



    }
}
