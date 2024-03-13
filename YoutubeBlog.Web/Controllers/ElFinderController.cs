using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Web.WebHelper;

namespace YoutubeBlog.Web.Controllers
{
    public class ElFinderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult FileManager()
        {
            return View();
        }

        public async Task<IActionResult> Connector()
        {
            var connector = ElFinderHelper.GetConnector(Request);
            return await connector.ProcessAsync(Request);
        }

        public async Task<IActionResult> Thumbs(string hash)
        {
            var connector = ElFinderHelper.GetConnector(Request);
            return await connector.GetThumbnailAsync(HttpContext.Request, HttpContext.Response, hash);
        }
    }
}
