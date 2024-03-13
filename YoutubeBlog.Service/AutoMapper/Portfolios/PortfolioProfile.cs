using AutoMapper;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Portfolios
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<PortfolioDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioUpdateDto, Portfolio>().ReverseMap();
            CreateMap<PortfolioUpdateDto, PortfolioDto>().ReverseMap();
            CreateMap<PortfolioAddDto, Portfolio>().ReverseMap();
        }
    }
}
