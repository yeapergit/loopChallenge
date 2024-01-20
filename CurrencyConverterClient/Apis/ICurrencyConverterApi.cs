namespace CurrencyConverterClient.Apis;

public interface ICurrencyConverterApi
{
    public Task<string> GetCurrencyFromApi(string apiKey, string currencyFrom, string currencyTo, int amount);

}