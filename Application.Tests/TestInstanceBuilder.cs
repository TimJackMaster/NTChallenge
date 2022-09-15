using Bogus;
using Domain;

namespace Application.Tests;

internal static class TestInstanceBuilder
{
    private static readonly Faker _faker= new();

    public static LocationCoordinates CreateLocationCoordinates(
        decimal? latitude = null,
        decimal? longitude = null)
    {
        return new LocationCoordinates(
            latitude ?? _faker.Random.Decimal(-90m, 90m),
            longitude ?? _faker.Random.Decimal(-180m, 180m)
            );
    }

    public static OpenWeatherMapToken CreateOpenWeatherMapToken(string? token = null)
    {
        return new OpenWeatherMapToken(token ?? _faker.Random.String());
    }
}
