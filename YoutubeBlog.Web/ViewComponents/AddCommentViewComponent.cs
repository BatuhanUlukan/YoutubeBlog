using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Web.Models;

namespace YoutubeBlog.Web.ViewComponents
{
    public class AddCommentViewComponent : ViewComponent
    {
        private readonly IWebHostEnvironment _environment;

        public AddCommentViewComponent(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public IViewComponentResult Invoke(Guid articleId)
        {
            // Yorum eklemek için kullanılan DTO oluşturulur
            var viewModel = new CommentAddDto
            {
                ArticleId = articleId,
            };

            // View Component'a geçirilecek model oluşturulur
            var view = new HomeIndexViewModel
            {
                Comment = viewModel
            };

            // ViewComponent sınıfının "View" metodu ile View döndürülür
            return View(view);
        }
    }
}
