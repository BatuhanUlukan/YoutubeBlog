using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Entity.DTOs.Comments
{
    public class CommentUpdateDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsConfırm { get; set; }
        public Article Articles { get; set; }
        public AppUser AppUser { get; set; }
        public string Name { get; set; }
        public string SecName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}