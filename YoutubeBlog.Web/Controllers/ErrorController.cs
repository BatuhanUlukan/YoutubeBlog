using Microsoft.AspNetCore.Mvc;

namespace YoutubeBlog.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    // 404 sayfa tasarımınızı içeren view'i göster
                    return View("404");
                case 500:
                    // 500 sayfa tasarımınızı içeren view'i göster
                    return View("500");
                case 408:
                    // 408 sayfa tasarımınızı içeren view'i göster
                    return View("408");
                // Diğer durumlar için gerekirse case'leri ekleyebilirsiniz.
                default:
                    return View("Error");
            }
        }
    }

}
