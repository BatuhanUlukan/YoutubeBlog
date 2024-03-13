using Microsoft.AspNetCore.Mvc;

namespace YoutubeBlog.Web.ViewComponents
{

    public class JSViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // ViewComponent'in görselleştirileceği görünümü döndürün
            return View();
        }
    }

}
