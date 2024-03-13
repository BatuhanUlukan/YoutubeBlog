using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Enums;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync();
        Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync();
        Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(string? articleSlug, string? articleTitle, Guid? articleId);
        Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(string articleSlug);
        Task<string> UndoDeleteArticleAsync(string articleSlug);
        Task<ArticleListDto> GetAllByPagingAsync(string? categoryName, int currentPage = 1, int pageSize = 12, bool isAscending = false);
        Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 12,
            bool isAscending = false);
        Task<List<ArticleDto>> GetRandomArticlesInCategoryAsync(Guid categoryId, int count);
        Task<List<ArticleDto>> GetRandomArticlesAsync(int count);
        Task<UserDto> GetAuthorInfoAsync(Guid articleId);
        Task<ArticleDto> GetAdjacentArticleAsync(string slug, ArticleDirection direction);
        Task<string> HardDeleteArticleAsync(string articleSlug);
        Task<List<ArticleDto>> GetArticlesForUser();
        Task<string> ApproveArticle(string articleSlug);
        Task<string> RejectArticle(string articleSlug);



    }
}
