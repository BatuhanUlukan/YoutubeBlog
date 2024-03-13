using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class PortfolioImageMap : IEntityTypeConfiguration<PortfolioImage>
    {
        public void Configure(EntityTypeBuilder<PortfolioImage> builder)

        {
            Guid portfolio1Id = Guid.Parse("ABCDE123-1234-5678-90AB-CDEF12345678");
            Guid portfolio2Id = Guid.Parse("BCDEF234-2345-6789-01BC-DEF234567890");


            builder.HasData(
                new PortfolioImage
                {
                    Id = Guid.NewGuid(),
                    PortfolioId = portfolio1Id,
                    FileName = "images/testimage",
                    FileType = "jpg",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false
                },
              new PortfolioImage
              {
                  Id = Guid.NewGuid(),
                  PortfolioId = portfolio2Id,
                  FileName = "images/vstest",
                  FileType = "png",
                  CreatedBy = "Admin Test",
                  CreatedDate = DateTime.Now,
                  IsDeleted = false
              });

        }
    }
}
