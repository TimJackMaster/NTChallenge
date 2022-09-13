using Api.DTOs;
using Api.Mapping;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherInformationService _weatherInformationService;

    public WeatherController(IWeatherInformationService weatherInformationService)
    {
        _weatherInformationService = weatherInformationService;
    }

    [HttpGet]
    public async Task<ActionResult<WeatherInformationDto>> GetWeatherInformation()
    {
        var response = await _weatherInformationService.GetCurrentWeatherInformation();

        var dto = response.MapToDto();

        return Ok(dto);
    }
}
