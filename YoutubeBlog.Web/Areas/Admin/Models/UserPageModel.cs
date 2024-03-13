using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Users;

namespace YoutubeBlog.Web.Areas.Admin.Models
{
    public class UserPageModel
    {
        public UserDto User { get; set; } // Kullanıcı bilgileri
        public List<MessageDto> Last4Messages { get; set; } // Son 4 mesaj
        public int Last12HoursMessageCount { get; set; }


    }


}