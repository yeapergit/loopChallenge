using CurrencyConverterAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverterAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CurrencyConverterController : ControllerBase
{
    private readonly ICurrencyConverterService _currencyConverterService;

    public CurrencyConverterController(ICurrencyConverterService currencyConverterService)
    {
        _currencyConverterService = currencyConverterService;
    }

    [HttpGet("getCurrency")]
    public async Task<IActionResult> GetCurrency([FromQuery] string apiKey, [FromQuery] string currencyFrom,
        [FromQuery] string currencyTo,
        [FromQuery] int amount = 1)
    {
        var result = await _currencyConverterService.GetCurrency(apiKey, currencyFrom, currencyTo, amount);
        return Ok(result);
    }
}