using System.Net;
using Application.Requests;
using Moq;
using RestSharp;

namespace Application.Tests;

public sealed class OpenWeatherMapRequestTests
{

    private readonly Mock<IRestClient> _restClient;
    private readonly OpenWeatherMapRequest _openWeatherMapRequest;

    public OpenWeatherMapRequestTests()
    {
        _restClient = new Mock<IRestClient>();
        _openWeatherMapRequest = new OpenWeatherMapRequest(_restClient.Object);
    }

    [Fact]
    public async Task GetCurrentWeatherInformation_WhenCalled_CallsRightUrl()
    {
        var apiKey = TestInstanceBuilder.CreateOpenWeatherMapToken();
        var coordinates = TestInstanceBuilder.CreateLocationCoordinates();
        var exspectedUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={apiKey}");

        var restResponse = CreateRestResponse("GoodResponse.json");
        _restClient.Setup(r => r.GetAsync(It.IsAny<RestRequest>(), exspectedUri))
            .ReturnsAsync(restResponse);

        _ = await _openWeatherMapRequest.GetCurrentWeatherInformation(coordinates, apiKey);

        _restClient.Verify(r => r.GetAsync(It.IsAny<RestRequest>(), exspectedUri), Times.Once);
    }

    private RestResponse CreateRestResponse(string filename, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new RestResponse()
        {
            StatusCode = statusCode,
            Content = ReadFileContent(filename),
        };
    }

    private string ReadFileContent(string filename)
    {
        var content = File.ReadAllText($"Requests/OpenWeatherMapResponses/{filename}");
        return content;
    }
}