using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Slug;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task CreateCommentAsync(CommentAddDto commentAddDto)
        {
            // Get the logged-in user's email or set it to "guest" if not available
            var userEmail = _user.GetLoggedInEmail() ?? "guest@gmail.com";

            // Retrieve user information based on the email
            var userInfo = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Email == userEmail);

            // Create a new comment
            Comment comment = new Comment
            {
                Name = string.IsNullOrWhiteSpace(commentAddDto.Name)
             ? commentAddDto.Name
             : userInfo != null
                 ? $"{userInfo.FirstName} {userInfo.LastName}"
                 : "Unknown User",
                Text = commentAddDto.Text,
                ArticleId = commentAddDto.ArticleId,
                CreatedBy = userEmail,
                IsConfırm = false,   
                SecName = commentAddDto.SecName,
            };


            // Add the comment to the repository
            await unitOfWork.GetRepository<Comment>().AddAsync(comment);

            // Save changes asynchronously
            await unitOfWork.SaveAsync();
        }




        public async Task<Comment> GetCommentByGuid(string secName)
        {
            var user = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.SecName == secName, u => u.Article);
            var map = mapper.Map<Comment>(user);

            return map;
        }


        public async Task<string> UpdateCommentAsync(CommentUpdateDto commentUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.Id == commentUpdateDto.Id);

            comment.Text = commentUpdateDto.Text;
            comment.ModifiedBy = userEmail;
            comment.ModifiedDate = DateTime.Now;
            comment.SecName = UniqStr.GuidToRandomName(Guid.NewGuid().ToString(), 6, 8);


            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Name;
        }

        public async Task<List<CommentDto>> GetAllCommentsForArticle(Guid articleId)
        {
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(
                x => !x.IsDeleted && x.ArticleId == articleId,
                x => x.User // Include the User navigation property
            );
            return mapper.Map<List<CommentDto>>(comments);
        }

        public async Task<List<Comment>> GetAllCommentsForUser(Guid articleId)
        {
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(
                x => !x.IsDeleted && x.ArticleId == articleId,
                x => x.User, x => x.User.UserImagess // Include the User navigation property
            );
            return mapper.Map<List<Comment>>(comments);
        }

        public async Task<List<CommentDto>> GetAllComments()
        {
            var comments = await unitOfWork.GetRepository<Comment>()
                .GetAllAsync(x => !x.IsDeleted, x => x.Article); // Eager loading ile Article'ı çek
            var commentDtos = mapper.Map<List<CommentDto>>(comments);
            return commentDtos; // Return the mapped list of CommentDto

        }

        public async Task DeleteCommentAsync(string secName)
        {
            var userEmail = _user.GetLoggedInEmail();
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.SecName == secName);

            comment.IsDeleted = true;
            comment.DeletedDate = DateTime.Now;
            comment.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();
        }


        public async Task UndoDeleteCommentAsync(string secName)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => x.IsDeleted && x.SecName == secName);

            comment.IsDeleted = false;
            comment.DeletedDate = null;
            comment.DeletedBy = null;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();
        }
        public async Task<int> GetCommentCountForArticle(Guid articleId)
        {
            var comments = await unitOfWork.GetRepository<Comment>().GetAllAsync(x => !x.IsDeleted && x.ArticleId == articleId && x.IsConfırm == true);
            return comments.Count();
        }

        public async Task<string> ApproveComment(string secName)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.SecName == secName);
            comment.IsConfırm = true;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Name;
        }
        public async Task<string> RejectComment(string secName)
        {
            var comment = await unitOfWork.GetRepository<Comment>().GetAsync(x => !x.IsDeleted && x.SecName == secName);
            comment.IsConfırm = false;

            await unitOfWork.GetRepository<Comment>().UpdateAsync(comment);
            await unitOfWork.SaveAsync();

            return comment.Name;
        }
        public async Task<List<Comment>> GetRandomComments(int count)
        {
            var allComments = await unitOfWork.GetRepository<Comment>()
                .GetAllAsync(x => !x.IsDeleted && x.IsActive && x.IsConfırm, x => x.Article, x => x.User.UserImagess, x => x.User);

            var randomComments = allComments.OrderBy(comment => Guid.NewGuid()).Take(count).ToList();

            var commentDtos = mapper.Map<List<Comment>>(randomComments);
            return commentDtos;
        }



    }
}
