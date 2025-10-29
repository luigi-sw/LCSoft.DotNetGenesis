using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace teste.Application.HealthCheck;

public static class HealthCheckConfigurationExtensions
{
    public static IServiceCollection AddMonitoringServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRequestTimeouts();
        services.AddOutputCache();

        services.AddRequestTimeouts(
        configure: static timeouts =>
            timeouts.AddPolicy("HealthChecks", TimeSpan.FromSeconds(5)));

        services.AddOutputCache(
            configureOptions: static caching =>
                caching.AddPolicy("HealthChecks",
                build: static policy => policy.Expire(TimeSpan.FromSeconds(10))));

        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), tags: ["live"])
            //.AddSqlServer(
            //    configuration.GetConnectionString("DefaultConnection")!,
            //    name: "database",
            //    failureStatus: HealthStatus.Unhealthy,s
            //    timeout: TimeSpan.FromSeconds(30),
            //    tags: new[] { "db", "critical", "ready" })
            .AddCheck<CustomHealthCheck>("custom", tags: ["ready"]);

        services.AddSingleton<IHealthCheck, CustomHealthCheck>();

        return services;
    }
}
