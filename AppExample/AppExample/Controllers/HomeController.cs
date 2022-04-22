using AppExample.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppExample.Controllers;

public class HomeController : ControllerBase
{
    private readonly IMathService _mathService;
    private readonly IRandomGenerator _randomGenerator;

    public HomeController(IMathService mathService, IRandomGenerator randomGenerator)
    {
        _mathService = mathService;
        _randomGenerator = randomGenerator;
    }

    [HttpGet("/api/resource")]
    public IActionResult Get()
    {
        var randomNumber1 = _randomGenerator.Generate();
        var randomNumber2 = _randomGenerator.Generate();
        
        return Ok(new
        {
            Mul = _mathService.Multiply(randomNumber1, randomNumber2)
        });
    }
}