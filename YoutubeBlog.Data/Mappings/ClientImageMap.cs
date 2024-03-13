using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ClientImageMap : IEntityTypeConfiguration<ClientImage>
    {
        public void Configure(EntityTypeBuilder<ClientImage> builder)

        {
            Guid client1Id = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B");
            Guid client2Id = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1");


            builder.HasData(
              new ClientImage
              {
                  Id = Guid.NewGuid(),
                  ClientId = client1Id,
                  FileName = "images/testimage",
                  FileType = "jpg",
                  CreatedBy = "Admin Test"
              }
,
           new ClientImage
           {
               Id = Guid.NewGuid(),
               ClientId = client2Id,
               FileName = "images/testimage",
               FileType = "jpg",
               CreatedBy = "Admin Test"
           }
);

        }
    }
}
