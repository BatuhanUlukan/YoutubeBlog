using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Clients;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.DTOs.Sliders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Models
{
    public class BasePageViewModel
    {
        public List<ClientDto> Clients { get; set; }
        public PageSeo PageSeos { get; set; }
        public List<AboutDto> Abouts { get; set; }
        public List<FactDto> Facts { get; set; }
        public List<SliderDto> Sliders { get; set; }
        public List<DutyDto> Services { get; set; }
        public List<ArticleDto> Articles { get; set; }
        public List<PortfolioDto> Portfolios { get; set; }


    }
}
