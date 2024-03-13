using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class AboutValidator : AbstractValidator<About> // Use ArticleAddDto here
    {
        public AboutValidator()
        {


            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(900)
                .WithName("İçerik");

        }
    }
}
