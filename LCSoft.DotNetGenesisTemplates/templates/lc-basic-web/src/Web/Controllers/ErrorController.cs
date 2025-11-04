using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace __company__.__project__.Web.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }

    // Handles exceptions from app.UseExceptionHandler("/Error")
    [Route("Error")]
    public IActionResult Exception()
    {
        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

        var correlationId = HttpContext.Items["X-Correlation-ID"]?.ToString();
        //var requestId = HttpContext.Items["X-Request-ID"]?.ToString();
        //var traceId = HttpContext.Items["X-Trace-ID"]?.ToString();
        var traceId = HttpContext.TraceIdentifier;

        if (exceptionHandlerPathFeature != null)
        {
            _logger.LogError(exceptionHandlerPathFeature.Error,
                "Unhandled exception at path {Path} with CorrelationId {CorrelationId}",
                exceptionHandlerPathFeature.Path, correlationId);
        }

        ViewBag.CorrelationId = correlationId;
        //ViewBag.RequestId = requestId;
        ViewBag.TraceId = traceId;

        return View("Error"); 
    }

    // Handles status codes from app.UseStatusCodePagesWithRedirects("/Error/{0}")
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        _logger.LogWarning("HTTP {StatusCode} at path {Path}", statusCode, HttpContext.Request.Path);

        ViewBag.StatusCode = statusCode;

        switch (statusCode)
        {
            case 404:
                return View("NotFound"); // Views/Error/NotFound.cshtml
            case 403:
                return View("Forbidden"); // Views/Error/Forbidden.cshtml
            default:
                return View("Error");
        }
    }

    // Handles validation errors redirected by your ValidationFilter
    [Route("Error/Validation")]
    public IActionResult Validation()
    {
        if (TempData["ValidationErrors"] is string json)
        {
            var errors = System.Text.Json.JsonSerializer
                .Deserialize<Dictionary<string, string[]>>(json);

            _logger.LogInformation("Validation failed with {ErrorCount} fields invalid", errors?.Count);

            return View("ValidationError", errors);
        }

        return RedirectToAction("Exception");
    }
}
