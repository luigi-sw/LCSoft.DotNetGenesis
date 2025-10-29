namespace teste.Api.apidoc;

public class ApiDocumentationOptions
{
    public string Title { get; set; } = default!;
    public string Version { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string ServerUrl { get; set; } = default!;
    public string ServerDescription { get; set; } = default!;
    public string LicenseName { get; set; } = default!;
    public string LicenseUrl { get; set; } = default!;
    public string TermsUrl { get; set; } = default!;
    public string ContactName { get; set; } = default!;
    public string ContactUrl { get; set; } = default!;
    public string ContactEmail { get; set; } = default!;

    public List<ApiTagOptions> Tags { get; set; } = new();
}

public class ApiTagOptions
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
}