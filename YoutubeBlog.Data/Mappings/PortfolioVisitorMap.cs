using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Mappings
{
    public class PortfolioVisitorMap : IEntityTypeConfiguration<PortfolioVisitor>
    {
        public void Configure(EntityTypeBuilder<PortfolioVisitor> builder)
        {
            builder.HasKey(x => new { x.PortfolioId, x.VisitorId });
        }
    }
}
