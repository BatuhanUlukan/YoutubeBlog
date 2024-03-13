using YoutubeBlog.Core.Entities;


namespace YoutubeBlog.Entity.Entities
{
    public class Duty : EntityBase
    {
        public Duty()
        {

        }

        public Duty(string name, string icon, string content, Guid userId, string createdBy)
        {
            Name = name;
            Icon = icon;
            Content = content;
            UserId = userId;
            CreatedBy = createdBy;
        }

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }
        public string Content { get; set; }
        public bool IsMaın { get; set; }


    }
}
