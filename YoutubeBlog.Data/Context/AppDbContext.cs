using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<PageSeo> PageSeos { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Headquarter> Headquarters { get; set; }
        public DbSet<AttachmentRecord> AttachmentRecords { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<PortfolioImage> PortfolioImages { get; set; }
        public DbSet<SliderImage> SliderImages { get; set; }
        public DbSet<AboutImage> AboutImages { get; set; }
        public DbSet<LogoImage> LogoImages { get; set; }
        public DbSet<ClientImage> ClientImages { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors { get; set; }
        public DbSet<PortfolioVisitor> PortfolioVisitors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
