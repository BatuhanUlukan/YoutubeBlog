using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.DTOs.Messages
{
    public class MessageAddDto : EntityBase
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }


}

