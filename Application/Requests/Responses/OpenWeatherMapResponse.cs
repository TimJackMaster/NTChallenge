using Application.Requests.Responses.OpenWeatherMapDtos;

namespace Application.Requests.Responses;

internal sealed class OpenWeatherMapResponse
{
    public Main Main { get; set; } // contains temperature information

    public Wind Wind { get; set; } // contains wind information

    public Clouds Clouds { get; set; } // contians cloud information
}
