using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using __company__.__project__.Application.Extensions;
using __company__.__project__.Application.Middleware;
using __company__.__project__.Application.Models;

namespace __company__.__project__.Application.Configuration;

public static class ApplicationWebApplicationExtensions
{
    public static WebApplication UseApplication(this WebApplication app)
    {
        const bool authentication = false;
        // -Usuário acessando com Accept - Language: pt - BR → mensagens em português.
        // - Usuário acessando com Accept - Language: en - US → mensagens em inglês.
        //var supportedCultures = new[] { "en-US", "pt-BR" };
        //var localizationOptions = new RequestLocalizationOptions()
        //    .SetDefaultCulture("en-US")
        //    .AddSupportedCultures(supportedCultures)
        //    .AddSupportedUICultures(supportedCultures);

        var securityHeaderOptions = app.Configuration
                                       .GetSection("SecurityHeaders")
                                       .Get<SecurityHeaderOptions>();

        app.UseStatusCodePagesWithReExecute("/Error/{0}");
        //app.UseStatusCodePagesWithRedirects("/Error/{0}");

        app.UseHttpsRedirection();

        app.UseSecurityHeaders(opt =>
        {
            opt.ContentSecurityPolicy = securityHeaderOptions!.ContentSecurityPolicy;
            opt.ReferrerPolicy = securityHeaderOptions.ReferrerPolicy;
            opt.UseHsts = securityHeaderOptions.UseHsts;
            opt.HstsMaxAgeDays = securityHeaderOptions.HstsMaxAgeDays;
            opt.AddXContentTypeOptions = securityHeaderOptions.AddXContentTypeOptions;
            opt.AddXFrameOptions = securityHeaderOptions.AddXFrameOptions;
            opt.AddXXssProtection = securityHeaderOptions.AddXXssProtection;
        });

        //app.UseSecurityHeaders(opt =>
        //{
        //    opt.ContentSecurityPolicy =
        //        "default-src 'self'; script-src 'self'; style-src 'self'; img-src 'self' data:;";
        //    opt.ReferrerPolicy = "strict-origin-when-cross-origin";
        //    opt.HstsMaxAgeDays = 730;
        //});

        //app.UseRequestLocalization(localizationOptions);
        app.UseRequestLocalization();

        app.UseHttpLogging();

        app.UseMiddleware<CorrelationIdMiddleware>();
        //app.UseMiddleware<RequestTracingMiddleware>();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseResponseCompression();
        app.UseResponseCaching();

        if (authentication)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        app.UseSession();

        return app;
    }
}
