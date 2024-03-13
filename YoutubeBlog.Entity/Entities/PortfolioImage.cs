
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class PortfolioImage : EntityBase
    {
        public PortfolioImage()
        {

        }

        public PortfolioImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid PortfolioId { get; set; }  // Eğer bir resim sadece bir portföye ait olacaksa bu ilişkiyi kullanabiliriz.
        public Portfolio Portfolio { get; set; }



    }
}
