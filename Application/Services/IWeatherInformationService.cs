using Domain;

namespace Application.Services;

/// <summary>
/// Service providing weather information for locations.
/// </summary>
public interface IWeatherInformationService
{
    /// <summary>
    /// Gets the current weather information for a given collection.
    /// </summary>
    /// <returns>The current weather information at the given location.</returns>
    public Task<WeatherInformation> GetCurrentWeatherInformation();
}
