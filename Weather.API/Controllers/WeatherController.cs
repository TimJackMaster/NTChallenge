using Api.DTOs;
using Api.Mapping;
using Application.Services;
using Domain;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

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
    /// <returns>Current weather information</returns>
    [HttpGet]
    [Route("/location")]
    public async Task<ActionResult<WeatherInformationDto>> GetWeatherInformation([FromQuery] decimal latitude, [FromQuery] decimal longitude)
    {
        var coordinates  = new LocationCoordinates(latitude, longitude);

        var response = await _weatherInformationService.GetCurrentWeatherInformation(coordinates);

        var dto = response.MapToDto();

        return Ok(dto);
    }
}
