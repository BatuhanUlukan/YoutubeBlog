using FluentValidation;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;

public class ArticleValidator : AbstractValidator<Article>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IArticleService articleService;

    public ArticleValidator(IUnitOfWork unitOfWork, IArticleService articleService)
    {
        this.unitOfWork = unitOfWork;
        this.articleService = articleService;


        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(99999999)
            .WithName("İçerik");

        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(150)
            .WithName("Başlık")
             .CustomAsync(async (title, context, cancellationToken) =>
             {
                 // Ensure you provide both articleSlug and articleId
                 var existingArticle = await articleService.GetArticleWithCategoryNonDeletedAsync(null, title, context.InstanceToValidate.Id);

                 if (existingArticle != null && existingArticle.Id != context.InstanceToValidate.Id)
                 {
                     context.AddFailure("Title", $"Title '{title}' zaten (başlık: {existingArticle.Title}) adlı bir makale tarafından kullanılıyor.");
                 }
             });

        RuleFor(x => x.Slug)
            .MinimumLength(3)
            .MaximumLength(150)
            .WithName("Slug")
            .CustomAsync(async (slug, context, cancellationToken) =>
            {
                // Ensure you provide both articleSlug and articleId
                var existingArticle = await articleService.GetArticleWithCategoryNonDeletedAsync(slug, null, context.InstanceToValidate.Id);

                if (existingArticle != null && existingArticle.Id != context.InstanceToValidate.Id)
                {
                    context.AddFailure("Slug", $"Slug '{slug}' zaten (başlık: {existingArticle.Title}) adlı bir makale tarafından kullanılıyor.");
                }
            });
    }
}
