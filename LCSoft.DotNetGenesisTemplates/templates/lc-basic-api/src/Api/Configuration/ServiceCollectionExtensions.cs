using __company__.__project__.Api.Mvc;
using __company__.__project__.Api.apidoc;
using __company__.__project__.Application.Configuration;

namespace __company__.__project__.Api.Extensions;

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
