using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class HeadquarterService : IHeadquarterService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public HeadquarterService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }


        public async Task<List<HeadquarterDto>> GetAllHeadquartersNonDeleted()
        {
            var headquarters = await unitOfWork.GetRepository<Headquarter>().GetAllAsync(x => !x.IsDeleted);
            var map = mapper.Map<List<HeadquarterDto>>(headquarters);

            return map;
        }

        public async Task<List<HeadquarterDto>> GetAllHeadquarteersMaınPage()
        {
            var headquarters = await unitOfWork.GetRepository<Headquarter>().GetAllAsync(x => !x.IsDeleted && x.IsActive);
            var map = mapper.Map<List<HeadquarterDto>>(headquarters);

            return map;
        }

        public async Task CreateHeadquarterAsync(HeadquarterAddDto headquarterAddDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            // Check if any headquarters are already chosen
            bool isAnyChosen = await unitOfWork.GetRepository<Headquarter>()
                .AnyAsync(hq => hq.Choosen);

            if (isAnyChosen && headquarterAddDto.Choosen)
            {
                // Hata fırlat veya bir hata kodu döndür, isteğe bağlı
                throw new InvalidOperationException("Mevcut bir başkanlık seçilmiş.");
            }

            Headquarter headquarter = mapper.Map<Headquarter>(headquarterAddDto);

            await unitOfWork.GetRepository<Headquarter>().AddAsync(headquarter);
            await unitOfWork.SaveAsync();
        }




        public async Task<Headquarter> GetHeadquarterByGuid(string headquarterName)
        {
            var headquarter = await unitOfWork.GetRepository<Headquarter>().GetAsync(x => x.Name == headquarterName);
            return headquarter;
        }



        public async Task<string> UpdateHeadquarterAsync(HeadquarterUpdateDto headquarterUpdateDto)
        {
            var userEmail = _user.GetLoggedInEmail();
            var headquarter = await unitOfWork.GetRepository<Headquarter>().GetAsync(x => !x.IsDeleted && x.Id == headquarterUpdateDto.Id);

            // Güncellenen genel merkez şu anda seçili değilse ve yeni başkanlık seçilmek isteniyorsa kontrolü
            if (!headquarter.Choosen && headquarterUpdateDto.Choosen)
            {
                bool isAnyChosen = await unitOfWork.GetRepository<Headquarter>().AnyAsync(hq => hq.Choosen);

                if (isAnyChosen)
                {
                    // Başka bir genel merkezde zaten seçilmiş bir başkanlık bulunmaktadır.
                    throw new InvalidOperationException("Mevcut bir başkanlık seçilmiş.");
                }
            }

            if (headquarterUpdateDto.Choosen)
            {
                headquarter.Choosen = true;
            }


            mapper.Map(headquarterUpdateDto, headquarter);
            headquarter.ModifiedBy = userEmail;
            headquarter.ModifiedDate = DateTime.Now;

            await unitOfWork.GetRepository<Headquarter>().UpdateAsync(headquarter);
            await unitOfWork.SaveAsync();

            return headquarter.Name;
        }



        public async Task<string> SafeDeleteHeadquarterAsync(string headquarterName)
        {
            var userEmail = _user.GetLoggedInEmail();
            var headquarter = await unitOfWork.GetRepository<Headquarter>().GetAsync(x => x.Name == headquarterName);

            headquarter.IsActive = false;
            headquarter.IsDeleted = true;
            headquarter.DeletedDate = DateTime.Now;
            headquarter.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Headquarter>().UpdateAsync(headquarter);
            await unitOfWork.SaveAsync();

            return headquarter.Name;
        }

        public async Task<List<HeadquarterDto>> GetAllHeadquartersDeleted()
        {
            var headquarters = await unitOfWork.GetRepository<Headquarter>().GetAllAsync(x => x.IsDeleted);
            var map = mapper.Map<List<HeadquarterDto>>(headquarters);

            return map;
        }

        public async Task<string> UndoDeleteHeadquarterAsync(string headquarterName)
        {
            var headquarter = await unitOfWork.GetRepository<Headquarter>().GetAsync(x => x.Name == headquarterName);
            var userEmail = _user.GetLoggedInEmail();

            headquarter.IsDeleted = false;
            headquarter.DeletedDate = DateTime.UtcNow;
            headquarter.DeletedBy = userEmail;

            await unitOfWork.GetRepository<Headquarter>().UpdateAsync(headquarter);
            await unitOfWork.SaveAsync();

            return headquarter.Name;
        }
        public async Task<string> HardDeleteHeadquarterAsync(string headquarterName)
        {
            var headquarter = await unitOfWork.GetRepository<Headquarter>().GetAsync(x => x.Name == headquarterName);

            if (headquarter != null)
            {
                // Remove the entity from the repository
                unitOfWork.GetRepository<Headquarter>().DeleteAsync(headquarter);
                await unitOfWork.SaveAsync();

                return headquarter.Name;
            }

            // If the headquarter with the specified ID doesn't exist, you can handle the error or return an appropriate value.
            return null; // Or throw an exception, depending on your error handling strategy.
        }



    }
}
