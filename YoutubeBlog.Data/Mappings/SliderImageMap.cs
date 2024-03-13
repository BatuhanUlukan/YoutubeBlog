using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class SliderImageMap : IEntityTypeConfiguration<SliderImage>
    {
        public void Configure(EntityTypeBuilder<SliderImage> builder)

        {
            Guid slider1Id = Guid.Parse("35A6FF13-92F5-4D82-B69D-77876EDB1D57");
            Guid slider2Id = Guid.Parse("9653E768-1EA1-4F17-B9BF-04EAC0BC88C2");


            builder.HasData(
              new SliderImage
              {
                  Id = Guid.NewGuid(),
                  SliderId = slider1Id,
                  FileName = "images/testimage",
                  FileType = "jpg",
                  CreatedBy = "Admin Test"
              }
,
           new SliderImage
           {
               Id = Guid.NewGuid(),
               SliderId = slider2Id,
               FileName = "images/testimage",
               FileType = "jpg",
               CreatedBy = "Admin Test"
           }
);

        }
    }
}
