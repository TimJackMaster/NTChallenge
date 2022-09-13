namespace Api.DTOs;

/// <summary>
/// Representation of weather information at a location.
/// </summary>
public sealed record WeatherInformationDto
{
	/// <summary>
	/// The current temperature at the current location
	/// </summary>
    public decimal CurrentTemperature { get; }

	/// <summary>
	/// Controller
	/// </summary>
	/// <param name="currentTemperature">Current Temperature</param>
	public WeatherInformationDto(decimal currentTemperature)
	{
		CurrentTemperature = currentTemperature;
	}
}
