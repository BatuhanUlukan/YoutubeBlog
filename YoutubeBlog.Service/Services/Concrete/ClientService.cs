using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Xml.Linq;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.imageHelper = imageHelper;
        }

        public async Task<Client> GetClient(string name)
        {
            var client = await unitOfWork.GetRepository<Client>().GetAsync(x => x.Name == name, x => x.ClientImages);
            return client;
        }
        public async Task CreateClientAsync(ClientAddDto clientAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var client = new Client(clientAddDto.Name, clientAddDto.Link, userEmail);


            foreach (var photo in clientAddDto.Photos)
            {
                var imageUpload = await imageHelper.Upload(clientAddDto.Name, photo, ImageType.Client);
                ClientImage image = new(imageUpload.FullName, photo.ContentType, userEmail);
                await unitOfWork.GetRepository<ClientImage>().AddAsync(image);
                client.ClientImages.Add(image);
            }

            await unitOfWork.GetRepository<Client>().AddAsync(client);
            await unitOfWork.SaveAsync();
        }
        public async Task<List<ClientDto>> GetAllClientsNonDeleted()
        {

            var clients = await unitOfWork.GetRepository<Client>().GetAllAsync(x => !x.IsDeleted, x => x.ClientImages);
            var map = mapper.Map<List<ClientDto>>(clients);

            return map;
        }
        public async Task<List<ClientDto>> GetAllDeletedClients()
        {

            var clients = await unitOfWork.GetRepository<Client>().GetAllAsync(x => x.IsDeleted, x => x.ClientImages);
            var map = mapper.Map<List<ClientDto>>(clients);

            return map;
        }

        public async Task<string> UpdateClientAsync(ClientUpdateDto clientUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            // Check if the client with the specified Id exists
            var client = await unitOfWork.GetRepository<Client>().GetAsync(x => !x.IsDeleted && x.Name == clientUpdateDto.Name, x => x.ClientImages);


            var oldImages = client.ClientImages.ToList();

            client.ModifiedDate = DateTime.Now;
            client.ModifiedBy = userEmail;

            if (clientUpdateDto.Photos != null && clientUpdateDto.Photos.Any())
            {
                // Remove and delete old images
                foreach (var oldImage in oldImages)
                {
                    imageHelper.Delete(oldImage.FileName);
                    client.ClientImages.Remove(oldImage);
                    await unitOfWork.GetRepository<ClientImage>().DeleteAsync(oldImage);
                }

                // Upload new images
                foreach (var photo in clientUpdateDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(clientUpdateDto.Name, photo, ImageType.Client);
                    ClientImage image = new(imageUpload.FullName, photo.ContentType, userEmail)
                    {
                        ClientId = client.Id
                    };
                    await unitOfWork.GetRepository<ClientImage>().AddAsync(image);
                    client.ClientImages.Add(image);
                }
            }

            await unitOfWork.GetRepository<Client>().UpdateAsync(client);
            await unitOfWork.SaveAsync();

            return client.Name;
        }

        public async Task<string> SafeDeleteClientAsync(string name)
        {
            var userEmail = _user.GetLoggedInEmail();
            var client = await unitOfWork.GetRepository<Client>().GetAsync(x => x.Name == name);

            client.IsDeleted = true;
            client.DeletedDate = DateTime.Now;
            client.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Client>().UpdateAsync(client);
            await unitOfWork.SaveAsync();

            return client.Name;
        }
        public async Task<string> HardDeleteClientAsync(string name)
        {
            // Article nesnesini veritabanından getir
            var client = await unitOfWork.GetRepository<Client>().GetAsync(x => x.Name == name, x => x.ClientImages);

            // İlişkili tüm resimleri sil
            foreach (var image in client.ClientImages)
            {
                imageHelper.Delete(image.FileName);  // Fiziksel resim dosyasını sil
                await unitOfWork.GetRepository<ClientImage>().DeleteAsync(image);  // Resmi veritabanından sil
            }

            // Article nesnesini veritabanından sil
            await unitOfWork.GetRepository<Client>().DeleteAsync(client);
            await unitOfWork.SaveAsync();

            return client.Name;
        }

        public async Task<string> UndoDeleteClientAsync(string name)
        {
            var client = await unitOfWork.GetRepository<Client>().GetAsync(x => x.Name == name);

            client.IsDeleted = false;
            client.DeletedDate = null;
            client.DeletedBy = null;

            await unitOfWork.GetRepository<Client>().UpdateAsync(client);
            await unitOfWork.SaveAsync();

            return client.Name;
        }

    }
}
















