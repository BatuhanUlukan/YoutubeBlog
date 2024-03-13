using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Portfolios;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Helpers.Slug;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class PortfolioService : IPortfolioService
    {
        private string V = "Portfolio";
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.imageHelper = imageHelper;
        }
        public async Task<PortfolioListDto> GetAllByPagingAsync(Guid? categoryId, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var portfolios = categoryId == null
                ? await unitOfWork.GetRepository<Portfolio>().GetAllAsync(a => !a.IsDeleted && a.IsActive,
                    a => a.Category,
                    a => a.PortfolioImages, // "PortfolioImages" olarak güncellendi
                    u => u.User)
                : await unitOfWork.GetRepository<Portfolio>().GetAllAsync(a => a.CategoryId == categoryId && !a.IsDeleted && a.IsActive,
                    a => a.Category,
                    a => a.PortfolioImages, // "PortfolioImages" olarak güncellendi
                    u => u.User);

            var sortedPortfolios = isAscending
                ? portfolios.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : portfolios.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            var pageSeo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == V);

            return new PortfolioListDto
            {
                Portfolios = sortedPortfolios,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = portfolios.Count,
                IsAscending = isAscending,
                PageSeos = pageSeo
            };
        }

        public async Task CreatePortfolioAsync(PortfolioAddDto portfolioAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();
            var portfolio = new Portfolio(portfolioAddDto.Title, portfolioAddDto.Content, portfolioAddDto.Link, userId, userEmail, portfolioAddDto.CategoryId);

            if (string.IsNullOrEmpty(portfolioAddDto.Slug))
            {
                // Generate a slug for the portfolio
                var slug = StringHelper.GenerateSlug(portfolioAddDto.Title);
                portfolio.Slug = slug;  // Yeni slug'ı atayın
            }
            else
            {
                var slug = StringHelper.GenerateSlug(portfolioAddDto.Slug);
                portfolio.Slug = slug;  // Yeni slug'ı atayın
            }

            if (portfolioAddDto.Photos != null && portfolioAddDto.Photos.Count > 0)
            {
                foreach (var photo in portfolioAddDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(portfolioAddDto.Title, photo, ImageType.Work);
                    PortfolioImage image = new(imageUpload.FullName, photo.ContentType, userEmail);
                    await unitOfWork.GetRepository<PortfolioImage>().AddAsync(image);
                    portfolio.PortfolioImages.Add(image);
                }
            }

            await unitOfWork.GetRepository<Portfolio>().AddAsync(portfolio);
            await unitOfWork.SaveAsync();
        }


        public async Task<List<PortfolioDto>> GetAllPortfoliosWithCategoryNonDeletedAsync()
        {
            // Fetch all non-deleted and active portfolios along with their categories
            var portfolios = await unitOfWork.GetRepository<Portfolio>().GetAllAsync(
                x => !x.IsDeleted,
                x => x.Category, i => i.PortfolioImages
            );

            var map = mapper.Map<List<PortfolioDto>>(portfolios);

            return map;
        }

        public async Task<PortfolioDto> GetPortfolioWithCategoryNonDeletedAsync(string portfolioSlug)
        {
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => !x.IsDeleted && x.Slug == portfolioSlug,
                                                                                 x => x.Category,
                                                                                 i => i.PortfolioImages,
                                                                                 u => u.User);
            var map = mapper.Map<PortfolioDto>(portfolio);

            return map;
        }
        public async Task<string> UpdatePortfolioAsync(PortfolioUpdateDto portfolioUpdateDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            // Fetch the portfolio
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => !x.IsDeleted && x.Id == portfolioUpdateDto.Id, x => x.Category, i => i.PortfolioImages);

            if (string.IsNullOrEmpty(portfolioUpdateDto.Slug))
            {
                // Generate a slug for the portfolio
                var slug = StringHelper.GenerateSlug(portfolioUpdateDto.Title);
                portfolio.Slug = slug;  // Yeni slug'ı atayın
            }
            else
            {
                var slug = StringHelper.GenerateSlug(portfolioUpdateDto.Slug);
                portfolio.Slug = slug;  // Yeni slug'ı atayın
            }

            portfolio.IsActive = portfolioUpdateDto.IsActive;
            portfolio.Title = portfolioUpdateDto.Title;

            portfolio.Content = portfolioUpdateDto.Content;
            portfolio.ModifiedDate = DateTime.Now;
            portfolio.ModifiedBy = userEmail;
            portfolio.CategoryId = portfolioUpdateDto.CategoryId;

            // If new images are provided
            if (portfolioUpdateDto.Photos != null && portfolioUpdateDto.Photos.Any())
            {
                // Fetch and keep old images for later deletion                                                                                                                                B
                var oldImages = portfolio.PortfolioImages.ToList();

                // Add new portfolio images
                foreach (var photo in portfolioUpdateDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(portfolioUpdateDto.Title, photo, ImageType.Work);
                    PortfolioImage image = new(imageUpload.FullName, photo.ContentType, userEmail);

                    await unitOfWork.GetRepository<PortfolioImage>().AddAsync(image);  // Add image to the database
                    portfolio.PortfolioImages.Add(image);  // Add the image to the portfolio's collection
                }

                // Remove and delete old images since new ones are uploaded
                foreach (var oldImage in oldImages)
                {
                    imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                    portfolio.PortfolioImages.Remove(oldImage);  // Remove the image from the portfolio's collection
                    await unitOfWork.GetRepository<PortfolioImage>().DeleteAsync(oldImage);  // Delete the image from the database
                }
            }

            await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);
            await unitOfWork.SaveAsync();

            return portfolio.Title;
        }

        public async Task<string> SafeDeletePortfolioAsync(string secName)
        {
            var userEmail = _user.GetLoggedInEmail();
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => x.SecName == secName, x => x.PortfolioImages);

            portfolio.IsDeleted = true;
            portfolio.IsActive = false;
            portfolio.DeletedDate = DateTime.Now;
            portfolio.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);
            await unitOfWork.SaveAsync();

            return portfolio.Title;
        }

        public async Task<List<PortfolioDto>> GetAllPortfoliosWithCategoryDeletedAsync()
        {
            var portfolios = await unitOfWork.GetRepository<Portfolio>().GetAllAsync(x => x.IsDeleted, x => x.Category, i => i.PortfolioImages);
            var map = mapper.Map<List<PortfolioDto>>(portfolios);

            return map;
        }

        public async Task<string> UndoDeletePortfolioAsync(string portfolioTitle)
        {
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => x.Title == portfolioTitle, x => x.PortfolioImages);

            foreach (var image in portfolio.PortfolioImages)
            {
                image.IsDeleted = false;
            }

            portfolio.IsDeleted = false;
            portfolio.DeletedDate = null;
            portfolio.DeletedBy = null;

            await unitOfWork.GetRepository<Portfolio>().UpdateAsync(portfolio);
            await unitOfWork.SaveAsync();

            return portfolio.Title;
        }


        public async Task<List<PortfolioDto>> GetRandomPortfoliosAsync(int count)
        {
            // Tüm portföyleri veritabanından çekin
            var allPortfolios = await unitOfWork.GetRepository<Portfolio>()
                            .GetAllAsync(a => !a.IsDeleted && a.IsActive, // Filter for active portfolios
                             a => a.Category,
                             a => a.PortfolioImages,  // "PortfolioImages" olarak güncellendi
                             u => u.User);

            // Portföyleri rastgele sıralayın ve belirtilen sayıda (count) öğeyi seçin
            var randomPortfolios = allPortfolios.OrderBy(x => Guid.NewGuid()).Take(count).ToList();

            // Portföyleri DTO'ya dönüştürün
            var portfolioDtos = mapper.Map<List<PortfolioDto>>(randomPortfolios);

            return portfolioDtos;
        }
        public async Task<string> HardDeletePortfolioAsync(string portfolioTitle)
        {
            // Portfolio nesnesini veritabanından getir
            var portfolio = await unitOfWork.GetRepository<Portfolio>().GetAsync(x => x.Title == portfolioTitle, x => x.PortfolioImages);

            if (portfolio == null)
            {
                throw new Exception("Portfolio not found.");
            }

            // İlişkili tüm resimleri sil
            foreach (var image in portfolio.PortfolioImages)
            {
                imageHelper.Delete(image.FileName);  // Fiziksel resim dosyasını sil
                await unitOfWork.GetRepository<PortfolioImage>().DeleteAsync(image);  // Resmi veritabanından sil
            }

            // Portfolio nesnesini veritabanından sil
            await unitOfWork.GetRepository<Portfolio>().DeleteAsync(portfolio);
            await unitOfWork.SaveAsync();

            return portfolio.Title;
        }



    }
}