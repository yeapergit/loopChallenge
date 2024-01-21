using CurrencyConverterClient.Dto;

namespace CurrencyConverterClient.Apis;

public interface ICurrencyConverterApi
{
    public Task<Currency> GetCurrencyFromApi(string apiKey, string currencyFrom, string currencyTo, int amount);

}