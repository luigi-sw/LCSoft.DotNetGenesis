using __company__.__project__.Application.Configuration;

namespace __company__.__project__.Web.Configuration;

public static class WebApplicationExtensions
{
    public static WebApplication UseWebProject(this WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }
        else
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseApplication();

        //app.MapRazorPages();              // Razor Pages
        app.MapDefaultControllerRoute().WithStaticAssets();  // MVC default route
        // ou
        //app.MapControllerRoute(
        //    name: "default",
        //    pattern: "{controller=Home}/{action=Index}/{id?}")
        //    .WithStaticAssets();

        return app;
    }
}
