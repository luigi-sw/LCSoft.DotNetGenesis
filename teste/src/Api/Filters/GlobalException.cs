using Microsoft.AspNetCore.Diagnostics;

namespace teste.Api.Filters;

public class GlobalException : IExceptionHandler
{
    private readonly ILogger<GlobalException> logger;
    public GlobalException(ILogger<GlobalException> logger)
    {
        this.logger = logger;
    }
    public ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var exceptionMessage = exception.Message;
        logger.LogError(
            "Error Message: {exceptionMessage}, time of occurrence {time}",
            exceptionMessage, DateTime.UtcNow);
        return ValueTask.FromResult(false);
    }
}