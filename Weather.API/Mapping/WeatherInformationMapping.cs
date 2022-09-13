using Api.DTOs;
using Domain;

namespace Api.Mapping;

internal static class WeatherInformationMapping
{
    public static WeatherInformationDto MapToDto(this WeatherInformation weatherInformation)
    {
        return new WeatherInformationDto(weatherInformation.CurrentTemperature);
    }
}
