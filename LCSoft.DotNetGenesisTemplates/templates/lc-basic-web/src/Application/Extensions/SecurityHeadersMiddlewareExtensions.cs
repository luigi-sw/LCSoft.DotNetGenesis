using Microsoft.AspNetCore.Builder;
using __company__.__project__.Application.Models;

namespace __company__.__project__.Application.Extensions;

public static class SecurityHeadersMiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityHeaders(
        this IApplicationBuilder app,
        Action<SecurityHeaderOptions>? configureOptions = null)
    {
        var options = new SecurityHeaderOptions();
        configureOptions?.Invoke(options);

        app.Use(async (context, next) =>
        {
            if (options.AddXContentTypeOptions)
                context.Response.Headers["X-Content-Type-Options"] = "nosniff";

            if (options.AddXFrameOptions)
                context.Response.Headers["X-Frame-Options"] = "DENY";

            if (options.AddXXssProtection)
                context.Response.Headers["X-XSS-Protection"] = "1; mode=block";

            if (!string.IsNullOrWhiteSpace(options.ReferrerPolicy))
                context.Response.Headers["Referrer-Policy"] = options.ReferrerPolicy;

            if (!string.IsNullOrWhiteSpace(options.ContentSecurityPolicy))
                context.Response.Headers["Content-Security-Policy"] = options.ContentSecurityPolicy;


            if (options.UseHsts && context.Request.IsHttps)
            {
                //        context.Response.Headers["Content-Security-Policy"] =
                //"default-src 'self'; " +
                //"script-src 'self' 'unsafe-inline'; " +
                //"style-src 'self' 'unsafe-inline'; " +
                //"img-src 'self' data:; " +
                //"object-src 'none'; " +
                //"frame-ancestors 'none'; " +
                //"base-uri 'self'; " +
                //"form-action 'self'";

                context.Response.Headers["Strict-Transport-Security"] =
                    $"max-age={options.HstsMaxAgeDays * 24 * 60 * 60}; includeSubDomains; preload";
            }

            await next();
        });

        return app;
    }
}

