using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Client : EntityBase
    {
        public Client()
        {
            ClientImages = new HashSet<ClientImage>();

        }
        public Client(string name, string link, string createdBy)
        {
            Name = name;
            Link = link;
            CreatedBy = createdBy;
            ClientImages = new HashSet<ClientImage>();

        }
        public string Name { get; set; }
        public string Link { get; set; }
        public ICollection<ClientImage> ClientImages { get; set; }  // Retained the relationship


    }
}
