using FluentValidation;
using YoutubeBlog.Entity.Entities;

namespace YoutubeBlog.Service.FluentValidations
{
    public class HeadquarterValidator : AbstractValidator<Headquarter>
    {
        public HeadquarterValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Ofis Adı");

            RuleFor(c => c.Address)
                .NotEmpty()
                .NotNull()
                .WithName("Adres");

            RuleFor(c => c.AddressLink)
                .NotEmpty()
                .NotNull()
                .WithName("Adres Linki");

            RuleFor(c => c.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .WithName("Telefon Numarası");

            RuleFor(c => c.Email)
                .NotEmpty()
                .NotNull()
                .EmailAddress()
                .WithName("Email");

            RuleFor(c => c.Location)
                .NotEmpty()
                .NotNull()
                .WithName("Adres Koordinatları");
        }
    }
}
