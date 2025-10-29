using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace MyCompany.MyProject.Application.HealthCheck;

public class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Implement your custom health check logic here
        var isHealthy = true; // Your health check logic

        return Task.FromResult(
            isHealthy ? HealthCheckResult.Healthy("Custom check passed")
                     : HealthCheckResult.Unhealthy("Custom check failed"));
    }
}