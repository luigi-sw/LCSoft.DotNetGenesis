namespace __company__.__project__.Application.Models;

public class SecurityHeaderOptions
{
    public string ContentSecurityPolicy { get; set; } =
        "default-src 'self'; object-src 'none'; frame-ancestors 'none'; base-uri 'self';";

    public string ReferrerPolicy { get; set; } = "no-referrer";
    public bool UseHsts { get; set; } = true;
    public int HstsMaxAgeDays { get; set; } = 365;

    public bool AddXContentTypeOptions { get; set; } = true;
    public bool AddXFrameOptions { get; set; } = true;
    public bool AddXXssProtection { get; set; } = false; // browsers modernos ignoram
}