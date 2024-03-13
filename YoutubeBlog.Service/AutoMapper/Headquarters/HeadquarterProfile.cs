using AutoMapper;
using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Headquartes
{
    public class HeadquarterProfile : Profile
    {
        public HeadquarterProfile()
        {
            CreateMap<HeadquarterDto, Headquarter>().ReverseMap();
            CreateMap<HeadquarterAddDto, Headquarter>().ReverseMap();
            CreateMap<HeadquarterUpdateDto, Headquarter>().ReverseMap();

        }
    }
}
