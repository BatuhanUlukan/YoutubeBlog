using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class ClientController : Controller
    {
        private readonly IClientService clientService;
        private readonly IMapper mapper;
        private readonly IToastNotification toast;
        private readonly IValidator<Client> clientvalidator;


        public ClientController(IValidator<Client> clientvalidator, IClientService clientService, IMapper mapper, IToastNotification toast)
        {
            this.clientService = clientService;
            this.mapper = mapper;
            this.toast = toast;
            this.clientvalidator = clientvalidator;

        }

        [Route("clients")]
        [HttpGet]
        public async Task<IActionResult> Clients()
        {
            var clients = await clientService.GetAllClientsNonDeleted();
            return View(clients);
        }
        [Route("deleted-clients")]
        [HttpGet]
        public async Task<IActionResult> DeletedClients()
        {
            var clients = await clientService.GetAllDeletedClients();
            return View(clients);
        }


        [Route("add-client")]
        [HttpGet]
        public IActionResult AddClient()
        {
            return View();
        }


        [Route("add-client")]
        [HttpPost]
        public async Task<IActionResult> AddClient(ClientAddDto clientAddDto)
        {
            var map = mapper.Map<Client>(clientAddDto);
            var result = await clientvalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                await clientService.CreateClientAsync(clientAddDto);
                toast.AddSuccessToastMessage(Messages.Client.Add(clientAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Clients", "Client");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }
        [Route("update-client/{name}")]
        [HttpGet]
        public async Task<IActionResult> UpdateClient(string name)
        {
            var client = await clientService.GetClient(name);
            var map = mapper.Map<Client, ClientUpdateDto>(client);

            return View(map);
        }

        [Route("update-client/{name}")]
        [HttpPost]
        public async Task<IActionResult> UpdateClient(ClientUpdateDto clientUpdateDto)
        {
            var map = mapper.Map<Client>(clientUpdateDto);
            var result = await clientvalidator.ValidateAsync(map);

            if (result.IsValid)
            {
                var name = await clientService.UpdateClientAsync(clientUpdateDto);
                toast.AddSuccessToastMessage(Messages.Client.Update(name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Clients", "Client");
            }

            result.AddToModelState(this.ModelState);
            return View();
        }

        [Route("client-delete/{name}")]
        [HttpGet]
        public async Task<IActionResult> DeleteClient(string name)
        {
            var client = await clientService.SafeDeleteClientAsync(name);
            toast.AddSuccessToastMessage(Messages.Client.Delete(client), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Clients", "Client");
        }
        [Route("undo-delete-client/{name}")]
        [HttpGet]
        public async Task<IActionResult> UndoClient(string name)
        {
            var client = await clientService.UndoDeleteClientAsync(name);
            toast.AddSuccessToastMessage(Messages.Client.Delete(client), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Clients", "Client");
        }
        [Route("hardclient-delete/{name}")]
        [HttpGet]
        public async Task<IActionResult> HardDelete(string name)
        {
            var client = await clientService.HardDeleteClientAsync(name);
            toast.AddSuccessToastMessage(Messages.Client.Delete(client), new ToastrOptions() { Title = "İşlem Başarılı" });

            return RedirectToAction("Clients", "Client");
        }

    }
}
