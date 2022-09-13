namespace Domain;

/// <summary>
/// Representation of weather information at a location.
/// </summary>
public sealed record WeatherInformation
{
	/// <summary>
	/// Current temperature at location.
	/// </summary>
    public decimal CurrentTemperature { get; }

	/// <summary>
	/// Controller.
	/// </summary>
	/// <param name="currentTemperature">Current temperature at location</param>
	public WeatherInformation(decimal currentTemperature)
	{
		CurrentTemperature = currentTemperature;
	}
}