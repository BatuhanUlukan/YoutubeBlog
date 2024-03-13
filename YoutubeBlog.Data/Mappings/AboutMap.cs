using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class AboutMap : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            Guid about1Id = Guid.Parse("3E008E90-80F5-48E6-BC1B-F5A49F20694A");


            builder.HasData(
                new About
                {
                    Id = about1Id,
                    Name = "about",
                    Name2 = "Header",
                    Content = "Header",
                    SubContent = "Header",
                    CreatedBy = "Admin Test",
                    CreatedDate = DateTime.Now,
                    IsDeleted = false,
                }

            );
        }
    }
}
