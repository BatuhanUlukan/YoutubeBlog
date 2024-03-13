using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Slider : EntityBase
    {
        public Slider()
        {
            SliderImages = new HashSet<SliderImage>();

        }
        public Slider(string name, string content, string subcontent, string createdBy)
        {
            Name = name;
            Content = content;
            SubContent = subcontent;
            CreatedBy = createdBy;
            SliderImages = new HashSet<SliderImage>();

        }

        public string Name { get; set; }
        public string? Content { get; set; }
        public string? SubContent { get; set; }

        public ICollection<SliderImage> SliderImages { get; set; }  // Retained the relationship

    }
}