namespace Application.DTOs;

/// <summary>
/// Represents weather information for the wind
/// </summary>
public sealed record WindInformationDto
{
    /// <summary>
    /// Speed of the wind
    /// </summary>
    public decimal Speed { get; }

    /// <summary>
    /// Direction of the wind
    /// </summary>
    public int Direction { get; }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="speed">Speed of the wind</param>
    /// <param name="direction">Direction of the wind</param>
    public WindInformationDto(decimal speed, int direction)
    {
        Speed = speed;
        Direction = direction;
    }
}
