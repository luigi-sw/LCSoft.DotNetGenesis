using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace MyCompany.MyProject.UnitTests.Extensions;


public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    public string _settingsFile { get; set; } = "appsettings.json";

    //public CustomWebApplicationFactory(string settingsFile = "appsettings.json")
    //{
    //    _settingsFile = settingsFile;
    //}


    // Aqui você pode sobrescrever configurações se precisar
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseContentRoot(AppContext.BaseDirectory); 

        builder.ConfigureAppConfiguration((context, config) =>
        {
            config.Sources.Clear();

            config.AddJsonFile(_settingsFile, optional: false, reloadOnChange: false);;
        });

        return base.CreateHost(builder);
    }
}

