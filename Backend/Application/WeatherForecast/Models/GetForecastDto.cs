namespace ApiTemplate.Application.WeatherForecast.Models;

/// <summary>DTO for weather forecast data.</summary>
public sealed record GetForecastDto
{
    /// <summary>Date of the forecast.</summary>
    public DateOnly Date { get; init; }

    /// <summary>Maximum temperature in Celsius.</summary>
    public int MaxTemperatureC { get; init; }

    /// <summary>Minimum temperature in Celsius.</summary>
    public int MinTemperatureC { get; init; }
}