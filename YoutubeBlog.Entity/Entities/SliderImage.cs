
using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class SliderImage : EntityBase
    {
        public SliderImage()
        {

        }

        public SliderImage(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public string FileName { get; set; }
        public string FileType { get; set; }
        public Guid SliderId { get; set; }
        public Slider Slider { get; set; }



    }
}
