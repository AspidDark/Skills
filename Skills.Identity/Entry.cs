using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skills.Identity.Data;
using Skills.Identity.Models;

namespace Skills.Identity;

public static class Entry
{
    public static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("IdentityDb")));

        services.AddDatabaseDeveloperPageExceptionFilter();

        //Видимо дефолт надо убрать
        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        //https://metanit.com/sharp/aspnet5/16.5.php
        //+Settings change try
        //services.AddIdentity<IdentityUser, IdentityRole>(config => {
        //    config.Password.RequiredLength = 4;
        //    config.SignIn.RequireConfirmedEmail = true;
        //}).AddEntityFrameworkStores<ApplicationDbContext>()
        //.AddDefaultTokenProviders().AddClaimsPrincipalFactory<>();
        //-Settings change try

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddControllersWithViews();
        services.AddRazorPages();

        return services;
    }
}
