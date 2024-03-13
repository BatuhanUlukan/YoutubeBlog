using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net.Mail;
using System.Reflection;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Service.FluentValidations;
using YoutubeBlog.Service.Helpers.Images;
using YoutubeBlog.Service.Services.Abstractions;
using YoutubeBlog.Service.Services.Concrete;

namespace YoutubeBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IDashbordService, DashboardService>();
            services.AddScoped<IHeadquarterService, HeadquarterService>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IPageSeoService, PageSeoService>();
            services.AddScoped<IPortfolioService, PortfolioService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISmtpService, SmtpService>();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<SmtpClient>();
            services.AddSingleton<SmtpClient>();



            services.AddScoped<IPageSeoService, PageSeoService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(assembly);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    });
            });

            services.AddControllersWithViews()
           .AddFluentValidation(opt =>
           {
               opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<SmtpValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<PortfolioValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<AboutValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<CategoryValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<ClientValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<CommentValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<DutyValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<FactValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<HeadquarterValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<LogoValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<MessageValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<PageSeoValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<PortfolioValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<SliderValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<SocialValidator>();
               opt.RegisterValidatorsFromAssemblyContaining<UserValidator>();

               opt.DisableDataAnnotationsValidation = true;
               opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
           });

            return services;
        }
    }
}
