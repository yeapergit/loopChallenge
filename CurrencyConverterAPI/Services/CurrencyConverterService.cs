using CurrencyConverterAPI.Clients;
using CurrencyConverterAPI.Dto;

namespace CurrencyConverterAPI.Services;

public class CurrencyConverterService : ICurrencyConverterService
{
    private readonly ICurrencyClient _currencyClient;
    private readonly ILogger<CurrencyConverterService> _logger;

    public CurrencyConverterService(ICurrencyClient currencyClient, ILogger<CurrencyConverterService> logger)
    {
        _currencyClient = currencyClient;
        _logger = logger;
    }

    public async Task<Currency> GetCurrency(string apiKey, string currencyFrom, string currencyTo, int amount)
    {
        var currency = await _currencyClient.GetCurrencyFromPublicApi(apiKey, currencyFrom, currencyTo, amount);

        if (currency.error != 0)
        {
            _logger.LogError(
                $"Error occured to get currency: errorCode={currency.error} ,errorMessage={currency.error_message}");
        }

        return currency;
    }
}