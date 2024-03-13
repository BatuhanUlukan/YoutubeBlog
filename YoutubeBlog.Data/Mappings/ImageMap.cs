using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            Guid user1ıd = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C");
            Guid user2ıd = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427");

            builder.HasData(new UserImage
            {
                Id = Guid.Parse("F71F4B9A-AA60-461D-B398-DE31001BF214"),
                UserId = user1ıd,
                FileName = "images/testimage",
                FileType = "jpg",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new UserImage
            {
                Id = Guid.Parse("D16A6EC7-8C50-4AB0-89A5-02B9A551F0FA"),
                UserId = user2ıd,
                FileName = "images/vstest",
                FileType = "png",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            });
        }
    }
}
