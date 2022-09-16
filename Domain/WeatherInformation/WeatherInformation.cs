namespace Domain.WeatherInformation;

/// <summary>
/// Represents information about weather at a location.
/// </summary>
/// <param name="Main"></param>
/// <param name="Wind"></param>
/// <param name="Clouds"></param>
public sealed record WeatherInformation(
    MainInformation Main,
    WindInformation Wind,
    CloudInformation Clouds);