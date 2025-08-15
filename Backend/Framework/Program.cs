using ApiTemplate.Application;
using ApiTemplate.Config;
using ApiTemplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder
    .AddDefaultHealthChecks()
    .ConfigureCors()
    .ConfigureOpenTelemetry()
    .ConfigureHttpClientDefaults();

var app = builder.Build();
app
    .ConfigureDevelopment()
    .RegisterEndpointsFromAssembly()
    .UseHttpsRedirection()
    .UseCors();

await app.RunAsync();