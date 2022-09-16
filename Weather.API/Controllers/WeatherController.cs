using Application.DTOs;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

/// <summary>
/// Controller profiding information about weather.
/// </summary>
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherInformationService _weatherInformationService;

    /// <summary>
    /// Controller.
    /// </summary>
    /// <param name="weatherInformationService">Service providing weather information</param>
    public WeatherController(IWeatherInformationService weatherInformationService)
    {
        _weatherInformationService = weatherInformationService;
    }

    /// <summary>
    /// Returns the current weather information for a given location.
    /// </summary>
    /// <param name="latitude">Latitude of the location.</param>
    /// <param name="longitude">Longitude of the location.</param>
    /// <returns>Current weather information</returns>
    [HttpGet]
    [Route("/location")]
    public async Task<ActionResult<WeatherInformationDto>> GetWeatherInformation([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var coordinates  = new LocationCoordinates(latitude, longitude);

        var dto = await _weatherInformationService.GetCurrentWeatherInformation(coordinates);

        return Ok(dto);
    }
}
