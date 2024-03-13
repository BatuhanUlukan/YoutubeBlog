using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class PageSeoMap : IEntityTypeConfiguration<PageSeo>
    {
        public void Configure(EntityTypeBuilder<PageSeo> builder)
        {
            builder.HasData(new PageSeo
            {
                Id = Guid.Parse("9C8CEA58-68DB-4AA7-A54E-913AB047622C"),
                Title = "Contact",
                Description = "Contact",
                Keywords = "Contact",
                Page = "Contact",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new PageSeo
            {
                Id = Guid.Parse("0ECC0342-25CF-4F53-B64C-788EB22D832A"),
                Title = "Home",
                Description = "Home",
                Keywords = "Home",
                Page = "Home",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            }
            ,
            new PageSeo
            {
                Id = Guid.Parse("DD40A305-995B-48CA-A7F8-133910FB72CB"),
                Title = "Portfolio",
                Description = "Portfolio",
                Keywords = "Portfolio",
                Page = "Portfolio",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new PageSeo
            {
                Id = Guid.Parse("A501A204-6F7B-45A4-8FB8-969CD86E8791"),
                Title = "Base",
                Description = "Base",
                Keywords = "Base",
                Page = "Base",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}