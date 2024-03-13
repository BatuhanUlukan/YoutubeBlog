using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class LogoMap : IEntityTypeConfiguration<Logo>
    {
        public void Configure(EntityTypeBuilder<Logo> builder)
        {
            Guid logo1Id = Guid.Parse("ABCDE123-1234-5678-90AB-CDEF12345679");
            Guid logo2Id = Guid.Parse("BCDEF234-2345-6789-01BC-DEF234567899");


            builder.HasData(
                new Logo
                {
                    Id = logo1Id,
                    Title = "Header",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Slug = "asp.net-core-deneme-makalesi-1",

                },
                new Article
                {
                    Id = logo2Id,
                    Title = "Footer",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    Slug = "vısual-studıo-deneme-makalesi-1",


                }
            );
        }
    }
}
