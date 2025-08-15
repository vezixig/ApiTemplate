namespace ApiTemplate.Core.Entities;

/// <summary>Represents a weather forecast for a specific date.</summary>
public record WeatherForecast
{
    /// <summary>Gets the date of the weather forecast.</summary>
    public DateOnly Date { get; init; }

    /// <summary>Gets the maximum temperature in Celsius.</summary>
    public int MaxTemperatureC { get; init; }

    /// <summary>Gets the maximum temperature in Fahrenheit.</summary>
    public int MaxTemperatureF => 32 + (int)(MaxTemperatureC / 0.5556);

    /// <summary>Gets the minimum temperature in Celsius.</summary>
    public int MinTemperatureC { get; init; }

    /// <summary>Gets the minimum temperature in Fahrenheit.</summary>
    public int MinTemperatureF => 32 + (int)(MinTemperatureC / 0.5556);
}