using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class PageSeoValidator : AbstractValidator<PageSeo>
    {
        public PageSeoValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(200)
                .WithName("Sayfa İçeriği");
        }
    }
}
