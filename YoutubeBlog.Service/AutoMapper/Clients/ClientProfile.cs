using AutoMapper;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Categories
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>().ReverseMap();
            CreateMap<ClientUpdateDto, Client>().ReverseMap();
            CreateMap<ClientAddDto, Client>().ReverseMap();
        }



    }

}
