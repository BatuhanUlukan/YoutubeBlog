using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ClientMap : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(new Client
            {
                Id = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                Name = "KARMOD",
                Link = "KARMOD",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Client
            {
                Id = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                Name = "DIA",
                Link = "DIA",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });

        }
    }
}
