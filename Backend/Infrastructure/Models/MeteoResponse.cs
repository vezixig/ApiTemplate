namespace ApiTemplate.Infrastructure.Models;

using System.Text.Json.Serialization;

internal record MeteoResponse(
    double Latitude,
    double Longitude,
    double GenerationtimeMs,
    int UtcOffsetSeconds,
    string Timezone,
    string TimezoneAbbreviation,
    double Elevation,
    MeteoResponseDailyUnits DailyUnits,
    MeteoResponseDailyData Daily);

internal record MeteoResponseDailyUnits(
    string Time,
    [property: JsonPropertyName("temperature_2m_max")]
    string Temperature2mMax,
    [property: JsonPropertyName("temperature_2m_min")]
    string Temperature2mMin);

internal record MeteoResponseDailyData(
    List<DateOnly> Time,
    [property: JsonPropertyName("temperature_2m_max")]
    List<double> Temperature2mMax,
    [property: JsonPropertyName("temperature_2m_min")]
    List<double> Temperature2mMin);