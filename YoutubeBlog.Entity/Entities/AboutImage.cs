using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class AboutImage : EntityBase
    {
        // Default constructor
        public AboutImage()
        {

        }

        // Parameterized constructor
        public AboutImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        // Properties
        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid AboutId { get; set; }  // This property suggests a relationship with an About entity through its ID
        public About About { get; set; }    // Navigation property representing the relationship with the About entity

    }
}
