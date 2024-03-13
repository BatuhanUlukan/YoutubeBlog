using AutoMapper;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.DTOs.Logos;
using YoutubeBlog.Entity.DTOs.Pages;
using YoutubeBlog.Entity.DTOs.Sliders;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IDashbordService
    {
        Task<List<int>> GetYearlyArticleCounts();
        Task<int> GetTotalArticleCount();
        Task<int> GetTotalCategoryCount();



        Task<string> UpdateLogoImages(LogoUpdateDto logoUpdateDto);
        Task<Logo> GetLogo(string logoName);
        Task<List<LogoDto>> GetAllLogos();



        Task<List<SliderDto>> GetSliders();
        Task CreateSliderAsync(SliderAddDto sliderAddDto);
        Task<string> UpdateSliderAsync(SliderUpdateDto sliderUpdateDto);
        Task<Slider> GetSlider(string sliderName);
        Task<string> HardDeleteSliderAsync(string sliderName);



        Task<List<FactDto>> GetFacts();
        Task CreateFactAsync(FactAddDto factAddDto);
        Task<Fact> GetFactName(string factName);
        Task<string> UpdateFactAsync(FactUpdateDto factUpdateDto);
        Task<string> HardDeleteFactAsync(string factName);


        Task<List<AboutDto>> GetAbout();
        Task<About> GetAbout(string aboutName);
        Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto);


    }
}
