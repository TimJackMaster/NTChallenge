namespace Domain;

/// <summary>
/// Configuration for Requests send to OpenWeatherMap
/// </summary>
/// <param name="Token">The API Key</param>
public sealed record OpenWeatherMapConfig(OpenWeatherMapToken Token);
