using Microsoft.AspNetCore.Identity;
using System.Xml.Linq;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecName { get; set; }
        public string? About { get; set; }  // Eğer zaten string ise bu özellik varsayılan olarak opsiyonel olacaktır.

        public ICollection<UserImage> UserImagess { get; set; }  // Retained the relationship
        public ICollection<Article> Articles { get; set; }
        public ICollection<Social> Socials { get; set; }
        public ICollection<Duty> Duties { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
