using YoutubeBlog.Core.Entities;

namespace YoutubeBlog.Entity.Entities
{
    public class Comment : EntityBase
    {

        public string Text { get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }
        public Guid? UserId { get; set; }
        public AppUser? User { get; set; }
        public bool IsConfırm { get; set; }
        public string Name { get; set; }

        // Default constructor
        public Comment() { }

        // Overloaded constructor
        public Comment(string name, string text, Guid articleId, Guid userId, bool isConfirm)
        {
            Name = name;
            Text = text;
            ArticleId = articleId;
            UserId = userId;
            IsConfırm = isConfirm;
        }


    }
}