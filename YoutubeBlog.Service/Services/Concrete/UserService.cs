using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Entity.Enums;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Helpers.Slug;
using YoutubeBlog.Service.Services.Abstractions;
using static System.Net.Mime.MediaTypeNames;

namespace YoutubeBlog.Service.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IImageHelper imageHelper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
        {
            this.unitOfWork = unitOfWork;
            this.httpContextAccessor = httpContextAccessor;
            this._user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.imageHelper = imageHelper;

        }


        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {

            // Map the UserAddDto to an AppUser
            var user = mapper.Map<AppUser>(userAddDto);

            // Set the UserName to the user's email
            user.UserName = userAddDto.Email;


            // Create the user with the provided password or an empty string if it's null or empty
            var result = await userManager.CreateAsync(user, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                // Find the role by its ID
                var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());

                // Add the user to the role
                await userManager.AddToRoleAsync(user, findRole.Name);
            }

            return result;
        }




        public async Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(string user)
        {
            var users = await GetAppUserAsync(user);
            var result = await userManager.DeleteAsync(users);
            if (result.Succeeded)
                return (result, users.Email);
            else
                return (result, null);
        }

        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {

            var users = await userManager.Users.Include(u => u.UserImagess).ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);


            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));
                item.Role = role;
            }

            return map;
        }


        public async Task<AppUser> GetAppUserAsync(string user)
        {
            // Assuming unitOfWork is an instance of your unit of work class
            var users = await unitOfWork.GetRepository<AppUser>()
                .GetAsync(x => x.SecName == user, i => i.UserImagess, i => i.Duties);  // Include Duties here
            var map = mapper.Map<AppUser>(users);

            return map;
        }

        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            // Assuming unitOfWork is an instance of your unit of work class
            var user = await unitOfWork.GetRepository<AppUser>()
                .GetAsync(x => x.Id == userId, i => i.UserImagess, i => i.Duties);  // Include Duties here
            var map = mapper.Map<AppUser>(user);

            return map;
        }


        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await userManager.GetRolesAsync(user));
        }

        private void LogErrors(IEnumerable<IdentityError> errors)
        {
            foreach (var error in errors)
            {
                Console.WriteLine($"Error during user update: {error.Description}");
            }
        }

        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            try
            {
                var user = await GetAppUserByIdAsync(userUpdateDto.Id);
                var userEmail = _user.GetLoggedInEmail();

                await UpdateUserRoleAsync(user, userUpdateDto.RoleId);

                await UpdateUserPasswordAsync(user, userUpdateDto.NewPassword);

                if (userUpdateDto.Photos != null && userUpdateDto.Photos.Any())
                {
                    // Remove and delete old images since new ones are uploaded
                    foreach (var oldImage in user.UserImagess.ToList())
                    {
                        imageHelper.Delete(oldImage.FileName);  // Delete the physical image file
                        user.UserImagess.Remove(oldImage);      // Remove the image from the user's collection
                        await unitOfWork.GetRepository<UserImage>().DeleteAsync(oldImage);  // Delete the image from the database
                    }

                    // Upload the new image(s)
                    foreach (var photo in userUpdateDto.Photos)
                    {
                        var imageUpload = await imageHelper.Upload(userUpdateDto.Email, photo, ImageType.User);
                        UserImage image = new(imageUpload.FullName, photo.ContentType, userEmail)
                        {
                            UserId = user.Id
                        };
                        await unitOfWork.GetRepository<UserImage>().AddAsync(image);
                        user.UserImagess.Add(image);
                    }
                }

                // Update additional properties and save changes
                userUpdateDto.SecName = UniqStr.GuidToRandomName(Guid.NewGuid().ToString(), 6, 8);
                mapper.Map(userUpdateDto, user);

                var result = await userManager.UpdateAsync(user);
                await unitOfWork.SaveAsync();

                if (!result.Succeeded)
                {
                    LogErrors(result.Errors);
                }

                return result;
            }
            catch (Exception ex)
            {
                LogErrors(new[] { new IdentityError { Description = $"An unexpected error occurred: {ex.Message}" } });
                return IdentityResult.Failed(new IdentityError { Description = "An unexpected error occurred during user update." });
            }
        }

        private async Task UpdateUserRoleAsync(AppUser user, Guid? roleId)
        {
            var userRole = await GetUserRoleAsync(user);

            // Remove existing role
            if (!string.IsNullOrEmpty(userRole))
            {
                await userManager.RemoveFromRoleAsync(user, userRole);
            }

            // Assign the new role
            if (roleId != null && roleId != Guid.Empty)
            {
                var findRole = await roleManager.FindByIdAsync(roleId.ToString());

                if (findRole != null)
                {
                    await userManager.AddToRoleAsync(user, findRole.Name);
                }
                else
                {
                    LogErrors(new[] { new IdentityError { Description = "Role not found." } });
                }
            }
            else
            {
                // RoleId is not specified or is empty, directly assign the role to "User"
                await userManager.AddToRoleAsync(user, "User");
            }
        }

        private async Task UpdateUserPasswordAsync(AppUser user, string newPassword)
        {
            if (!string.IsNullOrEmpty(newPassword))
            {
                var removePasswordResult = await userManager.RemovePasswordAsync(user);

                if (removePasswordResult.Succeeded)
                {
                    var addPasswordResult = await userManager.AddPasswordAsync(user, newPassword);

                    if (!addPasswordResult.Succeeded)
                    {
                        LogErrors(addPasswordResult.Errors);
                    }
                }
                else
                {
                    LogErrors(removePasswordResult.Errors);
                }

                await userManager.UpdateSecurityStampAsync(user);

                // Skip the sign-out and sign-in steps to avoid reauthentication
                // await signInManager.SignOutAsync();
                // await signInManager.PasswordSignInAsync(user, newPassword, true, false);
            }
        }

        //KULLANICLARIN SERVISLERI ICIN METHOTLAR
        public async Task<Duty> GetUserWithDuty(string secName)
        {
            var duty = await unitOfWork.GetRepository<Duty>().GetAsync(x => x.SecName == secName, i => i.User);
            var map = mapper.Map<Duty>(duty);

            return map;
        }
        public async Task<IdentityResult> CreateServiceAsync(DutyAddDto dutyAddDto)
        {
            var userId = _user.GetLoggedInUserId();
            var userEmail = _user.GetLoggedInEmail();

            if (userId == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // Check if the user already has 6 social records.
            var serviceCount = await unitOfWork.GetRepository<Duty>().CountAsync(s => s.UserId == userId && s.IsActive);

            // Check the user's role
            var isUser = _user.IsInRole("User");

            if (isUser && serviceCount >= 6)
            {
                // Return an IdentityResult indicating that the maximum social records limit has been reached for users with the "User" role.
                return IdentityResult.Failed(new IdentityError { Description = "Maksimum aktif servis sayısı 6'dır. Bu sayıya ulaştınız." });
            }

            var duty = mapper.Map<Duty>(dutyAddDto);
            duty.UserId = userId;
            duty.CreatedBy = userEmail;


            await unitOfWork.GetRepository<Duty>().AddAsync(duty);
            await unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }


        public async Task<List<DutyDto>> GetAllServicesForMains()
        {
            // Retrieve duties from the database based on certain criteria
            var socials = await unitOfWork.GetRepository<Duty>().GetAllAsync(
               s => !s.IsDeleted && s.IsMaın,
               s => s.User
            );

            // Map the retrieved duties to DutyDto using AutoMapper
            var map = mapper.Map<List<DutyDto>>(socials);

            // Return the mapped list of DutyDto
            return map;
        }


        public async Task<List<DutyDto>> GetAllServicesForMain()
        {
            var userId = _user.GetLoggedInUserId();
            var isUser = _user.IsInRole("User");

            if (isUser)
            {
                var socials = await unitOfWork.GetRepository<Duty>().GetAllAsync(s => s.UserId == userId && !s.IsDeleted, s => s.User);
                var map = mapper.Map<List<DutyDto>>(socials);
                return map;
            }
            else
            {
                var socials = await unitOfWork.GetRepository<Duty>().GetAllAsync(x => !x.IsDeleted, u => u.User);
                var map = mapper.Map<List<DutyDto>>(socials);
                return map;
            }
        }

        public async Task<IdentityResult> UpdateServiceAsync(DutyUpdateDto dutyUpdateDto)

        {
            var userEmail = _user.GetLoggedInEmail();

            if (dutyUpdateDto.Id == Guid.Empty)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid Duty ID." });
            }

            // Öncelikle ilgili Duty'yi veritabanından çekiyoruz.
            var existingDuty = await unitOfWork.GetRepository<Duty>().GetByGuidAsync(dutyUpdateDto.Id);
            if (existingDuty == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Duty not found." });
            }

            // Kullanıcının daha önce 6 veya daha fazla görev kaydı oluşturup oluşturmadığını kontrol etmek için CountAsync kullanılır.
            var userId = _user.GetLoggedInUserId();
            if (userId == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }


            var serviceCount = await unitOfWork.GetRepository<Duty>().CountAsync(s => s.UserId == userId && s.IsActive);

            // Check the user's role
            var isUser = _user.IsInRole("User");

            if (isUser && serviceCount >= 6)
            {
                // Return an IdentityResult indicating that the maximum social records limit has been reached for users with the "User" role.
                return IdentityResult.Failed(new IdentityError { Description = "Maksimum aktif servis sayısı 6'dır. Bu sayıya ulaştınız." });
            }

            // Duty'nin özelliklerini güncelliyoruz.
            existingDuty.IsActive = dutyUpdateDto.IsActive;
            existingDuty.IsMaın = dutyUpdateDto.IsMaın;
            existingDuty.ModifiedBy = userEmail;
            existingDuty.ModifiedDate = DateTime.Now;
            dutyUpdateDto.SecName = UniqStr.GuidToRandomName(Guid.NewGuid().ToString(), 6, 8);
            mapper.Map(dutyUpdateDto, existingDuty);

            // UserId'yi mevcut kullanıcının ID'si ile güncelliyoruz.
            existingDuty.UserId = userId;

            // Değişiklikleri kaydediyoruz.
            await unitOfWork.GetRepository<Duty>().UpdateAsync(existingDuty);
            await unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }


        public async Task<bool> DeleteServiceAsync(string secName)
        {
            var duty = await unitOfWork.GetRepository<Duty>().GetAsync(x => x.SecName == secName);

            var userEmail = _user.GetLoggedInEmail();

            if (duty != null)

            {
                duty.IsActive = false;
                duty.IsDeleted = true;
                duty.DeletedDate = DateTime.UtcNow;
                duty.DeletedBy = userEmail;
                await unitOfWork.GetRepository<Duty>().UpdateAsync(duty);
                await unitOfWork.SaveAsync();
                return true; // Return true to indicate success
            }

            return false; // Return false to indicate that no duty was found for the given serviceId

        }
        public async Task<string> HardDeleteServiceAsync(string secName)
        {
            var duty = await unitOfWork.GetRepository<Duty>().GetAsync(x => x.SecName == secName);


            // Önce, sosyal medya kaydını veritabanından tamamen kaldırın (hard delete).
            await unitOfWork.GetRepository<Duty>().DeleteAsync(duty);

            // Veritabanındaki değişiklikleri kaydedin.
            await unitOfWork.SaveAsync();

            return duty.Name; // Başarıyı göstermek için true döndürün

        }

        public async Task<List<DutyDto>> GetDeletedDuties()
        {
            var userId = _user.GetLoggedInUserId();

            if (_user.IsInRole("User"))
            {
                var duties = await unitOfWork.GetRepository<Duty>().GetAllAsync(s => s.UserId == userId && s.IsDeleted, u => u.User);
                var map = mapper.Map<List<DutyDto>>(duties);
                return map;

            }
            else
            {
                var duties = await unitOfWork.GetRepository<Duty>().GetAllAsync(x => x.IsDeleted, u => u.User);
                var map = mapper.Map<List<DutyDto>>(duties);
                return map;
            }
        }



        public async Task<string> UndoDeleteServiceAsync(string secName)
        {
            var duty = await unitOfWork.GetRepository<Duty>().GetAsync(x => x.SecName == secName);

            duty.IsDeleted = false;
            duty.DeletedDate = null;
            duty.DeletedBy = null;
            await unitOfWork.GetRepository<Duty>().UpdateAsync(duty);
            await unitOfWork.SaveAsync();

            return duty.Name;
        }



        // SOSYAL MEDYA ICIN

        public async Task<List<SocialDto>> GetAllMaınSocials()
        {
            var userId = _user.GetLoggedInUserId();
            var isUser = _user.IsInRole("User");

            if (isUser)
            {
                var socials = await unitOfWork.GetRepository<Social>().GetAllAsync(s => s.UserId == userId && !s.IsDeleted, s => s.User);
                var map = mapper.Map<List<SocialDto>>(socials);
                return map;
            }
            else
            {
                var socials = await unitOfWork.GetRepository<Social>().GetAllAsync(x => !x.IsDeleted, u => u.User);
                var map = mapper.Map<List<SocialDto>>(socials);
                return map;
            }

        }
        public async Task<List<SocialDto>> GetMaınPageSocials()
        {

            var socials = await unitOfWork.GetRepository<Social>().GetAllAsync(s => !s.IsDeleted && s.IsMaın && s.IsActive, s => s.User);
            var map = mapper.Map<List<SocialDto>>(socials);
            return map;

        }


        public async Task<List<SocialDto>> GetSocialProfilesForUser(Guid userId)
        {
            // Retrieve active social profiles for the specified user
            var socialProfiles = await unitOfWork.GetRepository<Social>().GetAllAsync(s => s.UserId == userId && s.IsActive == true);

            // Map the Social entities to SocialDto using AutoMapper
            var socialDtoList = mapper.Map<List<SocialDto>>(socialProfiles);

            return socialDtoList;
        }


        public async Task<Social> GetUserWithSocial(string secName)
        {
            var social = await unitOfWork.GetRepository<Social>().GetAsync(x => x.SecName == secName, i => i.User);
            var map = mapper.Map<Social>(social);

            return map;
        }

        public async Task<IdentityResult> CreateSocialAsync(SocialAddDto socialAddDto)
        {
            var userId = _user.GetLoggedInUserId();

            if (userId == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }

            // Check if the user already has 6 social records.
            var socialCount = await unitOfWork.GetRepository<Social>().CountAsync(s => s.UserId == userId && s.IsActive);

            // Check the user's role
            var isUser = _user.IsInRole("User");

            if (isUser && socialCount >= 6)
            {
                // Return an IdentityResult indicating that the maximum social records limit has been reached for users with the "User" role.
                return IdentityResult.Failed(new IdentityError { Description = "Maksimum aktif sosyal medya sayısı 6'dır. Bu sayıya ulaştınız." });
            }
            var social = mapper.Map<Social>(socialAddDto);
            social.UserId = userId;

            await unitOfWork.GetRepository<Social>().AddAsync(social);
            await unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }




        public async Task<IdentityResult> UpdateSocialAsync(SocialUpdateDto socialUpdateDto)
        {
            if (socialUpdateDto.Id == Guid.Empty)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Invalid Social ID." });
            }

            // Öncelikle ilgili Social'i veritabanından çekiyoruz.
            var existingSocial = await unitOfWork.GetRepository<Social>().GetByGuidAsync(socialUpdateDto.Id);
            if (existingSocial == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Social not found." });
            }

            // Social'nin özelliklerini güncelliyoruz.
            existingSocial.IsActive = socialUpdateDto.IsActive;
            mapper.Map(socialUpdateDto, existingSocial); // Dikkat: İki parametreli Map metodu kullanıldı.

            // UserId'yi mevcut kullanıcının ID'si ile güncelliyoruz. Eğer bu adımı istemiyorsanız çıkarabilirsiniz.
            var userId = _user.GetLoggedInUserId();
            if (userId == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found." });
            }
            existingSocial.UserId = userId;

            // Check if the user already has 6 social records.
            var socialCount = await unitOfWork.GetRepository<Social>().CountAsync(s => s.UserId == userId && s.IsActive);

            // Check the user's role
            var isUser = _user.IsInRole("User");

            if (isUser && socialCount >= 6)
            {
                // Return an IdentityResult indicating that the maximum social records limit has been reached for users with the "User" role.
                return IdentityResult.Failed(new IdentityError { Description = "Maksimum aktif sosyal medya sayısı 6'dır. Bu sayıya ulaştınız." });
            }

            // Değişiklikleri kaydediyoruz.
            await unitOfWork.GetRepository<Social>().UpdateAsync(existingSocial);
            await unitOfWork.SaveAsync();

            return IdentityResult.Success;
        }

        public async Task<bool> DeleteSocialAsync(string secName)
        {

            var social = await unitOfWork.GetRepository<Social>().GetAsync(x => x.SecName == secName);


            if (social != null)
            {
                var userEmail = _user.GetLoggedInEmail();

                social.IsActive = false;
                social.IsDeleted = true;
                social.DeletedDate = DateTime.UtcNow;
                social.DeletedBy = userEmail;

                await unitOfWork.SaveAsync();

                return true;
            }

            return false;
        }





        public async Task<string> HardDeleteSocialAsync(string secName)
        {
            var social = await unitOfWork.GetRepository<Social>().GetAsync(x => x.SecName == secName);


            // Önce, sosyal medya kaydını veritabanından tamamen kaldırın (hard delete).
            await unitOfWork.GetRepository<Social>().DeleteAsync(social);

            // Veritabanındaki değişiklikleri kaydedin.
            await unitOfWork.SaveAsync();

            return social.Name; // Başarıyı göstermek için true döndürün

        }


        public async Task<string> UndoDeleteSocialAsync(string secName)
        {
            var email = _user.GetLoggedInEmail();
            var social = await unitOfWork.GetRepository<Social>().GetAsync(x => x.SecName == secName);

            social.IsDeleted = false;
            social.DeletedDate = null;
            social.DeletedBy = null;

            await unitOfWork.GetRepository<Social>().UpdateAsync(social);
            await unitOfWork.SaveAsync();

            return social.Name;
        }

        public async Task<List<SocialDto>> GetDeletedSocials()
        {
            var userId = _user.GetLoggedInUserId();

            if (_user.IsInRole("User"))
            {
                var socials = await unitOfWork.GetRepository<Social>().GetAllAsync(s => s.UserId == userId && s.IsDeleted, u => u.User);
                var map = mapper.Map<List<SocialDto>>(socials);
                return map;

            }
            else
            {
                var socials = await unitOfWork.GetRepository<Social>().GetAllAsync(x => x.IsDeleted, u => u.User);
                var map = mapper.Map<List<SocialDto>>(socials);
                return map;
            }
        }


    }
}
