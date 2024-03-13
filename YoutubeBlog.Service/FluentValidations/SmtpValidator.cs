using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class SmtpValidator : AbstractValidator<SmtpSetting>
    {
        public SmtpValidator()
        {


            RuleFor(x => x.Username)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(900)
                .WithName("KullanıcıAdı");

        }
    }
}
