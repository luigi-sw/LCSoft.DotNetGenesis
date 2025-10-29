using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace __company__.__project__.Application.Logging;

public static class LogConfigurationExtensions
{
    public static WebApplicationBuilder AddLoggingServices(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Logging.AddAdvancedMicrosoftLogging(builder.Configuration, builder.Environment);
        return builder;
    }

    public static ILoggingBuilder AddAdvancedMicrosoftLogging(
        this ILoggingBuilder loggingBuilder,
        IConfiguration configuration,
        IHostEnvironment environment)
    {
        loggingBuilder.ClearProviders();

        loggingBuilder.AddConfiguration(configuration.GetSection("Logging:Microsoft"));

        if (environment.IsDevelopment())
        {
            loggingBuilder.AddSimpleConsole(options =>
            {
                options.SingleLine = true;
                options.TimestampFormat = "HH:mm:ss ";
                options.UseUtcTimestamp = true;
            })
            .AddDebug();
            //loggingBuilder.AddConsole(options =>
            //{
            //    options.FormatterName = "custom";
            //    options.IncludeScopes = true;
            //})
            //.AddDebug();
        }
        else
        {
            loggingBuilder.AddJsonConsole(options =>
            {
                options.IncludeScopes = true;
                options.TimestampFormat = "yyyy-MM-dd HH:mm:ss.fff zzz";
                options.JsonWriterOptions = new JsonWriterOptions { Indented = false };
            });
        }

        loggingBuilder.Services.Configure<LoggerFilterOptions>(options =>
        {
            options.Rules.Add(new LoggerFilterRule(
                providerName: null,
                categoryName: "Microsoft.EntityFrameworkCore",
                logLevel: LogLevel.Warning,
                filter: null));
        });

        return loggingBuilder;
    }
}
