using __company__.__project__.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.CreateApi();

var app = builder.Build();

app.Logger.LogTrace("Starting API...");

app.UseApiMiddleware();

app.Run();