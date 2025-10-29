using Microsoft.OpenApi.Models;

namespace MyCompany.MyProject.Api.Apidoc;

public static class ApiConfigurationServiceCollectionExtensions
{
    internal static IServiceCollection AddDocumentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        var ApiDocumentation = configuration.GetSection("ApiDocumentation").Get<ApiDocumentationOptions>();

        services.AddEndpointsApiExplorer();
        services.AddOpenApi("v1", options =>
        {
            options.AddDocumentTransformer((document, context, cancellationToken) =>
            {
                document.Info = new OpenApiInfo
                {
                    Title = ApiDocumentation!.Title,
                    Version = ApiDocumentation.Version,
                    Description = ApiDocumentation.Description,
                    License = new OpenApiLicense
                    {
                        Name = ApiDocumentation.LicenseName,
                        Url = new Uri(ApiDocumentation.LicenseUrl)
                    },
                    TermsOfService = new Uri(ApiDocumentation.TermsUrl),
                    Contact = new OpenApiContact
                    {
                        Name = ApiDocumentation.ContactName,
                        Url = new Uri(ApiDocumentation.ContactUrl),
                        Email = ApiDocumentation.ContactEmail
                    }
                };
                document.Servers = new List<OpenApiServer>
                {
                    new OpenApiServer
                    {
                        Description = ApiDocumentation.ServerDescription,
                        Url = ApiDocumentation.ServerUrl
                    }
                };
                document.Tags = ApiDocumentation.Tags?
                    .Select(t => new OpenApiTag { Name = t.Name, Description = t.Description })
                    .ToList() ?? new List<OpenApiTag>();

                document.SecurityRequirements = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    }
                };
                return Task.CompletedTask;
            });
        });

        return services;
    }
}
