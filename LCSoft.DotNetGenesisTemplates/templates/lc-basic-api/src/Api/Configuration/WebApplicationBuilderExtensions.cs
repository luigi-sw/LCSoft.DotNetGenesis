using __company__.__project__.Application.Logging;

namespace __company__.__project__.Api.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder CreateApi(this WebApplicationBuilder builder)
    {
        builder.AddLoggingServices();

        builder.Services.AddApiServices(
            builder.Configuration,
            connectionStringName: "DefaultConnection"
        );

        return builder;
    }
}
