using FluentValidation;
using Microsoft.AspNetCore.Identity;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class UserValidator : AbstractValidator<AppUser>
    {
        private readonly UserManager<AppUser> _userManager;

        public UserValidator(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

            RuleFor(x => x.FirstName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50)
             .WithName("İsim");

            RuleFor(x => x.LastName)
             .NotEmpty()
             .MinimumLength(3)
             .MaximumLength(50)
             .WithName("Soyisim");

            RuleFor(x => x.PhoneNumber)
             .NotEmpty()
             .MinimumLength(11)
             .WithName("Telefon numarası");

            RuleFor(x => x.Email)
         .MustAsync(async (user, email, cancellation) =>
         {
             var existingUser = await _userManager.FindByEmailAsync(email);

             if (existingUser == null)
                 return true; // e-posta adresi kullanılmamış, bu yüzden doğru

             if (user.Id == existingUser.Id)
                 return true; // e-posta adresi güncellenen kullanıcıya ait, bu yüzden doğru

             return false; // e-posta adresi başka bir kullanıcıya ait
         })
         .WithMessage("Bu e-posta adresi zaten kayıtlı.");

        }
    }
}
