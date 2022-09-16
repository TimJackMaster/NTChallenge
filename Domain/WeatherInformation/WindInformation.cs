namespace Domain.WeatherInformation;

/// <summary>
/// Represents weather information for the wind
/// </summary>
/// <param name="Speed"></param>
/// <param name="Direction"></param>
public sealed record WindInformation(decimal Speed, int Direction);