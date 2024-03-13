

using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class AttachmentRecord : IEntityBase
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }

}
