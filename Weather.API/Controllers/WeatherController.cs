using Api.DTOs;
using Api.Mapping;
using Application.Services;
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
    /// <returns>Current weather information</returns>
    [HttpGet]
    public async Task<ActionResult<WeatherInformationDto>> GetWeatherInformation()
    {
        var response = await _weatherInformationService.GetCurrentWeatherInformation();

        var dto = response.MapToDto();

        return Ok(dto);
    }
}
