namespace Application.Requests.Responses.OpenWeatherMapDtos;

internal sealed class Main
{
    public decimal Temp { get; set; } // Temperature

    public decimal Temp_Max { get; set; } // Maximum Temperature

    public decimal Temp_Min { get; set; } // Minimum Temperature

    public int Pressure { get; set; } // Air Pressure

    public int Humidity { get; set; } // Humidity
}
