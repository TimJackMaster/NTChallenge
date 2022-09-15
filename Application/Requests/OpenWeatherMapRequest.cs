using Application.Requests.Responses;
using Domain;
using RestSharp;
using System.Text.Json;

namespace Application.Requests;

internal sealed class OpenWeatherMapRequest : IOpenWeatherMapRequest
{
    private const string REQUEST_URI = "https://api.openweathermap.org/data/2.5/weather";

    private readonly IRestClient _restClient;

    public OpenWeatherMapRequest(IRestClient restClient)
    {
        _restClient = restClient;
    }

    public async Task<WeatherInformation> GetCurrentWeatherInformation(LocationCoordinates coordinates, OpenWeatherMapToken apiKey)
    {
        var request = new RestRequest("", Method.Get);
        var url = $"{REQUEST_URI}?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={apiKey}";

        var response = await _restClient.GetAsync(request, new Uri(url));

        var responseDto = ConvertJsonToObject<OpenWeatherMapResponse>(response);

        return MapResponseToDomainObject(responseDto!);
    }

    private static T? ConvertJsonToObject<T>(RestResponse response)
    {
        var converted = JsonSerializer.Deserialize<T>(response.Content!, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        return converted;
    }

    private static WeatherInformation MapResponseToDomainObject(OpenWeatherMapResponse response)
    {
        return new WeatherInformation(response.Main.Temp);
    }
}
