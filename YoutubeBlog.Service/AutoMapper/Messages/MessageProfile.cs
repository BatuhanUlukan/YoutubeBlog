using AutoMapper;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Messages
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {

            CreateMap<MessageDto, Message>().ReverseMap();
            CreateMap<MessageAddDto, Message>().ReverseMap();
        }
    }
}


