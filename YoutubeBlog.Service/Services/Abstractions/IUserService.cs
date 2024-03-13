using Microsoft.AspNetCore.Identity;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUsersWithRoleAsync();
        Task<List<AppRole>> GetAllRolesAsync();
        Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(string user);
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<AppUser> GetAppUserAsync(string user);
        Task<string> GetUserRoleAsync(AppUser user);



        // SOCIALS FOR USER 
        Task<List<SocialDto>> GetSocialProfilesForUser(Guid userId);
        Task<List<SocialDto>> GetAllMaınSocials();
        Task<List<SocialDto>> GetMaınPageSocials();
        Task<string> UndoDeleteSocialAsync(string secName);
        Task<bool> DeleteSocialAsync(string secName);
        Task<IdentityResult> UpdateSocialAsync(SocialUpdateDto socialUpdateDto);
        Task<IdentityResult> CreateSocialAsync(SocialAddDto socialAddDto);
        Task<Social> GetUserWithSocial(string secName);
        Task<string> HardDeleteSocialAsync(string secName);
        Task<List<SocialDto>> GetDeletedSocials();



        //SERVICES FOR USER
        Task<Duty> GetUserWithDuty(string secName);
        Task<IdentityResult> CreateServiceAsync(DutyAddDto dutyAddDto);
        Task<List<DutyDto>> GetAllServicesForMain();
        Task<List<DutyDto>> GetAllServicesForMains();
        Task<IdentityResult> UpdateServiceAsync(DutyUpdateDto dutyUpdateDto);
        Task<bool> DeleteServiceAsync(string secName);
        Task<string> HardDeleteServiceAsync(string secName);
        Task<string> UndoDeleteServiceAsync(string secName);
        Task<List<DutyDto>> GetDeletedDuties();




    }
}
