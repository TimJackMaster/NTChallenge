namespace Domain;

/// <summary>
/// Representing the coordinates of a location.
/// </summary>
public record LocationCoordinates
{
    /// <summary>
    /// Latitude of a location.
    /// </summary>
    public decimal Latitude { get; }

    /// <summary>
    /// Longitude of a location.
    /// </summary>
    public decimal Longitude { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="latitude">Latitude of the location.</param>
    /// <param name="longitude">Longitude of the location.</param>
    public LocationCoordinates(decimal latitude, decimal longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
