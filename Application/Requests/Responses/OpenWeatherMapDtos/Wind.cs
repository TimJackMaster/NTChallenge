namespace Application.Requests.Responses.OpenWeatherMapDtos;

internal sealed class Wind
{
    public decimal Speed { get; set; } // Wind Speed

    public int Deg { get; set; } // Wind Direction
}
