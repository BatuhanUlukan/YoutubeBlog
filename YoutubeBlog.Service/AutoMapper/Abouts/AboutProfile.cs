using AutoMapper;
using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Abouts
{
    public class AboutProfile : Profile
    {
        public AboutProfile()
        {
            CreateMap<AboutDto, About>().ReverseMap();
            CreateMap<AboutUpdateDto, About>().ReverseMap();
            CreateMap<About, AboutDto>().ReverseMap();


        }
    }
}
