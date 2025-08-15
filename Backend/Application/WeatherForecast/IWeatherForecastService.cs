namespace ApiTemplate.Application.WeatherForecast;

using Models;

/// <summary>Service for retrieving weather forecasts.</summary>
public interface IWeatherForecastService
{
    /// <summary>Gets the weather forecast.</summary>
    Task<List<GetForecastDto>> GetForecast();
}