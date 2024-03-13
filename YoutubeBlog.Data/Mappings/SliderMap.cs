using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class SliderMap : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.HasData(new Slider
            {
                Id = Guid.Parse("35A6FF13-92F5-4D82-B69D-77876EDB1D57"),
                Name = "KARMOD",
                Content = "DIA",
                SubContent = "DIA",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Slider
            {
                Id = Guid.Parse("9653E768-1EA1-4F17-B9BF-04EAC0BC88C2"),
                Name = "DIA",
                Content = "DIA",
                SubContent = "DIA",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });

        }
    }
}
