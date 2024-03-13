using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class LogoValidator : AbstractValidator<Logo>
    {
        public LogoValidator()
        {
            RuleFor(c => c.Slug)
                .NotEmpty()
                .NotNull()
                .WithName("Slug");

            RuleFor(c => c.Title)
                .NotEmpty()
                .NotNull()
                .WithName("Logo Adı");


        }
    }
}
