using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ArticleImageMap : IEntityTypeConfiguration<ArticleImage>
    {
        public void Configure(EntityTypeBuilder<ArticleImage> builder)

        {
            Guid article1Id = Guid.Parse("ABCDE123-1234-5678-90AB-CDEF12345678");
            Guid article2Id = Guid.Parse("BCDEF234-2345-6789-01BC-DEF234567890");


            builder.HasData(
              new ArticleImage
              {
                  Id = Guid.NewGuid(),
                  ArticleId = article1Id,
                  FileName = "images/testimage",
                  FileType = "jpg",
                  CreatedBy = "Admin Test"
              }
,
           new ArticleImage
           {
               Id = Guid.NewGuid(),
               ArticleId = article2Id,
               FileName = "images/testimage",
               FileType = "jpg",
               CreatedBy = "Admin Test"
           }
);

        }
    }
}
