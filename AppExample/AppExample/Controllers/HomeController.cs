using Microsoft.AspNetCore.Mvc;

namespace AppExample.Controllers;

public class HomeController : ControllerBase
{
    [HttpGet("/api/resource")]
    public IActionResult Get()
    {
        var random = new Random();
        var randomNumber = random.Next();
        var randomNumber2 = random.Next();
        return Ok(new
        {
            Mul = randomNumber * randomNumber2
        });
    }
}