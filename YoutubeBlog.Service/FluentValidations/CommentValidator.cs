using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class CommentValidator : AbstractValidator<Comment> // Use ArticleAddDto here
    {
        public CommentValidator()
        {


            RuleFor(x => x.Text)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(900)
                .WithName("İçerik");

        }
    }
}
