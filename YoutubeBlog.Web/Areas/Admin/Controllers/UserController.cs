using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System.Security.Claims;
using YoutubeBlog.Entity.DTOs.Duties;
using YoutubeBlog.Entity.DTOs.Socials;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Web.Consts;
using YoutubeBlog.Web.ResultMessages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IValidator<AppUser> uservalidator;
        private readonly IValidator<Social> socialvalidator;
        private readonly IValidator<Duty> dutyvalidator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public UserController(IUserService userService, IValidator<Social> socialvalidator, IValidator<AppUser> uservalidator, IValidator<Duty> dutyvalidator, IToastNotification toast, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this.userService = userService;
            this.uservalidator = uservalidator;
            this.dutyvalidator = dutyvalidator;
            this.socialvalidator = socialvalidator;
            this.toast = toast;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        [Route("users")]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Users()
        {
            var result = await userService.GetAllUsersWithRoleAsync();

            return View(result);
        }

        [Route("add-user")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDto { Roles = roles });
        }

        [Route("add-user")]
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            // Check for null DTO.
            if (userAddDto == null)
            {
                return BadRequest("User data is not provided.");
            }

            var roles = await userService.GetAllRolesAsync();

            // Map and validate the user object
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await uservalidator.ValidateAsync(map);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(new UserAddDto { Roles = roles });
            }

            // Attempt to create the user.
            var result = await userService.CreateUserAsync(userAddDto);
            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Users", "User", new { Area = "Admin" });
            }

            // If user creation failed, add errors to model state and return the view.
            result.AddToIdentityModelState(this.ModelState);
            return View(new UserAddDto { Roles = roles });
        }

        [Route("update-user/{user}")]
        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Update(string user)
        {
            var appUser = await userService.GetAppUserAsync(user);
            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDto>(appUser);

            // Explicitly set the properties after mapping.
            map.Roles = roles;
            map.UserImages = appUser.UserImagess;

            return View(map);
        }

        [Route("update-user/{user}")]
        [HttpPost]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin},{RoleConsts.User}")]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userService.GetAppUserAsync(userUpdateDto.SecName);

            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();

                var map = mapper.Map(userUpdateDto, user);
                var validation = await uservalidator.ValidateAsync(map);

                if (validation.IsValid)
                {
                    user.UserName = userUpdateDto.Email;
                    user.About = userUpdateDto.About;
                    user.SecurityStamp = Guid.NewGuid().ToString();
                    var userRole = await userService.GetUserRoleAsync(user);
                    var result = await userService.UpdateUserAsync(userUpdateDto);
                    if (result.Succeeded)
                    {
                        toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });

                        // Check if the logged-in user has the role "User"
                        if (userRole != "User")
                        {
                            // Redirect to the home page for users
                            return RedirectToAction("ABase", "Home", new { area = "Admin" });
                        }
                        else
                        {
                            // Redirect to the Users page for admins and superadmins
                            return RedirectToAction("Users", "User", new { Area = "Admin" });
                        }


                    }
                    else
                    {
                        result.AddToIdentityModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
                else
                {
                    validation.AddToModelState(this.ModelState);
                    return View(new UserUpdateDto { Roles = roles });
                }

            }
            return NotFound();
        }

        [Route("hard-delete-user/{user}")] // Silinmiş Görevleri listeleme için route belirleme
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}")]
        public async Task<IActionResult> Delete(string user)
        {
            var result = await userService.DeleteUserAsync(user);

            if (result.identityResult.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.User.Delete(result.email), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Users", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }




        //DUTIES

        [HttpGet]
        [Route("duties")] // Görevleri listeleme için route belirleme
        public async Task<IActionResult> Duties()
        {
            var result = await userService.GetAllServicesForMain();

            return View(result);
        }

        [HttpGet]
        [Route("add-duty")] // Yeni bir Görev eklemek için route belirleme
        public IActionResult AddDuty()
        {
            return View();
        }

        [HttpPost]
        [Route("add-duty")] // Yeni bir Görev eklemek için route belirleme
        public async Task<IActionResult> AddDuty(DutyAddDto dutyAddDto)
        {
            if (dutyAddDto == null)
            {
                return BadRequest("Duty data is not provided.");
            }

            if (!ModelState.IsValid)
            {
                return View(dutyAddDto);
            }

            var map = mapper.Map<Duty>(dutyAddDto);
            var validation = await dutyvalidator.ValidateAsync(map);

            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(dutyAddDto);
            }

            var result = await userService.CreateServiceAsync(dutyAddDto);

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.Duty.Add(dutyAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Duties", "User", new { Area = "Admin" });
            }
            else
            {
                // Display the error message in a toast message.
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                toast.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Error" });
                return RedirectToAction("Duties", "User", new { Area = "Admin" });
            }

        }

        [HttpGet]
        [Route("update-duty/{secName}")] // Görev güncelleme için route belirleme
        public async Task<IActionResult> UpdateDuty(string secName)
        {
            if (secName == null)
            {
                return NotFound("Invalid Duty ID.");
            }

            var existingDuty = await userService.GetUserWithDuty(secName);
            if (existingDuty == null)
            {
                return NotFound("Duty not found.");
            }

            var dutyUpdateDto = mapper.Map<DutyUpdateDto>(existingDuty);
            return View(dutyUpdateDto);
        }

        [HttpPost]
        [Route("update-duty/{secName}")] // Görev güncelleme için route belirleme
        public async Task<IActionResult> UpdateDuty(DutyUpdateDto dutyUpdateDto)
        {
            if (dutyUpdateDto == null)
            {
                return BadRequest("Duty data is not provided.");
            }

            if (!ModelState.IsValid)
            {
                return View(dutyUpdateDto);
            }

            var map = mapper.Map<Duty>(dutyUpdateDto);
            var validation = await dutyvalidator.ValidateAsync(map);

            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(dutyUpdateDto);
            }

            var result = await userService.UpdateServiceAsync(dutyUpdateDto);

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.Duty.Update(dutyUpdateDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Duties", "User", new { Area = "Admin" });
            }
            else
            {
                // Display the error message in a toast message.
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                toast.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Error" });
                return RedirectToAction("Duties", "User", new { Area = "Admin" });
            }
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        [Route("deleted-duties")] // Silinmiş Görevleri listeleme için route belirleme
        public async Task<IActionResult> DeletedDuties()
        {
            var articles = await userService.GetDeletedDuties();
            return View(articles);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        [Route("undo-delete-duty/{secName}")] // Silinmiş Görevi geri alma için route belirleme
        public async Task<IActionResult> UndoDeleteDuty(string secName)
        {
            var duty = await userService.UndoDeleteServiceAsync(secName);
            toast.AddSuccessToastMessage(Messages.Duty.UndoDelete(duty), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("DeletedDuties", "User", new { Area = "Admin" });
        }

        [Route("hard-delete-duty/{secName}")] // Silinmiş Görevi geri alma için route belirleme
        public async Task<IActionResult> HardDeleteDuty(string secName)
        {
            var duty = await userService.HardDeleteServiceAsync(secName);
            toast.AddSuccessToastMessage(Messages.Duty.Delete(duty), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("DeletedDuties", "User", new { Area = "Admin" });
        }

        [Route("delete-duty/{secName}")] // Görev silme için route belirleme
        public async Task<IActionResult> DeleteDuty(string secName)
        {
            var dutyName = await userService.GetUserWithDuty(secName);
            var deletionSuccessful = await userService.DeleteServiceAsync(secName);

            if (deletionSuccessful)
            {
                toast.AddSuccessToastMessage(Messages.Duty.Delete(dutyName.Name), new ToastrOptions { Title = "İşlem Başarılı" });
            }
            else
            {
                toast.AddErrorToastMessage(Messages.Duty.Delete(dutyName.Name), new ToastrOptions { Title = "İşlem Başarısız" });
            }

            return RedirectToAction("Duties", "User", new { Area = "Admin" });
        }










        //Socials

        [HttpGet]
        [Route("socials")] // Social'ları listeleme için route belirleme
        public async Task<IActionResult> Socials()
        {
            var result = await userService.GetAllMaınSocials();

            return View(result);
        }
        [HttpGet]
        [Route("add-social")] // Yeni bir Social eklemek için route belirleme

        public IActionResult AddSocial()
        {
            return View();
        }
        [HttpPost]
        [Route("add-social")] // Yeni bir Social eklemek için route belirleme
        public async Task<IActionResult> AddSocial(SocialAddDto socialAddDto)
        {
            if (socialAddDto == null)
            {
                return BadRequest("Social data is not provided.");
            }

            if (!ModelState.IsValid)
            {
                return View(socialAddDto);
            }

            var map = mapper.Map<Social>(socialAddDto);
            var validation = await socialvalidator.ValidateAsync(map);

            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(socialAddDto);
            }

            var result = await userService.CreateSocialAsync(socialAddDto);

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.Social.Add(socialAddDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Socials", "User", new { Area = "Admin" });
            }
            else
            {

                // Display the error message in a toast message.
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                toast.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Error" });

                return RedirectToAction("Socials", "User", new { Area = "Admin" });
            }
        }

        [HttpGet]
        [Route("update-social/{secName}")] // Social güncelleme için route belirleme
        public async Task<IActionResult> UpdateSocial(string secName)
        {
            if (secName == null)
            {
                return NotFound("Invalid Social ID.");
            }

            var existingSocial = await userService.GetUserWithSocial(secName);
            if (existingSocial == null)
            {
                return NotFound("Social not found.");
            }

            var socialUpdateDto = mapper.Map<SocialUpdateDto>(existingSocial);
            return View(socialUpdateDto);
        }

        [HttpPost]
        [Route("update-social/{secName}")] // Social güncelleme için route belirleme
        public async Task<IActionResult> UpdateSocial(SocialUpdateDto socialUpdateDto)
        {
            if (socialUpdateDto == null)
            {
                return BadRequest("Social data is not provided.");
            }

            if (!ModelState.IsValid)
            {
                return View(socialUpdateDto);
            }

            var map = mapper.Map<Social>(socialUpdateDto);
            var validation = await socialvalidator.ValidateAsync(map);

            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(socialUpdateDto);
            }

            var result = await userService.UpdateSocialAsync(socialUpdateDto);

            if (result.Succeeded)
            {
                toast.AddSuccessToastMessage(Messages.Social.Update(socialUpdateDto.Name), new ToastrOptions { Title = "İşlem Başarılı" });
                return RedirectToAction("Socials", "User", new { Area = "Admin" });
            }
            else
            {

                // Display the error message in a toast message.
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                toast.AddErrorToastMessage(errorMessage, new ToastrOptions { Title = "Error" });
                return RedirectToAction("Socials", "User", new { Area = "Admin" });
            }

        }

        [Route("delete-social/{secName}")]
        public async Task<IActionResult> DeleteSocial(string secName)
        {
            var socialName = await userService.GetUserWithSocial(secName);
            var deletionSuccessful = await userService.DeleteSocialAsync(secName);

            if (deletionSuccessful)
            {
                toast.AddSuccessToastMessage(Messages.Social.Delete(socialName.Name), new ToastrOptions { Title = "İşlem Başarılı" });
            }
            else
            {
                toast.AddErrorToastMessage(Messages.Social.Delete(socialName.Name), new ToastrOptions { Title = "İşlem Başarısız" });
            }

            return RedirectToAction("Socials", "User", new { Area = "Admin" });
        }

        [HttpGet]
        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        [Route("deleted-social")] // Silinmiş Social'ları listeleme için route belirleme

        public async Task<IActionResult> DeletedSocials()
        {
            var articles = await userService.GetDeletedSocials();
            return View(articles);
        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        [Route("undodelete-social/{secName}")] // Silinmiş Social'ı geri alma için route belirleme
        public async Task<IActionResult> UndoDeleteSocial(string secName)
        {
            var social = await userService.UndoDeleteSocialAsync(secName);
            toast.AddSuccessToastMessage(Messages.Social.UndoDelete(social), new ToastrOptions() { Title = "İşlem Başarılı" });
            return RedirectToAction("DeletedSocials", "User", new { Area = "Admin" });

        }

        [Authorize(Roles = $"{RoleConsts.Superadmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
        [Route("harddelete-social/{secName}")] // Silinmiş Social'ı geri alma için route belirleme
        public async Task<IActionResult> HardDeleteSocial(string secName)
        {
            var social = await userService.HardDeleteSocialAsync(secName);
            toast.AddSuccessToastMessage(Messages.Social.Delete(social), new ToastrOptions { Title = "İşlem Başarılı" });
            return RedirectToAction("DeletedSocials", "User", new { Area = "Admin" });
        }
    }
}


