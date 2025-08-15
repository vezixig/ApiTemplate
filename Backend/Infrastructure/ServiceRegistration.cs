namespace ApiTemplate.Infrastructure;

using Application.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;
using Repositories;

/// <summary>Service registration for the infrastructure layer.</summary>
public static class ServiceRegistration
{
    /// <summary>Add services from the infrastructure project to the DI container.</summary>
    /// <param name="services">The service collection.</param>
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddHttpClient<IWeatherForecastRepository, WeatherForecastRepository>(client => { client.BaseAddress = new Uri("https://api.open-meteo.com/v1/"); });
    }
}