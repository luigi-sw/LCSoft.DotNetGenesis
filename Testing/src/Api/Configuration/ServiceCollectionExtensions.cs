using MyCompany.MyProject.Api.Mvc;
using MyCompany.MyProject.Api.apidoc;
using MyCompany.MyProject.Application.Configuration;

namespace MyCompany.MyProject.Api.Extensions;

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
