using CurrencyConverterAPI.Dto;

namespace CurrencyConverterAPI.Services;

public interface ICurrencyConverterService
{
    public Task<Currency> GetCurrency(string apiKey, string currencyFrom, string currencyTo, int amount);
}