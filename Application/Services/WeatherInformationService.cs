using Domain;

namespace Application.Services;

internal sealed class WeatherInformationService : IWeatherInformationService
{
    public Task<WeatherInformation> GetCurrentWeatherInformation(LocationCoordinates _)
    {
        return Task.FromResult(new WeatherInformation(1.1m));
    }
}
