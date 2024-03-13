using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Social : EntityBase
    {
        public string Name { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool IsMaın { get; set; }
        public string? SecName { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }

        public Social()
        {
        }

        public Social(string name, string link, string icon, Guid userId, string createdBy)
        {

            Name = name;
            Link = link;
            Icon = icon;
            UserId = userId;
            CreatedBy = createdBy;
        }
    }

}
