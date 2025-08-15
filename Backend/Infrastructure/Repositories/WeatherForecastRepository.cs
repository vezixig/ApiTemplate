namespace ApiTemplate.Infrastructure.Repositories;

using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json;
using Application.WeatherForecast;
using Core.Entities;
using Models;

internal sealed class WeatherForecastRepository(HttpClient httpClient) : IWeatherForecastRepository
{
    private const double Latitude = 49.767367;

    private const double Longitude = 7.223761;

    public async Task<List<WeatherForecast>> GetForecastAsync()
    {
        var response = await httpClient.GetAsync(
            $"forecast?latitude={Latitude.ToString(CultureInfo.InvariantCulture)}&longitude={Longitude.ToString(CultureInfo.InvariantCulture)}&daily=temperature_2m_max,temperature_2m_min");
        var data = await response.Content.ReadFromJsonAsync<MeteoResponse>(
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            });
        if (data == null) throw new InvalidOperationException("Failed to retrieve weather forecast data.");

        var result = new List<WeatherForecast>();
        for (var i = 0; i < data.Daily.Time.Count; i++)
        {
            var date = data.Daily.Time[i];
            var maxTemp = data.Daily.Temperature2mMax[i];
            var minTemp = data.Daily.Temperature2mMin[i];

            result.Add(
                new WeatherForecast
                {
                    Date = date,
                    MaxTemperatureC = (int)maxTemp,
                    MinTemperatureC = (int)minTemp
                });
        }

        return result;
    }
}