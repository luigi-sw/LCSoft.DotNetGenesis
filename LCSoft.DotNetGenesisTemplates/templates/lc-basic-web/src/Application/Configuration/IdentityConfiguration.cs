using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using __company__.__project__.Application.Extensions;

namespace __company__.__project__.Application.Configuration;

internal static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        });

        services.AddAuthentication(o =>
        {
            o.DefaultScheme = IdentityConstants.ApplicationScheme;
            o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
        })
       .AddIdentityCookies(o => { });

       services.AddAuthorization();

        services.AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = true;
            options.User.RequireUniqueEmail = true;
            //options.Password.RequiredLength = 8;
            //options.Password.RequireNonAlphanumeric = true;
            //options.Password.RequireLowercase = false;
            //options.Password.RequireUppercase = true;
            //options.Password.RequireDigit = true;
        }).AddRoles<IdentityRole>()
          //.AddSignInManager<SignInManager<AppUser>>()
          //.AddUserManager<UserManager<AppUser>>()
          .AddErrorDescriber<AppErrorDescriber>()
          .AddRoleManager<RoleManager<IdentityRole>>()
          //.AddEntityFrameworkStores<DbContext>()
          .AddDefaultTokenProviders();

        return services;
    }
}
