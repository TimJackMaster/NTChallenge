using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherInformationService, WeatherInformationService>();
        }
    }
}
