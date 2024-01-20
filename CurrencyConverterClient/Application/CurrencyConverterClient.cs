using CurrencyConverterClient.Apis;

namespace CurrencyConverterClient.Application;

public class CurrencyConverterClient
{
    private readonly ICurrencyConverterApi _currencyConverterApi;

    public CurrencyConverterClient(ICurrencyConverterApi currencyConverterApi)
    {
        _currencyConverterApi = currencyConverterApi;
    }

    public async void Run()
    {
        var teste = await _currencyConverterApi.GetCurrencyFromApi("a", "b", "c", 12);
        Console.WriteLine(teste);
    }
}