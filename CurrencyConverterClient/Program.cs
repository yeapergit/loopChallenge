using CurrencyConverterClient.Apis;

namespace CurrencyConverterClient;

public static class Program
{
    public static async Task Main()
    {
        using var httpClient = new HttpClient();
        
        var currencyConverterApi = new CurrencyConverterApi(httpClient);

        var currencyConverterClient = new Application.CurrencyConverterClient(currencyConverterApi);
        
        currencyConverterClient.Run();
    }
}