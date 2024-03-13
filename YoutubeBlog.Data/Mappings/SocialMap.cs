using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class SocialMap : IEntityTypeConfiguration<Social>
    {
        public void Configure(EntityTypeBuilder<Social> builder)
        {
            builder.HasData(new Social
            {
                Id = Guid.NewGuid(),
                Name = "Facebook",
                Icon = "facebook",
                Link = "https://www.facebook.com",
                IsMaın = false,
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
            },
            new Social
            {
                Id = Guid.NewGuid(),
                Name = "Instagram",
                Icon = "instagram",
                Link = "https://www.instagram.com",
                CreatedBy = "Admin Test",
                IsMaın = true,
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
            });
        }
    }
}
