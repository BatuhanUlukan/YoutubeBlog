using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Categories;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Helpers.Slug;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private string V = "Home";
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IImageHelper imageHelper;
        private readonly ClaimsPrincipal _user;

        public ArticleService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.imageHelper = imageHelper;
        }




        public async Task<ArticleListDto> GetAllByPagingAsync(string? categoryName, int currentPage = 1, int pageSize = 12, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;

            var articles = categoryName == null
                ? await unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted && a.IsActive == true,
                    a => a.Category,
                    a => a.ArticleImages, // "ArticleImages" olarak güncellendi
                    u => u.User)
                : await unitOfWork.GetRepository<Article>().GetAllAsync(a => a.Category.Name == categoryName && !a.IsDeleted && a.IsActive == true,
                    a => a.Category,
                    a => a.ArticleImages, // "ArticleImages" olarak güncellendi
                    u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var pageSeo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == V);
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryName = categoryName,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending,
                PageSeos = pageSeo
            };
        }

        public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            var article = new Article(articleAddDto.Title, string.IsNullOrEmpty(articleAddDto.Slug) ? StringHelper.GenerateSlug(articleAddDto.Title) : StringHelper.GenerateSlug(articleAddDto.Slug), articleAddDto.Description, articleAddDto.Content, userId, userEmail, articleAddDto.CategoryId)
            {
                IsActive = !_user.IsInRole("User"),
                IsSliderIsActive = articleAddDto.IsSliderIsActive
            };

            if (articleAddDto.Photos != null && articleAddDto.Photos.Any())
            {
                foreach (var photo in articleAddDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(articleAddDto.Title, photo, ImageType.Post);
                    var image = new ArticleImage(imageUpload.FullName, photo.ContentType, userEmail);
                    await unitOfWork.GetRepository<ArticleImage>().AddAsync(image);
                    article.ArticleImages.Add(image);
                }
            }

            await unitOfWork.GetRepository<Article>().AddAsync(article);
            await unitOfWork.SaveAsync();
        }




        public async Task<List<ArticleDto>> GetArticlesForUser()
        {
            var userId = _user.GetLoggedInUserId();

            // Fetch articles with a Where clause to filter by UserId and IsDeleted
            var userArticles = await unitOfWork.GetRepository<Article>()
                .GetAllAsync(s => s.UserId == userId && !s.IsDeleted, x => x.Category);

            var articleDtoList = mapper.Map<List<ArticleDto>>(userArticles);

            return articleDtoList;
        }



        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryNonDeletedAsync()
        {
            var userId = _user.GetLoggedInUserId();
            if (_user.IsInRole("User"))
            {
                var articles = await unitOfWork.GetRepository<Article>()
                    .GetAllAsync(s => s.UserId == userId && !s.IsDeleted, x => x.Category, x => x.User, i => i.ArticleImages);

                var orderedArticles = articles.OrderByDescending(a => a.CreatedDate).ToList(); // Order by CreatedDate in descending order

                var map = mapper.Map<List<ArticleDto>>(orderedArticles);

                return map;
            }
            else
            {
                var articles = await unitOfWork.GetRepository<Article>()
                    .GetAllAsync(x => !x.IsDeleted, x => x.Category, x => x.User, i => i.ArticleImages);

                var orderedArticles = articles.OrderByDescending(a => a.CreatedDate).ToList(); // Order by CreatedDate in descending order

                var map = mapper.Map<List<ArticleDto>>(orderedArticles);

                return map;
            }
        }



        public async Task<ArticleDto> GetArticleWithCategoryNonDeletedAsync(string? articleSlug, string? articleTitle, Guid? articleId)
        {

            var article = await unitOfWork.GetRepository<Article>().GetAsync(
                x => !x.IsDeleted && (x.Slug == articleSlug || x.Title == articleTitle || x.Id == articleId),
                x => x.Category,
                i => i.ArticleImages,
                u => u.User
            );

            if (article != null)
            {
                var map = mapper.Map<ArticleDto>(article);
                return map;
            }
            else
            {

                return null;
            }

        }





        public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            // Fetch the article
            var article = await unitOfWork.GetRepository<Article>().GetAsync(
                x => !x.IsDeleted && x.Id == articleUpdateDto.Id,
                x => x.Category,
                i => i.ArticleImages
            );

            // Generate or update the slug for the article
            article.Slug = string.IsNullOrEmpty(articleUpdateDto.Slug) ? StringHelper.GenerateSlug(articleUpdateDto.Title) : StringHelper.GenerateSlug(articleUpdateDto.Slug);
            article.Title = articleUpdateDto.Title;
            article.Description = articleUpdateDto.Description;
            article.Content = articleUpdateDto.Content;
            article.IsSliderIsActive  = articleUpdateDto.IsSliderIsActive;

            var oldImages = article.ArticleImages.ToList();

            if (articleUpdateDto.Photos != null && articleUpdateDto.Photos.Any())  // Check if new images are provided
            {
                // Remove and delete old images since new ones are uploaded
                foreach (var oldImage in oldImages)
                {
                    imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                    article.ArticleImages.Remove(oldImage);  // Remove the image from the article's collection
                    await unitOfWork.GetRepository<ArticleImage>().DeleteAsync(oldImage);  // Delete the image from the database
                }

                // Upload the new images
                foreach (var photo in articleUpdateDto.Photos)
                {
                    var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, photo, ImageType.Post);
                    ArticleImage image = new ArticleImage(imageUpload.FullName, photo.ContentType, userEmail);
                    await unitOfWork.GetRepository<ArticleImage>().AddAsync(image);  // Add image to the database
                    article.ArticleImages.Add(image);  // Add the image to the article's collection
                }
            }


            // Update the article
            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }






        public async Task<List<ArticleDto>> GetAllArticlesWithCategoryDeletedAsync()
        {
            var userId = _user.GetLoggedInUserId();

            if (_user.IsInRole("User"))
            {

                var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(s => s.UserId == userId && s.IsDeleted, x => x.Category, x => x.User);
                var map = mapper.Map<List<ArticleDto>>(articles);

                return map;
            }

            else
            {
                var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(x => x.IsDeleted, x => x.Category, x => x.User);
                var map = mapper.Map<List<ArticleDto>>(articles);

                return map;
            }

        }


        public async Task<List<ArticleDto>> GetRandomArticlesAsync(int count)
        {
            // Tüm portföyleri veritabanından çekin
            var allArticles = await unitOfWork.GetRepository<Article>()
                .GetAllAsync(a => !a.IsDeleted,
                             a => a.Category,
                             a => a.ArticleImages,  // "ArticleImages" olarak güncellendi
                             u => u.User);

            // Portföyleri rastgele sıralayın ve belirtilen sayıda (count) öğeyi seçin
            var randomArticles = allArticles.OrderBy(x => Guid.NewGuid()).Take(count).ToList();

            // Portföyleri DTO'ya dönüştürün
            var articleDtos = mapper.Map<List<ArticleDto>>(randomArticles);


            return articleDtos;
        }

        public async Task<List<ArticleDto>> GetRandomArticlesInCategoryAsync(Guid categoryId, int count)
        {
            // Belirli bir kategoriye ait tüm makaleleri veritabanından çekin
            var categoryArticles = await unitOfWork.GetRepository<Article>()
                .GetAllAsync(a => !a.IsDeleted && a.CategoryId == categoryId, a => a.Category, i => i.ArticleImages, u => u.User);

            // Eğer belirli bir kategoriye ait makaleler yoksa boş bir liste döndürün
            if (categoryArticles == null || !categoryArticles.Any())
            {
                return new List<ArticleDto>();
            }

            // Kategoriye ait makaleleri rastgele sıralayın ve belirtilen sayıda (count) öğeyi seçin
            var randomArticles = categoryArticles.OrderBy(x => Guid.NewGuid()).Take(count).ToList();

            // Makaleleri DTO'ya dönüştürün
            var articleDtos = mapper.Map<List<ArticleDto>>(randomArticles);

            return articleDtos;
        }

        public async Task<UserDto> GetAuthorInfoAsync(Guid articleId)
        {
            // Makaleyi veritabanından çekin ve yazar bilgilerini döndürün
            var article = await unitOfWork.GetRepository<Article>().GetAsync(
                x => !x.IsDeleted && x.Id == articleId,
                x => x.User,
                x => x.User.UserImagess
            );

            if (article != null)
            {
                // Makaleyi yazan kullanıcının bilgilerini UserDto'ya dönüştürün
                var authorInfo = mapper.Map<UserDto>(article.User);
                return authorInfo;
            }

            // Makale bulunamazsa veya yazar bilgisi yoksa null döndürün
            return null;
        }

        public async Task<ArticleDto> GetAdjacentArticleAsync(string slug, ArticleDirection direction)
        {
            // Mevcut makalenin oluşturulma tarihini al
            var currentArticle = await unitOfWork.GetRepository<Article>()
          .GetAsync(a => a.Slug == slug && !a.IsDeleted && a.IsActive == true);
            if (currentArticle == null) return null; // Mevcut makale bulunamazsa null döndür


            var currentDate = currentArticle.CreatedDate;

            Article targetArticle;

            if (direction == ArticleDirection.Next)
            {
                var nextArticles = await unitOfWork.GetRepository<Article>()
                    .GetAllAsync(a => !a.IsDeleted && a.IsActive || a.CreatedDate > currentDate, a => a.Category,  i => i.ArticleImages, u => u.User);
                targetArticle = nextArticles.OrderBy(a => a.CreatedDate).FirstOrDefault();
            }
            else // Previous
            {
                var previousArticles = await unitOfWork.GetRepository<Article>()
                    .GetAllAsync(a => !a.IsDeleted && a.IsActive || a.CreatedDate < currentDate, a => a.Category, i => i.ArticleImages, u => u.User);
                targetArticle = previousArticles.OrderByDescending(a => a.CreatedDate).FirstOrDefault();
            }

            return mapper.Map<ArticleDto>(targetArticle);
        }



        public async Task<ArticleListDto> SearchAsync(string keyword, int currentPage = 1, int pageSize = 3, bool isAscending = false)
        {
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles = await unitOfWork.GetRepository<Article>().GetAllAsync(
                a => !a.IsDeleted && a.IsActive == true && (a.Title.Contains(keyword) || a.Content.Contains(keyword) || a.Category.Name.Contains(keyword)),
            a => a.Category,  i => i.ArticleImages, u => u.User);

            var sortedArticles = isAscending
                ? articles.OrderBy(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList()
                : articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = articles.Count,
                IsAscending = isAscending
            };
        }
        public async Task<string> HardDeleteArticleAsync(string articleSlug)
        {
            // Article nesnesini veritabanından getir
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == articleSlug, x => x.ArticleImages);

            // İlişkili tüm resimleri sil
            foreach (var image in article.ArticleImages)
            {
                imageHelper.Delete(image.FileName);  // Fiziksel resim dosyasını sil
                await unitOfWork.GetRepository<ArticleImage>().DeleteAsync(image);  // Resmi veritabanından sil
            }

            // Article nesnesini veritabanından sil
            await unitOfWork.GetRepository<Article>().DeleteAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }
        public async Task<string> UndoDeleteArticleAsync(string articleSlug)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == articleSlug);

            foreach (var image in article.ArticleImages)
            {
                image.IsDeleted = false;
            }

            article.IsDeleted = false;
            article.DeletedDate = null;
            article.DeletedBy = null;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }

        public async Task<string> SafeDeleteArticleAsync(string articleSlug)
        {
            var userEmail = _user.GetLoggedInEmail();
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == articleSlug);

            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now;
            article.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }



        public async Task<string> ApproveArticle(string articleSlug)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == articleSlug);
            article.IsActive = true;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }
        public async Task<string> RejectArticle(string articleSlug)
        {
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x => x.Slug == articleSlug);
            article.IsActive = false;

            await unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await unitOfWork.SaveAsync();

            return article.Title;
        }


    }
}




























