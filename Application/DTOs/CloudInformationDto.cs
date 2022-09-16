namespace Application.DTOs;

/// <summary>
/// Represents information about the cloudiness
/// </summary>
public sealed record CloudInformationDto
{
    /// <summary>
    /// Percentage of cloudiness
    /// </summary>
    public int Cloudiness { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="cloudiness">Percentage of cloudiness</param>
    public CloudInformationDto(int cloudiness)
    {
        Cloudiness = cloudiness;
    }
}
