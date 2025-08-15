namespace ApiTemplate.Application.WeatherForecast;

using Core.Entities;

/// <summary>Repository for accessing weather forecasts.</summary>
public interface IWeatherForecastRepository
{
    /// <summary>Gets the weather forecast asynchronously.</summary>
    Task<List<WeatherForecast>> GetForecastAsync();
}