using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;

namespace __company__.__project__.Application.Configuration;

public static class ApplicationWebAppBuilderExtensions
{
    public static WebApplicationBuilder AddApplication(this WebApplicationBuilder builder) 
    {
        const bool authentication = false;

        builder.Services.AddHttpLogging(logging =>
        {
            logging.LoggingFields =
                HttpLoggingFields.RequestProperties |
                HttpLoggingFields.ResponsePropertiesAndHeaders |
                HttpLoggingFields.RequestHeaders |
                HttpLoggingFields.ResponseHeaders;

            // Headers de requisição úteis para debug
            logging.RequestHeaders.Add("User-Agent");
            logging.RequestHeaders.Add("Accept");
            logging.RequestHeaders.Add("Content-Type");
            logging.RequestHeaders.Add("X-Correlation-ID");

            // Headers de resposta úteis
            logging.ResponseHeaders.Add("Content-Type");
            logging.ResponseHeaders.Add("X-Correlation-ID");

            //logging.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
        });

        builder.Services.AddSession(options =>
        {
            options.Cookie.Domain = "localhost";
            options.IdleTimeout = TimeSpan.FromSeconds(100);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        // 1. Configure Services
        if (authentication)
        {
            builder.Services.AddIdentityConfiguration(builder.Configuration);
        }

        builder.Services.AddResponseCompression();
        builder.Services.AddResponseCaching();
        builder.Services.AddHealthChecks();

        var supportedCultures = new[] { "en", "pt" };

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            options.SetDefaultCulture("en"); // fallback
            options.AddSupportedCultures(supportedCultures);
            options.AddSupportedUICultures(supportedCultures);
        });

        return builder;
    }
}
