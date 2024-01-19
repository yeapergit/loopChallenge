using CurrencyConverterAPI.Dto;

namespace CurrencyConverterAPI.Clients;

public interface ICurrencyClient
{
    public Task<Currency> GetCurrencyFromPublicApi(string apiKey, string currencyFrom, string currencyTo, int amount);
}