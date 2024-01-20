using Newtonsoft.Json;

namespace CurrencyConverterClient.Apis;

public class CurrencyConverterApi : ICurrencyConverterApi
{
    private const string ApiUrl = "http://localhost:5255/CurrencyConverter/";
    private readonly HttpClient _httpClient;

    public CurrencyConverterApi(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetCurrencyFromApi(string apiKey, string currencyFrom, string currencyTo, int amount)
    {
        try
        {
            var requestUrl =
                $"{ApiUrl}getCurrency?apiKey={apiKey}&currencyFrom={currencyFrom}&currencyTo={currencyTo}&amount={amount}";
            var response = _httpClient.GetAsync(requestUrl).Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var currency = JsonConvert.DeserializeObject(content);
            
            Console.WriteLine(currency);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

        return null;
    }
}