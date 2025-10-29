using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using MyCompany.MyProject.Application.Middleware;

namespace MyCompany.MyProject.Application.Configuration;

public static class WebApplicationExtensions
{
    public static WebApplication UseApplicationMiddleware(this WebApplication app)
    {
        app.UseSecurityMiddleware();
        app.UseLoggingMiddleware();
        app.UseRoutingMiddleware();

        //ADD HealthCheck
        //app.UseMonitoringMiddleware();

        return app;
    }

    private static WebApplication UseSecurityMiddleware(this WebApplication app)
    {
        app.UseForwardedHeaders(new ForwardedHeadersOptions
        {
            ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        });

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        if (!app.Environment.IsDevelopment())
        {
            app.UseResponseCompression();
        }
        app.UseCors();
        app.UseRateLimiter();

        return app;
    }

    private static WebApplication UseLoggingMiddleware(this WebApplication app)
    {
        app.UseMiddleware<RequestLoggingMiddleware>();
        app.UseMiddleware<CorrelationIdMiddleware>();

        return app;
    }

    private static WebApplication UseRoutingMiddleware(this WebApplication app)
    {
        app.UseRouting();
        app.UseResponseCaching();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        return app;
    }

    private static WebApplication UseMonitoringMiddleware(this WebApplication app)
    {
        var healthChecks = app.MapGroup("");

        healthChecks
            .CacheOutput("HealthChecks")
            .WithRequestTimeout("HealthChecks");

        healthChecks.MapHealthChecks("/health", new HealthCheckOptions
        {
            Predicate = _ => true,
            //ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            ResponseWriter = async (context, report) =>
            {
                context.Response.ContentType = "application/json";
                var response = new
                {
                    status = report.Status.ToString(),
                    checks = report.Entries.Select(entry => new
                    {
                        name = entry.Key,
                        status = entry.Value.Status.ToString(),
                        exception = entry.Value.Exception?.Message,
                        duration = entry.Value.Duration.ToString()
                    }),
                    duration = report.TotalDuration
                };
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        });//.RequireAuthorization();

        healthChecks.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = check => check.Tags.Contains("ready")
        });//.RequireAuthorization();
        //app.MapHealthChecks("/health/ready", new HealthCheckOptions
        //{
        //    Predicate = check => check.Tags.Contains("db") || check.Tags.Contains("cache") // Critical checks
        //});

        //app.MapHealthChecks("/health/live", new HealthCheckOptions
        //{
        //    Predicate = check => check.Tags.Contains("live") // Only basic checks
        //});
        healthChecks.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = _ => false
        });//.RequireAuthorization();


        app.UseRequestTimeouts();
        app.UseOutputCache();
        return app;
    }
}
