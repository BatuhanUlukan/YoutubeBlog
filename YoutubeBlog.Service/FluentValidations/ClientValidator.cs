using FluentValidation;
using System.Threading;
using System.Xml.Linq;
using YoutubeBlog.Data.UnitOfWorks;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;

namespace YoutubeBlog.Service.FluentValidations
{
    public class ClientValidator : AbstractValidator<Client>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IClientService clientService;

        public ClientValidator(IUnitOfWork unitOfWork, IClientService clientService)
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(100)
                .WithName("Client Adı");

            // Düzeltme
            RuleFor(x => x.Name)
                  .CustomAsync(async (name, context, cancellationToken) =>
                  {
                      if (context.InstanceToValidate.Id != Guid.Empty)
                      {
                          var existingClient = await clientService.GetClient(name);

                          if (existingClient != null && existingClient.Id != context.InstanceToValidate.Id)
                          {
                              context.AddFailure("Name", $"Refarans adı '{name}' zaten kullanılıyor.");
                          }
                      }
                  });
        }
    }
}
