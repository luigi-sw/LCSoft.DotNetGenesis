using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace MyCompany.MyProject.UnitTests.Extensions;

public class NoXFrameOptionsFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureAppConfiguration(config =>
        {
            // Sobrescreve as configurações de SecurityHeaders
            var dict = new Dictionary<string, string?>
            {
                { "SecurityHeaders:AddXFrameOptions", "false" }
            };

            config.AddInMemoryCollection(dict!);
        });

        return base.CreateHost(builder);
    }
}
