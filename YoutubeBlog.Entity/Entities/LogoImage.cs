
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class LogoImage : EntityBase
    {
        public LogoImage()
        {

        }

        public LogoImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid LogoId { get; set; }  // Eğer bir resim sadece bir portföye ait olacaksa bu ilişkiyi kullanabiliriz.
        public Logo Logo { get; set; }



    }
}
