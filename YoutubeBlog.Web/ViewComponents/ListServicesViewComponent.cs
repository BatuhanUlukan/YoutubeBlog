using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Web.ViewComponents
{

    public class ListServicesViewComponent : ViewComponent
    {
        private readonly IUserService _dutyService;
        private readonly IWebHostEnvironment _environment;

        public ListServicesViewComponent(IUserService dutyService, IWebHostEnvironment environment)
        {
            this._dutyService = dutyService;
            this._environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var duties = await _dutyService.GetAllServicesForMain();
            return View(duties);
        }



    }
}
