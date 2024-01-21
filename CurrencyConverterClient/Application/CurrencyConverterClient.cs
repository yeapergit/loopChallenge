using System.Security.Cryptography;
using CurrencyConverterClient.Apis;

namespace CurrencyConverterClient.Application;

public class CurrencyConverterClient
{
    private readonly ICurrencyConverterApi _currencyConverterApi;

    public CurrencyConverterClient(ICurrencyConverterApi currencyConverterApi)
    {
        _currencyConverterApi = currencyConverterApi;
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Currency Converter App");
        Console.WriteLine("Please enter a valid ApiKey from www.amdoren.com");
        var apiKey = Console.ReadLine();

        var currencyFrom = "";
        var currencyTo = "";
        var amount = "";
        int parsedAmount = 0;

        while (string.IsNullOrWhiteSpace(currencyFrom))
        {
            Console.WriteLine("Please enter the currency you would like to convert from (Ex: USD, EUR)");
            currencyFrom = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(currencyFrom))
            {
                Console.WriteLine("Currency from is required.");
            }
            else if (currencyFrom.ToUpper().Equals("EXIT"))
            {
                return;
            }
        }

        while (string.IsNullOrWhiteSpace(currencyTo))
        {
            Console.WriteLine("Please enter the currency you would like to convert to (Ex: USD, EUR)");
            currencyTo = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(currencyTo))
            {
                Console.WriteLine("Currency from is required.");
            }
            else if (currencyTo.ToUpper().Equals("EXIT"))
            {
                return;
            }
        }

        var showAmountOption = true;
        while (showAmountOption)
        {
            Console.WriteLine("The amount to convert from (optional)");
            amount = Console.ReadLine();
            if (amount.Equals("") || int.TryParse(amount, out parsedAmount))
            {
                showAmountOption = false;
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }

        var currency = _currencyConverterApi
            .GetCurrencyFromApi(apiKey, currencyFrom, currencyTo, amount.Equals("") ? 1 : parsedAmount).GetAwaiter()
            .GetResult();

        if (currency.error == 0)
        {
            Console.WriteLine($"Amount converted = {currency.amount}");
        }
        else
        {
            Console.WriteLine($"Cannot convert the entered currency = {currency.error_message}");
        }

        Console.WriteLine("Exiting application");
    }
}