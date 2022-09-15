using Application.Requests;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    /// <summary>
    /// Extension class for dependency injection.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Registers all services for dependency injection.
        /// </summary>
        /// <param name="services">Service Collection</param>
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherInformationService, OwmWeatherInformationService>();
            services.AddScoped<IRestClient, RestClientWrapper>();
            services.AddTransient<IOpenWeatherMapRequest, OpenWeatherMapRequest>();
        }
    }
}
