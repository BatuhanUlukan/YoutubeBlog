using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class AboutImageMap : IEntityTypeConfiguration<AboutImage>
    {
        public void Configure(EntityTypeBuilder<AboutImage> builder)

        {
            Guid about1Id = Guid.Parse("3E008E90-80F5-48E6-BC1B-F5A49F20694A");


            builder.HasData(
              new AboutImage
              {
                  Id = Guid.NewGuid(),
                  AboutId = about1Id,
                  FileName = "images/testimage",
                  FileType = "jpg",
                  CreatedBy = "Admin Test"
              });

        }
    }
}
