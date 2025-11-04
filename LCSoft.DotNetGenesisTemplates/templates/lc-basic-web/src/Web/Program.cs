using __company__.__project__.Web.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.AddWebProject();

var app = builder.Build();

app.Logger.LogTrace("Starting Web...");

app.UseWebProject();

app.Run();

public partial class Program { }
