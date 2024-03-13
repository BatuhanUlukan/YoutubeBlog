using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Socials
{
    public class SocialDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }

        public string Link { get; set; }
        public string Icon { get; set; }
        public bool IsMaın { get; set; }
        public bool IsActive { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }
        public bool IsDeleted { get; set; }

        public AppUser User { get; set; }


    }

}
