using AutoMapper;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Socials
{
    public class SocialProfile : Profile
    {
        public SocialProfile()
        {
            CreateMap<SocialDto, Social>().ReverseMap();
            CreateMap<SocialAddDto, Social>().ReverseMap();
            CreateMap<SocialUpdateDto, Social>().ReverseMap();
        }
    }
}
