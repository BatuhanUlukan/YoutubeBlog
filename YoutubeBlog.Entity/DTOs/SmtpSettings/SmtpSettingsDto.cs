namespace YoutubeBlog.Entity.DTOs.SmtpSettings
{
    public class SmtpSettingsDto
    {
        public Guid Id { get; set; }
        public string SmtpName { get; set; }
        public string ServerIP { get; set; }
        public string IncomingServer { get; set; }
        public string OutgoingServer { get; set; }
        public int SMTPPort { get; set; }
        public int IMAPPort { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }


}
