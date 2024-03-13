using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Web.Models
{
    public class SideBarViewModel
    {
        public List<CategoryDto> Categories { get; set; }
        public List<PortfolioDto> Portfolios { get; set; }
        public List<Comment> Comments { get; set; }

    }
}
