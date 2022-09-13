using Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherController : ControllerBase
{
    public WeatherController()
    {

    }

    [HttpGet]
    public async Task<ActionResult<WeatherInformationDto>> GetWeatherInformation()
    {
        var response = await CreateFakeResponse();
        return Ok(response);
    }

    private async Task<WeatherInformationDto> CreateFakeResponse()
    {
        var info = new WeatherInformationDto(1.0m);
        return await Task.FromResult(info);
    }
}
