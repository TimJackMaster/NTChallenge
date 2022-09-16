using Domain;
using Domain.WeatherInformation;

namespace Application.Requests;

internal interface IOpenWeatherMapRequest
{
    Task<WeatherInformation> GetCurrentWeatherInformation(LocationCoordinates coordinates, OpenWeatherMapToken apiKey);
}