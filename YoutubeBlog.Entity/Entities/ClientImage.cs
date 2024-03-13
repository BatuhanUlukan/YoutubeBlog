using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class ClientImage : EntityBase
    {
        public ClientImage()
        {

        }

        public ClientImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid ClientId { get; set; }  // Eğer bir resim sadece bir portföye ait olacaksa bu ilişkiyi kullanabiliriz.
        public Client Clients { get; set; }


    }
}