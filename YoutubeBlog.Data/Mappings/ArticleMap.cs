using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            Guid article1Id = Guid.Parse("ABCDE123-1234-5678-90AB-CDEF12345678");
            Guid article2Id = Guid.Parse("BCDEF234-2345-6789-01BC-DEF234567890");


            builder.HasData(
                new Article
                {
                    Id = article1Id,
                    Title = "Asp.net Core Deneme Makalesi 1",
                    Content = "...", // truncated for brevity
                    ViewCount = 15,
                    CategoryId = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                    Slug = "asp.net-core-deneme-makalesi-1",

                },
                new Article
                {
                    Id = article2Id,
                    Title = "Visual Studio Deneme Makalesi 1",
                    Content = "...", // truncated for brevity
                    ViewCount = 15,
                    CategoryId = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                    UserId = Guid.Parse("3AA42229-1C0F-4630-8C1A-DB879ECD0427"),
                    Slug = "vısual-studıo-deneme-makalesi-1",


                }
            );
        }
    }
}
