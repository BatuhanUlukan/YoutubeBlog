using YoutubeBlog.Entity.DTOs.Articles;

namespace YoutubeBlog.Web.Models
{
    public class AdjacentArticleViewModel
    {
        public ArticleDto PreviousArticle { get; set; }
        public ArticleDto NextArticle { get; set; }
    }

}
