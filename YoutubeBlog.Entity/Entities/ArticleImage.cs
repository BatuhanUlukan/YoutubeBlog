using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class ArticleImage : EntityBase
    {
        public ArticleImage()
        {

        }

        public ArticleImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }


    }
}
