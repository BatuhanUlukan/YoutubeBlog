using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class LogoImageMap : IEntityTypeConfiguration<LogoImage>
    {
        public void Configure(EntityTypeBuilder<LogoImage> builder)

        {
            Guid logo1Id = Guid.Parse("ABCDE123-1234-5678-90AB-CDEF12345679");
            Guid logo2Id = Guid.Parse("BCDEF234-2345-6789-01BC-DEF234567899");


            builder.HasData(
              new LogoImage
              {
                  Id = Guid.NewGuid(),
                  LogoId = logo1Id,
                  FileName = "images/testimage",
                  FileType = "jpg",
                  CreatedBy = "Admin Test"
              }
,
           new LogoImage
           {
               Id = Guid.NewGuid(),
               LogoId = logo2Id,
               FileName = "images/testimage",
               FileType = "jpg",
               CreatedBy = "Admin Test"
           }
);

        }
    }
}
