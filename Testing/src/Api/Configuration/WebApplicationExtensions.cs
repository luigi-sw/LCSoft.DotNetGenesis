using MyCompany.MyProject.Application.Configuration;

namespace MyCompany.MyProject.Api.Extensions;

public static class WebApplicationExtensions
{
    public static WebApplication UseApiMiddleware(this WebApplication app)
    {
        app.UseDocumentationMiddleware();
        app.UseApplicationMiddleware();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        return app;
    }
    private static WebApplication UseDocumentationMiddleware(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        return app;
    }
}
