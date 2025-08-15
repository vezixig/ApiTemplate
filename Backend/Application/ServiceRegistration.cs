namespace ApiTemplate.Application;

using Microsoft.Extensions.DependencyInjection;
using WeatherForecast;

/// <summary>Service registration for the application layer.</summary>
public static class ServiceRegistration
{
    /// <summary>Add services from the infrastructure project to the DI container.</summary>
    /// <param name="services">The service collection.</param>
    public static void AddApplication(this IServiceCollection services)
    {
        // register services
        services.AddSingleton<IWeatherForecastService, WeatherForecastService>();
    }
}