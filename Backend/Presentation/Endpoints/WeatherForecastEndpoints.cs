namespace ApiTemplate.Presentation.Endpoints;

using Application.WeatherForecast;
using Interfaces;

/// <summary>Defines endpoints for weather forecast operations.</summary>
public class WeatherForecastEndpoints : IEndpoints
{
    /// <inheritdoc />
    public void MapEndpoints(WebApplication app)
    {
        app.MapGet(
                "/weatherforecast",
                async (IWeatherForecastService weatherForecastService) =>
                {
                    var forecast = await weatherForecastService.GetForecast();
                    return forecast;
                })
            .WithName("GetWeatherForecast")
            .WithDescription("Retrieves the weather forecast for the next 5 days.");
    }
}