using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class FactValidator : AbstractValidator<Fact> // Use ArticleAddDto here
    {
        public FactValidator()
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
