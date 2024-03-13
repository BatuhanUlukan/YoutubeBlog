using YoutubeBlog.Entity.DTOs.Portfolios;

namespace YoutubeBlog.Web.Areas.Admin.Models
{
    public class PortfolioPageModel
    {
        public List<PortfolioDto> Portfolios { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
