using CurrencyConverterAPI.Clients;
using CurrencyConverterAPI.Services;

namespace CurrencyConverterAPI.Configuration;

internal static class ServicesDependencies
{
    internal static IServiceCollection ConfigureServicesDependencies(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<ICurrencyClient, CurrencyClient>();
        services.AddScoped<ICurrencyConverterService, CurrencyConverterService>();

        return services;
    }
}