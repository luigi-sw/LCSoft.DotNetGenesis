using teste.Api.Mvc;
using teste.Api.apidoc;
using teste.Application.Configuration;

namespace teste.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(
        this IServiceCollection services,
        IConfiguration configuration,
        string connectionStringName = "DefaultConnection")
    {
        services.AddEssentialServices();
        services.AddDocumentationServices(configuration);
        services.AddApplicationServices(configuration, connectionStringName);

        return services;
    }
}
