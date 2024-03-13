using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Comments;

namespace YoutubeBlog.Web.Models
{
    public class HomeIndexViewModel
    {
        public ArticleDto Article { get; set; }
        public CommentAddDto Comment { get; set; }
        public Guid ArticleId { get; set; }


    }
}
