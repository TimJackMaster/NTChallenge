using Domain;

namespace Application.Services;

public interface IWeatherInformationService
{
    public Task<WeatherInformation> GetCurrentWeatherInformation();
}
