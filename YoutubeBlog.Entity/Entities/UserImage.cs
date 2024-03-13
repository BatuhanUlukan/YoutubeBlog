using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class UserImage : EntityBase
    {
        public UserImage()
        {

        }

        public UserImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid UserId { get; set; }
        public AppUser User { get; set; }


    }
}
