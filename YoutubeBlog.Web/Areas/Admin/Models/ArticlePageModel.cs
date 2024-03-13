using YoutubeBlog.Entity.DTOs.Articles;

public class ArticlePageModel
{
    public List<ArticleDto> Articles { get; set; }
    public ArticleListDto ArticleListDto { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
}
