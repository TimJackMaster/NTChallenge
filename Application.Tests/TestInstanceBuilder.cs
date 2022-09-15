using Application.Requests;
using Bogus;
using Domain;

namespace Application.Tests;

internal static class TestInstanceBuilder
{
    private static Faker Faker= new Faker();

    public static LocationCoordinates CreateLocationCoordinates(
        decimal? latitude = null,
        decimal? longitude = null)
    {
        return new LocationCoordinates(
            latitude ?? Faker.Random.Decimal(-90m, 90m),
            longitude ?? Faker.Random.Decimal(-180m, 180m)
            );
    }

    public static OpenWeatherMapToken CreateOpenWeatherMapToken(string? token = null)
    {
        return new OpenWeatherMapToken(token ?? Faker.Random.String());
    }
}
