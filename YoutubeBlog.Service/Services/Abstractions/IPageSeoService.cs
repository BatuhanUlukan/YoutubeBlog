using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.DTOs.Pages;
using YoutubeBlog.Entity.Entities;


namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IPageSeoService
    {
        Task<PageSeo> GetSeoPage(string pageName);
        Task<List<PageSeoDto>> GetAllSeoPage();
        Task<string> UpdatePageSeoAsync(PageSeoUpdateDto pageSeoUpdateDto);

    }
}
