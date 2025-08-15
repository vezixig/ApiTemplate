namespace ApiTemplate.Application.WeatherForecast;

using Models;

internal sealed class WeatherForecastService(IWeatherForecastRepository weatherForecastRepository) : IWeatherForecastService
{
    public async Task<List<GetForecastDto>> GetForecast()
    {
        var forecast = await weatherForecastRepository.GetForecastAsync();

        var result = forecast.Select(o => new GetForecastDto
            {
                Date = o.Date,
                MinTemperatureC = o.MinTemperatureC,
                MaxTemperatureC = o.MaxTemperatureC
            })
            .ToList();

        return result;
    }
}