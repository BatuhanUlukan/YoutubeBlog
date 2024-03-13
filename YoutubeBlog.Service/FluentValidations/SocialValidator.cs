using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class SocialValidator : AbstractValidator<Social>
    {
        public SocialValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Sosyal Medya Adı");
        }
    }
}
