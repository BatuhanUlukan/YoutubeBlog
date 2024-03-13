using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IClientService
    {
        Task<List<ClientDto>> GetAllClientsNonDeleted();
        Task CreateClientAsync(ClientAddDto clientAddDto);
        Task<string> SafeDeleteClientAsync(string name);
        Task<string> HardDeleteClientAsync(string name);
        Task<string> UpdateClientAsync(ClientUpdateDto clientUpdateDto);
        Task<string> UndoDeleteClientAsync(string name);
        Task<Client> GetClient(string name);
        Task<List<ClientDto>> GetAllDeletedClients();

    }
}