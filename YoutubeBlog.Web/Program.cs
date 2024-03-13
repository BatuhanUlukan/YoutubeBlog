using Microsoft.AspNetCore.Identity;
using NToastNotify;
using YoutubeBlog.Data.Context;
using YoutubeBlog.Data.Extensions;
using YoutubeBlog.Entity.Entities;
using YoutubeBlog.Service.Describers;
using YoutubeBlog.Service.Extensions;
using YoutubeBlog.Web.Filters.ArticleVisitors;
using YoutubeBlog.Web.Filters.PortfolioVisitors;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.LoadDataLayerExtension(configuration);
builder.Services.LoadServiceLayerExtension(configuration);
builder.Services.AddSession();


// Add services to the container.
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ArticleVisitorFilter>();
    opt.Filters.Add<PortfolioVisitorFilter>();
})
    .AddNToastNotifyToastr(new ToastrOptions()
    {
        PositionClass = ToastPositions.TopRight,
        TimeOut = 3000,
    })
    .AddRazorRuntimeCompilation();



builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
})
    .AddRoleManager<RoleManager<AppRole>>()
    .AddErrorDescriber<CustomIdentityErrorDescriber>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/admin/login");
    config.LogoutPath = new PathString("/admin/logout");
    config.Cookie = new CookieBuilder
    {
        Name = "YoutubeBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //Always 
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/admin/access-denied");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseNToastNotify();
app.UseHttpsRedirection();
app.UseSession();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithRedirects("/Error/{0}");
app.UseExceptionHandler("/Home/Error");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areaRoute",
      pattern: "{area:exists}/{controller=Base}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute("ElFinderForCkEditor", "/elfinder", new { area = "Admin", controller = "ElFinder", action = "Index" });
    endpoints.MapControllerRoute("ElFinderFileManager", "/elfinder/file-manager", new { area = "Admin", controller = "ElFinder", action = "FileManager" });
    endpoints.MapControllerRoute("ElFinderConnector", "/elfinder/connector", new { area = "Admin", controller = "ElFinder", action = "Connector" });
    endpoints.MapControllerRoute("ElFinderThumbnail", "/elfinder/thumb/{hash}", new { area = "Admin", controller = "ElFinder", action = "Thumbs" });
});

app.Run();