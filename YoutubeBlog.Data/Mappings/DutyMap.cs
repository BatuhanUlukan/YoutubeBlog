using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class DutyMap : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasData(new Duty
            {
                Id = Guid.Parse("4C569A9A-5F41-478F-9D17-69AC5B02AE0B"),
                Name = "KARMOD",
                Content = "....",
                Icon = "eye",
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                IsMaın = true

            },
            new Duty
            {
                Id = Guid.Parse("D23E4F79-9600-4B5E-B3E9-756CDCACD2B1"),
                Name = "DIA",
                Content = "....",
                Icon = "screen",
                UserId = Guid.Parse("CB94223B-CCB8-4F2F-93D7-0DF96A7F065C"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                IsMaın = false
            });

        }
    }
}
