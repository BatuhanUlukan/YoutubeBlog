using System.Xml.Linq;
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class About : EntityBase
    {
        // Default constructor
        public About()
        {
            AboutImages = new HashSet<AboutImage>();
        }

        // Parameterized constructor
        public About(string name, string name2, string content, string subcontent, string createdBy)
        {
            Name = name;
            Name2 = name2;
            Content = content;
            SubContent = subcontent;
            CreatedBy = createdBy;
            AboutImages = new HashSet<AboutImage>();
        }

        // Properties
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string? Content { get; set; }
        public string? SubContent { get; set; }

        // Collection of AboutImage entities
        public ICollection<AboutImage> AboutImages { get; set; }
    }
}
