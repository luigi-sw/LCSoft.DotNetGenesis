using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using __company__.__project__.Api.Filters;

namespace __company__.__project__.Api.Mvc;

public static class EssentialServiceCollectionExtensions
{
    internal static IServiceCollection AddEssentialServices(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.ModelValidatorProviders.Clear();
            options.Filters.Add<GlobalExceptionFilter>();
            options.Filters.Add<ValidationFilter>();
        })
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.WriteIndented = false;
        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return services;
    }
}
