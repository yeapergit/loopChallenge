using System.Net.Http.Json;
using CurrencyConverterClient.Dto;
using Newtonsoft.Json;

namespace CurrencyConverterClient.Apis;

public class CurrencyConverterApi : ICurrencyConverterApi
{
    private const string ApiUrl = "http://localhost:5255/CurrencyConverter/";

    public async Task<Currency> GetCurrencyFromApi(string apiKey, string currencyFrom, string currencyTo, int amount)
    {
        try
        {
            var httpClient = new HttpClient();

            var requestUrl =
                $"{ApiUrl}getCurrency?apiKey={apiKey}&currencyFrom={currencyFrom}&currencyTo={currencyTo}&amount={amount}";
            var response = await httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var currency = await response.Content.ReadFromJsonAsync<Currency>();

                if (currency != null)
                {
                    return currency;
                }

                return new Currency
                {
                    error = 500,
                    error_message = "Something went wrong",
                };
            }
            
            return new Currency
            {
                error = (int)response.StatusCode,
                error_message = response.ReasonPhrase
            };
        }
        catch (Exception ex)
        {
            return new Currency
            {
                error = 500,
                error_message = ex.Message
            };
        }
    }
}