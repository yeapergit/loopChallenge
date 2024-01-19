using CurrencyConverterAPI.Dto;
using Newtonsoft.Json;

namespace CurrencyConverterAPI.Clients;

public class CurrencyClient : ICurrencyClient
{
    private const string ApiUrl = "https://www.amdoren.com/api/currency.php";
    
    private readonly HttpClient _httpClient;
    private readonly ILogger<CurrencyClient> _logger;

    public CurrencyClient(HttpClient httpClient, ILogger<CurrencyClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Currency> GetCurrencyFromPublicApi(string apiKey, string currencyFrom, string currencyTo, int amount)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{ApiUrl}?api_key={apiKey}&from={currencyFrom}&to={currencyTo}&amount={amount}");

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Got successful response from Amdoren API");
                var content = await response.Content.ReadAsStringAsync();
                var currency = JsonConvert.DeserializeObject<Currency>(content);
            
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
        catch (JsonException ex)
        {
            _logger.LogError("Failed to deserialize object from public api");
            throw new JsonException("Failed to deserialize object from public api", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw ex;
        }
    }
}