

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class FactMap : IEntityTypeConfiguration<Fact>
    {
        public void Configure(EntityTypeBuilder<Fact> builder)
        {
            builder.HasData(new Fact
            {
                Id = Guid.Parse("FE50FEFB-8EDB-4B5F-9E70-DCD4AEC46A70"),
                Name = "Completed Projects",
                Value = "125",
                Icon = "leaf",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false
            },
            new Fact
            {
                Id = Guid.Parse("DB3F7D1D-EC14-4D06-AEA8-2A69FFE9BA6C"),
                Name = "Satisfied Customers",
                Value = "150",
                Icon = "users",
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                IsDeleted = false

            });

        }
    }
}
