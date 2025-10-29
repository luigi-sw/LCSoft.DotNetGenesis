using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace __company__.__project__.Application.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var start = DateTime.UtcNow;

        _logger.LogTrace("Request started: {Method} {Path}",
            context.Request.Method, context.Request.Path);

        await _next(context);

        var duration = DateTime.UtcNow - start;

        _logger.LogTrace("Request completed: {Method} {Path} {StatusCode} in {Duration}ms",
            context.Request.Method, context.Request.Path, context.Response.StatusCode, duration.TotalMilliseconds);
    }
}