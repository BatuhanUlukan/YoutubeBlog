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
                ServerIP = "77.245.159.27",
                IncomingServer = "mail.batuhanulukan.com.tr",
                OutgoingServer = "mail.batuhanulukan.com.tr",
                SMTPPort = 465,
                IMAPPort = 993,
                Username = "info@batuhanulukan.com.tr",
                Password = "B5x8d2u~9",
            });
        }
    }
}
