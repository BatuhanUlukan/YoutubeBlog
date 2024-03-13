using AutoMapper;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Facts
{
    public class FactProfile : Profile
    {
        public FactProfile()
        {
            CreateMap<FactDto, Fact>().ReverseMap();
            CreateMap<FactUpdateDto, Fact>().ReverseMap();
            CreateMap<FactUpdateDto, FactDto>().ReverseMap();
            CreateMap<FactAddDto, Fact>().ReverseMap();
        }
    }
}
