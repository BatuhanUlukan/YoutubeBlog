using AutoMapper;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Pages;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Messages
{
    public class PageSeoProfile : Profile
    {
        public PageSeoProfile()
        {

            CreateMap<PageSeoDto, PageSeo>().ReverseMap();
            CreateMap<PageSeoUpdateDto, PageSeo>().ReverseMap();
        }
    }
}


