using Application.Requests;
using Application.Requests.Responses;
using FluentAssertions;
using Moq;
using RestSharp;
using System.Net;
using System.Text.Json;

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

    [Fact]
    public async Task GetCurrentWeatherInformation_WhenCalled_ReturnsMappedDomainObject()
    {
        var apiKey = TestInstanceBuilder.CreateOpenWeatherMapToken();
        var coordinates = TestInstanceBuilder.CreateLocationCoordinates();
        var exspectedUri = new Uri($"https://api.openweathermap.org/data/2.5/weather?lat={coordinates.Latitude}&lon={coordinates.Longitude}&appid={apiKey}");
        var exspectedResponse = LoadGoodResponse();

        var restResponse = CreateRestResponse("GoodResponse.json");
        _restClient.Setup(r => r.GetAsync(It.IsAny<RestRequest>(), exspectedUri))
            .ReturnsAsync(restResponse);

        var domainObject = await _openWeatherMapRequest.GetCurrentWeatherInformation(coordinates, apiKey);

        domainObject.Should().NotBeNull();
        domainObject.Wind.Speed.Should().Be(exspectedResponse.Wind.Speed);
        domainObject.Wind.Direction.Should().Be(exspectedResponse.Wind.Deg);
        domainObject.Clouds.Cloudiness.Should().Be(exspectedResponse.Clouds.All);
        domainObject.Main.AirPressure.Should().Be(exspectedResponse.Main.Pressure);
        domainObject.Main.Humidity.Should().Be(exspectedResponse.Main.Humidity);
        domainObject.Main.CurrentTemperature.Should().Be(exspectedResponse.Main.Temp);
        domainObject.Main.MaximumTemperature.Should().Be(exspectedResponse.Main.Temp_Max);
        domainObject.Main.MinimumTemperature.Should().Be(exspectedResponse.Main.Temp_Min);
    }

    private static RestResponse CreateRestResponse(string filename, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        return new RestResponse()
        {
            StatusCode = statusCode,
            Content = ReadFileContent(filename),
        };
    }

    private static OpenWeatherMapResponse LoadGoodResponse()
    {
        var json = ReadFileContent("GoodResponse.json");
        var response = JsonSerializer.Deserialize<OpenWeatherMapResponse>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        });

        return response;
    }

    private static string ReadFileContent(string filename)
    {
        var content = File.ReadAllText($"Requests/OpenWeatherMapResponses/{filename}");
        return content;
    }
}