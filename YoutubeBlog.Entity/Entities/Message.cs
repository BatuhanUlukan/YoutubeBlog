using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Message : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsSended { get; set; }
        public bool IsInbox { get; set; }
        public string SecName { get; set; }

        // Change to a collection of AttachmentRecord
        public List<AttachmentRecord> AttachmentRecords { get; set; }

        public Message()
        {
            // Initialize the collection in the constructor
            AttachmentRecords = new List<AttachmentRecord>();
        }

        public Message(string name, string email, string subject, string content, bool isSended, bool isInbox, string secName)
            : this()
        {
            Name = name;
            Email = email;
            Subject = subject;
            Content = content;
            IsSended = isSended;
            IsInbox = isInbox;
            SecName = secName;
        }
    }

}
