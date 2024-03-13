

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using YoutubeBlog.Entity.DTOs.Users;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Web.Models;
using static YoutubeBlog.Web.ResultMessages.Messages;

namespace YoutubeBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [Route("admin/login")]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [Route("admin/login")]
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginDto.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginDto.Password, userLoginDto.RememberMe, false);
                    if (result.Succeeded)
                    {

                        return RedirectToAction("ABase", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Şifreniz yanlış.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Böyle bir kullanıcı bulunamadı.");
                }
            }

            // ModelState geçerli değilse, hata mesajlarıyla birlikte view'ı tekrar göster
            return View(userLoginDto);
        }

        private class ErrorModelDTO
        {
            public string EmailError { get; set; }
            public string PasswordError { get; set; }
        }


        [AllowAnonymous]
        [Route("hlogin")]
        [HttpPost]
        public async Task<IActionResult> HeadLogin(HeaderModel headerModel)
        {
            if (ModelState.IsValid)
            {
                HeaderModel errorModel = new HeaderModel();

                if (headerModel.UserLogin.Email != null)
                {
                    var user = await userManager.FindByEmailAsync(headerModel.UserLogin.Email);

                    if (user != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, headerModel.UserLogin.Password, headerModel.UserLogin.RememberMe, false);

                        if (result.Succeeded)
                        {
                            // Add Toastify notification for successful login
                            TempData["successMessage"] = "Giriş Başarılı.";

                            return RedirectToAction("Index", "Base");
                        }
                        else
                        {
                            headerModel.PasswordError = "Şifreniz yanlış.";
                        }
                    }
                    else
                    {
                        headerModel.EmailError = "Kullanıcı bulunamadı.";
                    }
                }

                TempData["errorModel"] = JsonSerializer.Serialize(headerModel);
            }

            // Redirect to "Index" action only if there is an error
            return RedirectToAction("Index", "Base");
        }


        [Authorize]
        [Route("admin/logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth", new { Area = "Admin" });
        }

        [Authorize]
        [Route("admin/hlogout")]
        [HttpGet]
        public async Task<IActionResult> HeadLogout()
        {
            await signInManager.SignOutAsync();

            // Add Toastify notification for successful exit
            TempData["exitMessage"] = "Cıkış Başarılı.";

            return RedirectToAction("Index", "Base");

        }

        [Authorize]
        [Route("admin/access-denied")]
        [HttpGet]
        public async Task<IActionResult> AccessDenied()
        {
            return View();
        }
    }
}
