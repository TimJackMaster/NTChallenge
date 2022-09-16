using Application.DTOs;
using Application.Requests.Responses;
using Application.Requests.Responses.OpenWeatherMapDtos;
using Domain.WeatherInformation;

namespace Application.Mapping;

internal static class WeatherInformationMappingExtensions
{
    public static MainInformation MapToDomain(this Main main)
    {
        return new(
            main.Temp,
            main.Temp_Min,
            main.Temp_Max,
            main.Pressure,
            main.Humidity);
    }

    public static WindInformation MapToDomain(this Wind wind)
    {
        return new(wind.Speed, wind.Deg);
    }

    public static CloudInformation MapToDomain(this Clouds clouds)
    {
        return new(clouds.All);
    }

    public static WeatherInformation MapToDomain(this OpenWeatherMapResponse owmResponse)
    {
        return new(
            owmResponse.Main.MapToDomain(),
            owmResponse.Wind.MapToDomain(),
            owmResponse.Clouds.MapToDomain());
    }

    public static MainInformationDto MapToDto(this MainInformation main)
    {
        return new(
            main.CurrentTemperature,
            main.MinimumTemperature,
            main.MaximumTemperature,
            main.AirPressure,
            main.Humidity);
    }

    public static WindInformationDto MapToDto(this WindInformation wind)
    {
        return new(wind.Speed, wind.Direction);
    }

    public static CloudInformationDto MapToDto(this CloudInformation clouds)
    {
        return new(clouds.Cloudiness);
    }

    public static WeatherInformationDto MapToDto(this WeatherInformation weatherInformation)
    {
        return new(
            weatherInformation.Main.MapToDto(),
            weatherInformation.Wind.MapToDto(),
            weatherInformation.Clouds.MapToDto());
    }
}
