using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace __company__.__project__.Web.Filter;

public class ValidationFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            if (context.Controller is Controller controller)
            {
                controller.TempData["ValidationErrors"] =
                    System.Text.Json.JsonSerializer.Serialize(errors);
            }

            context.Result = new RedirectToActionResult("Validation", "Error", null);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context) { }
}