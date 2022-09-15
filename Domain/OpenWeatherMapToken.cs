namespace Domain;

/// <summary>
/// 
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
