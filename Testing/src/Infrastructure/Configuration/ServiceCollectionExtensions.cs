using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MyCompany.MyProject.Infrastructure.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
        services.AddDatabaseServices(configuration, connectionStringName);

        return services;
    }

    private static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration, string connectionStringName)
    {
        //Example with Entity Framework Core - replace YourDbContext with your actual DbContext
        //services.AddDbContext<DbContext>(options =>
        //{
        //    var connectionString = configuration.GetConnectionString(connectionStringName);
        //    options.UseSqlServer(connectionString, sqlOptions =>
        //    {
        //        sqlOptions.EnableRetryOnFailure(
        //            maxRetryCount: 3,
        //            maxRetryDelay: TimeSpan.FromSeconds(30),
        //            errorNumbersToAdd: null);
        //        sqlOptions.CommandTimeout(30);
        //    });

        //    options.EnableSensitiveDataLogging(false);
        //    options.EnableDetailedErrors(false);
        //});

        return services;
    }

}

