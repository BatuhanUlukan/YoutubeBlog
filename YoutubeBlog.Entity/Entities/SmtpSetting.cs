using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class SmtpSetting : EntityBase
    {
        public SmtpSetting()
        {
        }

        public SmtpSetting(string smtpName, string serverIP, string incomingServer, string outgoingServer, int smtpPort, int imapPort, string username, string password)
        {
            SmtpName = smtpName;
            ServerIP = serverIP;
            IncomingServer = incomingServer;
            OutgoingServer = outgoingServer;
            SMTPPort = smtpPort;
            IMAPPort = imapPort;
            Username = username;
            Password = password;
        }

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
