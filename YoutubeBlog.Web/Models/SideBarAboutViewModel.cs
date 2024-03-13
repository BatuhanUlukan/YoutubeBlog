using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.DTOs.Users;

namespace YoutubeBlog.Web.Models
{
    public class SideBarAboutViewModel
    {
        public UserDto User { get; set; }
        public List<SocialDto> Socials { get; set; }
    }
}
