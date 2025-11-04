using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using __company__.__project__.Web.Extensions;
using __company__.__project__.Web.Filter;
using System.Reflection;

namespace __company__.__project__.Web.Configuration;

public static class AddWebProjectExtensions
{
    public static WebApplicationBuilder AddWebProject(this WebApplicationBuilder builder)
    {
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.AddControllersWithViews(options =>
        {
            var sp = builder.Services.BuildServiceProvider();
            var localizer = sp.GetService<IStringLocalizerFactory>()!
                              .Create("ModelBindingMessages", Assembly.GetExecutingAssembly().GetName().Name!);

            options.UseCustomModelBindingMessages(localizer);
            options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            options.Filters.Add<ValidationFilter>();
        })
        .AddViewLocalization()
        .AddDataAnnotationsLocalization();

        //builder.Services.AddRazorPages();           // if using Razor Pages

        builder.AddApplication();

        return builder;
    }
}
