using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;
using YoutubeBlog.Web.Models;
using static YoutubeBlog.Web.ResultMessages.Messages;

namespace YoutubeBlog.Web.ViewComponents
{

    public class ListCommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;  // Assuming you have a service named ICommentService
        private readonly IWebHostEnvironment _environment;

        public ListCommentViewComponent(ICommentService commentService, IWebHostEnvironment environment)
        {
            _commentService = commentService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid articleId)
        {
            //var comments = await _commentService.GetAllCommentsForArticle(articleId);
            var commentCount = await _commentService.GetCommentCountForArticle(articleId);
            var comments = await _commentService.GetAllCommentsForUser(articleId);


            var viewModel = new CommentListViewModel
            {
                Comments = comments,
                CommentCount = commentCount,

            };


            return View(viewModel);  // Pass the ViewModel to the view
        }



    }
}
