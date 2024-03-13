using YoutubeBlog.Entity.DTOs.Headquarters;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IHeadquarterService
    {
        Task<List<HeadquarterDto>> GetAllHeadquartersNonDeleted();
        Task<List<HeadquarterDto>> GetAllHeadquarteersMaınPage();
        Task<List<HeadquarterDto>> GetAllHeadquartersDeleted();
        Task CreateHeadquarterAsync(HeadquarterAddDto HeadquarterAddDto);
        Task<Headquarter> GetHeadquarterByGuid(string headquarterName);
        Task<string> UpdateHeadquarterAsync(HeadquarterUpdateDto HeadquarterUpdateDto);
        Task<string> SafeDeleteHeadquarterAsync(string headquarterName);
        Task<string> UndoDeleteHeadquarterAsync(string headquarterName);
        Task<string> HardDeleteHeadquarterAsync(string headquarterName);



    }
}
