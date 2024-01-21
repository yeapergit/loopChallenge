using CurrencyConverterClient.Apis;

namespace CurrencyConverterClient;

public static class Program
{
    public static void Main()
    {
        var currencyConverterApi = new CurrencyConverterApi();

        var currencyConverterClient = new Application.CurrencyConverterClient(currencyConverterApi);
        
        currencyConverterClient.Run();
    }
}