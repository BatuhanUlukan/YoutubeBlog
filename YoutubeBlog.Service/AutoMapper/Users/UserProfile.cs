using AutoMapper;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, AppUser>().ReverseMap();
            CreateMap<UserAddDto, AppUser>().ReverseMap();
            CreateMap<UserUpdateDto, AppUser>().ReverseMap();
        }
    }
}
