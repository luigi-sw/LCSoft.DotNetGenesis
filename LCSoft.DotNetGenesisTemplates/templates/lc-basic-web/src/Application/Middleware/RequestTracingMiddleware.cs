using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace __company__.__project__.Application.Middleware;

public class RequestTracingMiddleware
{
    private readonly RequestDelegate _next;
    private const string RequestIdHeader = "X-Request-ID";
    private const string TraceIdHeader = "X-Trace-ID";

    public RequestTracingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ILogger<RequestTracingMiddleware> logger)
    {
        var requestId = context.Request.Headers[RequestIdHeader].FirstOrDefault() ?? Guid.NewGuid().ToString();
        var traceId = context.Request.Headers[TraceIdHeader].FirstOrDefault() ?? Guid.NewGuid().ToString();

        context.Items[RequestIdHeader] = requestId;
        context.Items[TraceIdHeader] = traceId;

        context.Response.OnStarting(() =>
        {
            context.Response.Headers[RequestIdHeader] = requestId;
            context.Response.Headers[TraceIdHeader] = traceId;
            return Task.CompletedTask;
        });

        using (logger.BeginScope(new Dictionary<string, object>
        {
            ["RequestId"] = requestId,
            ["TraceId"] = traceId
        }))
        {
            await _next(context);
        }
    }
}

