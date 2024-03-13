using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Messages
{
    public class MessageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public int sentCount { get; set; }
        public int takedCount { get; set; }
        public bool IsSended { get; set; }
        public bool IsInbox { get; set; }
        public bool IsDeleted { get; set; }
        public string SecName { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public List<EmailAttachmentViewModel> Attachments { get; } = new List<EmailAttachmentViewModel>();
        public List<AttachmentRecord> attachmentRecords { get; } = new List<AttachmentRecord>();

    }
    public class EmailAttachmentViewModel
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
    }

}
