using AutoMapper;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<CategoryAddDto, Category>().ReverseMap();
            CreateMap<CategoryUpdateDto, Category>().ReverseMap();
        }
    }
}
