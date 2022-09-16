namespace Application.DTOs;

/// <summary>
/// Represents main weather information, mainly temperature values and basic information
/// </summary>
public sealed record MainInformationDto
{
    /// <summary>
    /// Current temperature at location.
    /// </summary>
    public decimal CurrentTemperature { get; }

    /// <summary>
    /// Minimum temperature at location.
    /// </summary>
    public decimal MinimumTemperature { get; }

    /// <summary>
    /// Maximum temperature at location.
    /// </summary>
    public decimal MaximumTemperature { get; }

    /// <summary>
    /// Air pressure at location.
    /// </summary>
    public int AirPressure { get; }

    /// <summary>
    /// Humidity at locaiton.
    /// </summary>
    public int Humidity { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="currentTemperature">Current temperature at location.</param>
    /// <param name="minimumTemperature">Minimum temperature at location.</param>
    /// <param name="maximumTemperature">Maximum temperature at location.</param>
    /// <param name="airPressure">Air pressure at location.</param>
    /// <param name="humidity">Humidity at locaiton.</param>
    public MainInformationDto(decimal currentTemperature, decimal minimumTemperature, decimal maximumTemperature, int airPressure, int humidity)
    {
        Humidity = humidity;
        AirPressure = airPressure;
        MaximumTemperature = maximumTemperature;
        MinimumTemperature = minimumTemperature;
        CurrentTemperature = currentTemperature;
    }
}
