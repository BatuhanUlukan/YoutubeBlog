using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Models
{
    public class CommentListViewModel
    {
        public List<Comment> Comments { get; set; }
        //public AppUser AppUser { get; set; }
        public int CommentCount { get; set; }
    }
}
