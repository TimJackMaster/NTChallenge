namespace Domain;

/// <summary>
/// Struct wrapping the api key string
/// </summary>
public struct OpenWeatherMapToken
{
    private readonly string _token;

    public OpenWeatherMapToken(string token)
    {
        _token = token;
    }

    public override string ToString()
    {
        return _token;
    }
}
