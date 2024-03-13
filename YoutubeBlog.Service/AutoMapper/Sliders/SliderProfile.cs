using AutoMapper;
using YoutubeBlog.Entity.DTOs.Sliders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Sliders
{
    public class SliderProfile : Profile
    {
        public SliderProfile()
        {
            CreateMap<SliderDto, Slider>().ReverseMap();
            CreateMap<SliderUpdateDto, Slider>().ReverseMap();
            CreateMap<SliderUpdateDto, SliderDto>().ReverseMap();
            CreateMap<SliderAddDto, Slider>().ReverseMap();
        }
    }
}
