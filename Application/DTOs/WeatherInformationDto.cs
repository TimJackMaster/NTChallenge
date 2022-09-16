namespace Application.DTOs;

/// <summary>
/// Representation of weather information at a location.
/// </summary>
public sealed record WeatherInformationDto
{
    /// <summary>
    /// Main Information for the location.
    /// </summary>
    public MainInformationDto Main { get; }

    /// <summary>
    /// Wind Information for the location.
    /// </summary>
    public WindInformationDto Wind { get; }

    /// <summary>
    /// Cloud information for the location.
    /// </summary>
    public CloudInformationDto Clouds { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="main">Cloud information for the location</param>
    /// <param name="wind">Wind Information for the location</param>
    /// <param name="clouds">Main Information for the location</param>
    public WeatherInformationDto(MainInformationDto main, WindInformationDto wind, CloudInformationDto clouds)
    {
        Clouds = clouds;
        Wind = wind;
        Main = main;
    }
}