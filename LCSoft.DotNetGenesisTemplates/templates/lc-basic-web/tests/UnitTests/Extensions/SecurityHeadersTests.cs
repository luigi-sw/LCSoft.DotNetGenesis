using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace MyCompany.MyProject.UnitTests.Extensions;

public class SecurityHeadersTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public SecurityHeadersTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false
        });
    }

    [Fact]
    public async Task Deve_Incluir_Headers_De_Seguranca_Padrao()
    {
        // Act
        var response = await _client.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

        Assert.True(response.Headers.Contains("X-Content-Type-Options"));
        Assert.Equal("nosniff", response.Headers.GetValues("X-Content-Type-Options").First());

        Assert.True(response.Headers.Contains("X-Frame-Options"));
        Assert.Equal("DENY", response.Headers.GetValues("X-Frame-Options").First());

        Assert.True(response.Headers.Contains("Referrer-Policy"));
        Assert.Equal("no-referrer-when-downgrade", response.Headers.GetValues("Referrer-Policy").First());

        Assert.True(response.Headers.Contains("Content-Security-Policy"));
    }

    [Fact]
    public async Task Nao_Deve_Incluir_XFrameOptions_Quando_Desabilitado()
    {
        var factory = new CustomWebApplicationFactory()
        {
            _settingsFile = "appsettings.Test.json"
        };
        

        var client = factory.CreateClient();

        var response = await client.GetAsync("/");

        // Assert
        Assert.False(response.Headers.Contains("X-Frame-Options"));
    }
}
