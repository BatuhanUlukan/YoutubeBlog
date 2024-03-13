using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class HeadquarterMap : IEntityTypeConfiguration<Headquarter>
    {
        public void Configure(EntityTypeBuilder<Headquarter> builder)
        {
            builder.HasData(new Headquarter
            {
                Id = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                Name = "ASP.NET Core",
                Address = "SAMSUN",
                AddressLink = "SAMSUN",
                PhoneNumber = "+905976543210",
                Email = "batuhanulukan@mail.com",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Choosen = true,
                Location = "41.087770, 29.089148"


            },
            new Headquarter
            {
                Id = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                Name = "Visual Studio 2022",
                Address = "İSTANBUL",
                AddressLink = "İSTANBUL",
                PhoneNumber = "+905976543210",
                Email = "batuhanulukan@mail.com",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                Choosen = false,
                Location = "41.112996, 29.021128"

            });

        }
    }
}
