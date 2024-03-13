using AutoMapper;
using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.DTOs.SmtpSettings;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.AutoMapper.Abouts
{
    public class SmtpProfile : Profile
    {
        public SmtpProfile()
        {
            CreateMap<SmtpSettingsDto, SmtpSetting>().ReverseMap();
            CreateMap<SmtpSettingsUpdateDto, SmtpSetting>().ReverseMap();
            CreateMap<SmtpSetting, SmtpSettingsDto>().ReverseMap();


        }
    }
}
