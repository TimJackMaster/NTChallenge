namespace Domain.WeatherInformation;

/// <summary>
/// Represents main weather information, mainly temperature values and basic information
/// </summary>
/// <param name="CurrentTemperature"></param>
/// <param name="MinimumTemperature"></param>
/// <param name="MaximumTemperature"></param>
/// <param name="AirPressure"></param>
/// <param name="Humidity"></param>
public sealed record MainInformation(
    decimal CurrentTemperature,
    decimal MinimumTemperature,
    decimal MaximumTemperature,
    int AirPressure,
    int Humidity);