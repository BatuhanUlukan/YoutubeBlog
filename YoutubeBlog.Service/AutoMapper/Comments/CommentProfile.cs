using AutoMapper;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Comments
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentAddDto>().ReverseMap(); ;
            CreateMap<Comment, CommentUpdateDto>().ReverseMap();
            CreateMap<Comment, CommentDto>()
              .ForMember(dest => dest.Articles, opt => opt.MapFrom(src => src.Article)); // Assuming you have an ArticleDto class

        }
    }

}
