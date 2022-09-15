using Application.Requests;
using Domain;

namespace Application.Services;

internal sealed class OwmWeatherInformationService : IWeatherInformationService
{
    private readonly OpenWeatherMapConfig _config;
    private readonly IOpenWeatherMapRequest _openWeatherMapRequest;

    public OwmWeatherInformationService(OpenWeatherMapConfig config, IOpenWeatherMapRequest openWeatherMapRequest)
    {
        _openWeatherMapRequest = openWeatherMapRequest;
        _config = config;
    }

    public async Task<WeatherInformation> GetCurrentWeatherInformation(LocationCoordinates locationCoordinates)
    {
        var information = await _openWeatherMapRequest.GetCurrentWeatherInformation(locationCoordinates, _config.Token);

        return information;
    }
}
