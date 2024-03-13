using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Models
{
    public class ContactIndexViewModel
    {
        public List<HeadquarterDto> Headquarters { get; set; }
        public PageSeo PageSeos { get; set; }

        public MessageAddDto Message { get; set; }
        public List<SocialDto> Socials { get; set; }
    }
}
