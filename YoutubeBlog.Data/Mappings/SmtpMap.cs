using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YoutubeBlog.Entity.Entities;

namespace YourNamespace
{
    public class SmtpMap : IEntityTypeConfiguration<SmtpSetting>
    {
        public void Configure(EntityTypeBuilder<SmtpSetting> builder)
        {
            // Table name
            builder.HasData(new SmtpSetting
            {
                Id = Guid.NewGuid(),
                SmtpName = "SMTP",
                ServerIP = "",
                IncomingServer = "",
                OutgoingServer = "",
                SMTPPort = 465,
                IMAPPort = 993,
                Username = "",
                Password = "",
            });
        }
    }
}
