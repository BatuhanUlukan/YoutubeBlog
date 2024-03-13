using AutoMapper;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Duties
{
    public class DutyProfile : Profile
    {
        public DutyProfile()
        {
            CreateMap<DutyDto, Duty>().ReverseMap();
            CreateMap<DutyAddDto, Duty>().ReverseMap();
            CreateMap<DutyUpdateDto, Duty>().ReverseMap();
        }
    }
}
