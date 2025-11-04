namespace MyCompany.MyProject.UnitTests.Extensions;

public class SecurityHeadersDisabledTests : IClassFixture<NoXFrameOptionsFactory>
{
    private readonly HttpClient _client;

    public SecurityHeadersDisabledTests(NoXFrameOptionsFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Nao_Deve_Incluir_XFrameOptions_Quando_Desabilitado()
    {
        // Act
        var response = await _client.GetAsync("/");

        // Assert
        Assert.False(response.Headers.Contains("X-Frame-Options"));
    }
}
