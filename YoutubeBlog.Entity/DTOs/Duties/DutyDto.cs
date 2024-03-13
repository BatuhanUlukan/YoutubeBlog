using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Duties
{
    public class DutyDto
    {
        public Guid Id { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }
        public string Content { get; set; }
        public bool IsMaın { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public AppUser User { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeletedDate { get; set; }

    }
}
