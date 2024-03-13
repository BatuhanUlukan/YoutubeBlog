using AutoMapper;
using YoutubeBlog.Entity.DTOs.Logos;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Headquartes
{
    public class LogoProfile : Profile
    {
        public LogoProfile()
        {
            CreateMap<LogoDto, Logo>().ReverseMap();
            CreateMap<LogoUpdateDto, Logo>().ReverseMap();

        }
    }
}
