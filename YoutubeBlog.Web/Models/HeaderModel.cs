using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.DTOs.Logos;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Models
{
    public class HeaderModel
    {
        public LogoDto Logos { get; set; }
        public AppUser Users { get; set; }
        public UserLoginDto UserLogin { get; set; }
        public string? PasswordError { get; set; }
        public string? EmailError { get; set; }
        public List<SocialDto> Socials { get; set; }
        public List<HeadquarterDto> Headquarters { get; set; }


    }
}
