using Microsoft.AspNetCore.Mvc;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Web.ViewComponents
{

    public class ListClientViewComponent : ViewComponent
    {
        private readonly IClientService _clientService;  // Assuming you have a service named ICommentService
        private readonly IWebHostEnvironment _environment;


        public ListClientViewComponent(IClientService clientService, IWebHostEnvironment environment)
        {
            this._clientService = clientService;
            _environment = environment;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var clients = await _clientService.GetAllClientsNonDeleted();
            return View(clients);
        }



    }
}
