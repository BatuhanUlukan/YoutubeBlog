using System.IO;


namespace YoutubeBlog.Entity.DTOs.Messages
{
    public class AttachmentInfo
    {
        public Stream Stream { get; set; }
        public string FileName { get; set; }
    }


}
