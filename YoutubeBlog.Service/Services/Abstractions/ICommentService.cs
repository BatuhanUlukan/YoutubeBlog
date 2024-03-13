using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface ICommentService
    {
        Task CreateCommentAsync(CommentAddDto commentAddDto);
        Task<Comment> GetCommentByGuid(string secName);
        Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto);
        Task<List<Comment>> GetAllCommentsForUser(Guid articleId);
        Task<List<CommentDto>> GetAllCommentsForArticle(Guid articleId);

        Task DeleteCommentAsync(string secName);
        Task UndoDeleteCommentAsync(string secName);
        Task<int> GetCommentCountForArticle(Guid articleId);
        Task<List<CommentDto>> GetAllComments();
        Task<string> ApproveComment(string secName);
        Task<string> RejectComment(string secName);
        Task<List<Comment>> GetRandomComments(int count);





    }
}
