using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Abouts;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Facts;
using YoutubeBlog.Entity.DTOs.Logos;
using YoutubeBlog.Entity.DTOs.Sliders;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstractions;
namespace YoutubeBlog.Service.Services.Concrete
{
    public class DashboardService : IDashbordService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;



        public DashboardService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.imageHelper = imageHelper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
        }

        public async Task<List<int>> GetYearlyArticleCounts()
        {
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => !x.IsDeleted);

            var startDate = DateTime.Now.Date;
            startDate = new DateTime(startDate.Year, 1, 1);

            List<int> datas = new();

            for (int i = 1; i <= 12; i++)
            {
                var startedDate = new DateTime(startDate.Year, i, 1);
                var endedDate = startedDate.AddMonths(1);
                var data = articles.Where(x => x.CreatedDate >= startedDate && x.CreatedDate < endedDate).Count();
                datas.Add(data);
            }

            return datas;
        }
        public async Task<int> GetTotalArticleCount()
        {
            var articleCount = await unitOfWork.GetRepository<Article>().CountAsync();
            return articleCount;
        }
        public async Task<int> GetTotalCategoryCount()
        {
            var categoryCount = await unitOfWork.GetRepository<Category>().CountAsync();
            return categoryCount;
        }

        public async Task<string> UpdateLogoImages(LogoUpdateDto logoUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            // Fetch the logos
            var logos = await unitOfWork.GetRepository<Logo>().GetAsync(x => !x.IsDeleted && x.Id == logoUpdateDto.Id, i => i.LogoImages);

            logos.Slug = logoUpdateDto.Slug;
            logos.ModifiedBy = userEmail;
            logos.ModifiedDate = DateTime.Now;

            // If new images are provided
            if (logoUpdateDto.Photos != null && logoUpdateDto.Photos.Any())
            {
                // Fetch and keep old images for later deletion                                                                                                                               
                var oldImages = logos.LogoImages.ToList();

                // Add new logos images
                foreach (var photo in logoUpdateDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(logoUpdateDto.Title, photo, ImageType.Logo);
                    LogoImage image = new(imageUpload.FullName, photo.ContentType, userEmail);

                    await unitOfWork.GetRepository<LogoImage>().AddAsync(image);  // Add image to the database
                    logos.LogoImages.Add(image);  // Add the image to the logos's collection
                }

                // Remove and delete old images since new ones are uploaded
                foreach (var oldImage in oldImages)
                {
                    imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                    logos.LogoImages.Remove(oldImage);  // Remove the image from the logos's collection
                    await unitOfWork.GetRepository<LogoImage>().DeleteAsync(oldImage);  // Delete the image from the database
                }
            }

            await unitOfWork.GetRepository<Logo>().UpdateAsync(logos);
            await unitOfWork.SaveAsync();

            return logos.Title;
        }

        public async Task<Logo> GetLogo(string logoName)
        {
            var logo = await unitOfWork.GetRepository<Logo>().GetAsync(x => x.Title == logoName, x => x.LogoImages);
            var map = mapper.Map<Logo>(logo);

            return logo;
        }

        public async Task<List<LogoDto>> GetAllLogos()
        {

            var logoDtos = await unitOfWork.GetRepository<Logo>().GetAllAsync(x => x.IsActive, i => i.LogoImages);
            var map = mapper.Map<List<LogoDto>>(logoDtos);

            return map;

        }

        public async Task<List<SliderDto>> GetSliders()
        {
            var sliders = await unitOfWork.GetRepository<Slider>()
                .GetAllAsync(s => !s.IsDeleted, x => x.SliderImages);

            var sliderDtos = mapper.Map<List<SliderDto>>(sliders);

            return sliderDtos;
        }
        public async Task<Slider> GetSlider(string sliderName)
        {
            var slider = await unitOfWork.GetRepository<Slider>().GetAsync(x => x.Name == sliderName, x => x.SliderImages);
            var map = mapper.Map<Slider>(slider);

            return slider;
        }
        public async Task<string> UpdateSliderAsync(SliderUpdateDto sliderUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            // Fetch the logos
            var sliders = await unitOfWork.GetRepository<Slider>().GetAsync(x => !x.IsDeleted && x.Id == sliderUpdateDto.Id, i => i.SliderImages);

            sliders.Name = sliderUpdateDto.Name;
            sliders.SubContent = sliderUpdateDto.SubContent;
            sliders.Content = sliderUpdateDto.Content;
            sliders.ModifiedBy = userEmail;
            sliders.ModifiedDate = DateTime.Now;


            // If new images are provided
            if (sliderUpdateDto.Photos != null && sliderUpdateDto.Photos.Any())
            {
                // Fetch and keep old images for later deletion                                                                                                                               
                var oldImages = sliders.SliderImages.ToList();

                // Add new logos images
                foreach (var photo in sliderUpdateDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(sliderUpdateDto.Name, photo, ImageType.Slider);
                    SliderImage image = new(imageUpload.FullName, photo.ContentType, userEmail);

                    await unitOfWork.GetRepository<SliderImage>().AddAsync(image);  // Add image to the database
                    sliders.SliderImages.Add(image);  // Add the image to the logos's collection
                }

                // Remove and delete old images since new ones are uploaded
                foreach (var oldImage in oldImages)
                {
                    imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                    sliders.SliderImages.Remove(oldImage);  // Remove the image from the logos's collection
                    await unitOfWork.GetRepository<SliderImage>().DeleteAsync(oldImage);  // Delete the image from the database
                }
            }

            await unitOfWork.GetRepository<Slider>().UpdateAsync(sliders);
            await unitOfWork.SaveAsync();

            return sliders.Name;
        }

        public async Task CreateSliderAsync(SliderAddDto sliderAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var slider = new Slider(sliderAddDto.Name, sliderAddDto.Content, sliderAddDto.SubContent, userEmail);


            foreach (var photo in sliderAddDto.Photos)
            {
                var imageUpload = await imageHelper.Upload(sliderAddDto.Name, photo, ImageType.Slider);
                SliderImage image = new(imageUpload.FullName, photo.ContentType, userEmail);
                await unitOfWork.GetRepository<SliderImage>().AddAsync(image);
                slider.SliderImages.Add(image);
            }

            await unitOfWork.GetRepository<Slider>().AddAsync(slider);
            await unitOfWork.SaveAsync();
        }
        public async Task<string> HardDeleteSliderAsync(string sliderName)
        {
            // Portfolio nesnesini veritabanından getir
            var slider = await unitOfWork.GetRepository<Slider>().GetAsync(x => x.Name == sliderName, x => x.SliderImages);


            // İlişkili tüm resimleri sil
            foreach (var image in slider.SliderImages)
            {
                imageHelper.Delete(image.FileName);  // Fiziksel resim dosyasını sil
                await unitOfWork.GetRepository<SliderImage>().DeleteAsync(image);  // Resmi veritabanından sil
            }

            // Portfolio nesnesini veritabanından sil
            await unitOfWork.GetRepository<Slider>().DeleteAsync(slider);
            await unitOfWork.SaveAsync();

            return slider.Name;
        }






        public async Task<List<FactDto>> GetFacts()
        {
            var facts = await unitOfWork.GetRepository<Fact>()
                .GetAllAsync(s => !s.IsDeleted && s.IsActive);

            var factsDtos = mapper.Map<List<FactDto>>(facts);

            return factsDtos;
        }

        public async Task CreateFactAsync(FactAddDto factAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            Fact fact = new(factAddDto.Name, factAddDto.Value, factAddDto.Icon, userEmail);
            await unitOfWork.GetRepository<Fact>().AddAsync(fact);
            await unitOfWork.SaveAsync();

        }
        public async Task<Fact> GetFactName(string factName)
        {
            var fact = await unitOfWork.GetRepository<Fact>().GetAsync(x => x.Name == factName);
            return fact;
        }
        public async Task<string> UpdateFactAsync(FactUpdateDto factUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var fact = await unitOfWork.GetRepository<Fact>().GetAsync(x => !x.IsDeleted && x.Name == factUpdateDto.Name);

            fact.Name = factUpdateDto.Name;
            fact.Value = factUpdateDto.Value;
            fact.Icon = factUpdateDto.Icon;
            fact.ModifiedBy = userEmail;
            fact.ModifiedDate = DateTime.Now;


            await unitOfWork.GetRepository<Fact>().UpdateAsync(fact);
            await unitOfWork.SaveAsync();


            return fact.Name;
        }

        public async Task<string> HardDeleteFactAsync(string factName)
        {
            // Portfolio nesnesini veritabanından getir
            var fact = await unitOfWork.GetRepository<Fact>().GetAsync(x => x.Name == factName);

            // Portfolio nesnesini veritabanından sil
            await unitOfWork.GetRepository<Fact>().DeleteAsync(fact);
            await unitOfWork.SaveAsync();

            return fact.Name;
        }









        public async Task<List<AboutDto>> GetAbout()
        {
            var about = await unitOfWork.GetRepository<About>()
                .GetAllAsync(s => !s.IsDeleted, x => x.AboutImages);

            var aboutDtos = mapper.Map<List<AboutDto>>(about);

            return aboutDtos;
        }


        public async Task<About> GetAbout(string aboutName)
        {
            var about = await unitOfWork.GetRepository<About>().GetAsync(x => x.Name == aboutName, x => x.AboutImages);
            return about;
        }

        public async Task<string> UpdateAboutAsync(AboutUpdateDto aboutUpdateDto)
        {
            {
                var userEmail = _user.GetLoggedInEmail();

                // Fetch the logos
                var abouts = await unitOfWork.GetRepository<About>().GetAsync(x => !x.IsDeleted && x.Id == aboutUpdateDto.Id, i => i.AboutImages);

                abouts.Name2 = aboutUpdateDto.Name2;
                abouts.Content = aboutUpdateDto.Content;
                abouts.SubContent = aboutUpdateDto.SubContent;
                abouts.ModifiedDate = DateTime.Now;
                abouts.ModifiedBy = userEmail;

                // If new images are provided
                if (aboutUpdateDto.Photos != null && aboutUpdateDto.Photos.Any())
                {
                    // Fetch and keep old images for later deletion                                                                                                                               
                    var oldImages = abouts.AboutImages.ToList();

                    // Add new logos images
                    foreach (var photo in aboutUpdateDto.Photos)
                    {
                        var imageUpload = await imageHelper.Upload(aboutUpdateDto.Name, photo, ImageType.About);
                        AboutImage image = new(imageUpload.FullName, photo.ContentType, userEmail);

                        await unitOfWork.GetRepository<AboutImage>().AddAsync(image);  // Add image to the database
                        abouts.AboutImages.Add(image);  // Add the image to the logos's collection
                    }

                    // Remove and delete old images since new ones are uploaded
                    foreach (var oldImage in oldImages)
                    {
                        imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                        abouts.AboutImages.Remove(oldImage);  // Remove the image from the logos's collection
                        await unitOfWork.GetRepository<AboutImage>().DeleteAsync(oldImage);  // Delete the image from the database
                    }
                }

                await unitOfWork.GetRepository<About>().UpdateAsync(abouts);
                await unitOfWork.SaveAsync();

                return abouts.Name;
            }
        }
    }
}

