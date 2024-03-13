using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;

namespace YoutubeBlog.Service.FluentValidations
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ICategoryService categoryService;

        public CategoryValidator(IUnitOfWork unitOfWork, ICategoryService categoryService)
        {
            this.unitOfWork = unitOfWork;
            this.categoryService = categoryService;

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Kategori Adı boş olamaz.")
                .NotNull().WithMessage("Kategori Adı null olamaz.")
                .MinimumLength(3).WithMessage("Kategori Adı en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Kategori Adı en fazla 100 karakter olmalıdır.");

            // Düzeltme
            RuleFor(x => x.Name)
              .CustomAsync(async (name, context, cancellationToken) =>
              {
                  if (context.InstanceToValidate.Id != Guid.Empty)
                  {
                      var existingCategory = await categoryService.GetCategoryByGuid(name);

                      if (existingCategory != null && existingCategory.Id != context.InstanceToValidate.Id)
                      {
                          context.AddFailure("Name", $"Kategori adı '{name}' zaten kullanılıyor.");
                      }
                  }
              });


        }
    }
}
