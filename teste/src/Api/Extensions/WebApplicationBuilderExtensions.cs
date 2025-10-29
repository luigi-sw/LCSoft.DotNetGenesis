using teste.Application.Logging;

namespace teste.Api.Extensions;

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
