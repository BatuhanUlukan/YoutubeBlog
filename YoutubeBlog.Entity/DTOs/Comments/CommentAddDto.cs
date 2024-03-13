using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.DTOs.Comments
{
    public class CommentAddDto  : EntityBase
    {
        public string Text { get; set; }
        public string Name { get; set; }
        public bool IsConfırm { get; set; }
        public Guid ArticleId { get; set; }
        public Guid UserId { get; set; }
    }
}
