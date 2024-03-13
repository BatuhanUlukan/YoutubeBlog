using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Articles;
using YoutubeBlog.Entity.DTOs.Comments;
using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.DTOs.Messages;
using YoutubeBlog.Entity.DTOs.Pages;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public class PageSeoService : IPageSeoService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public PageSeoService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }


        public async Task<PageSeo> GetSeoPage(string pageName)

        {
            var seo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == pageName);
            var map = mapper.Map<PageSeo>(seo);

            return seo;
        }
        public async Task<List<PageSeoDto>> GetAllSeoPage()
        {
            // Fetch all messages from the database
            var seos = await unitOfWork.GetRepository<PageSeo>().GetAllAsync();

            // Map the entity messages to the MessageDto using AutoMapper
            var seoDtos = mapper.Map<List<PageSeoDto>>(seos);

            return seoDtos;
        }

        public async Task<string> UpdatePageSeoAsync(PageSeoUpdateDto pageSeoUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var pageSeo = await unitOfWork.GetRepository<PageSeo>().GetAsync(x => x.Page == pageSeoUpdateDto.Page);

            pageSeo.Description = pageSeoUpdateDto.Description;
            pageSeo.Keywords = pageSeoUpdateDto.Keywords;
            pageSeo.Title = pageSeoUpdateDto.Title;
            pageSeo.ModifiedBy = userEmail;
            pageSeo.ModifiedDate = DateTime.Now;
            mapper.Map(pageSeoUpdateDto, pageSeo);

            await unitOfWork.GetRepository<PageSeo>().UpdateAsync(pageSeo);
            await unitOfWork.SaveAsync();

            return pageSeo.Page;
        }
    }
}
