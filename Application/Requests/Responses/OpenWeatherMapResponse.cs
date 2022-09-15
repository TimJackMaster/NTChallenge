using Application.Requests.Responses.OpenWeatherMapDtos;

namespace Application.Requests.Responses;

internal class OpenWeatherMapResponse
{
    public Main Main { get; set; } // contains temperature information
}
