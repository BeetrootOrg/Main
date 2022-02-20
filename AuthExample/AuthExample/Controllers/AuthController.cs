using Microsoft.AspNetCore.Mvc;

namespace AuthExample.Controllers
{
    public class AuthController : ControllerBase
    {
        [HttpGet("me")]
        public IActionResult Me()
        {
            return Ok(new
            {
                Username = "user",
                Age = 42
            });
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register()
        {
            return Ok();
        }
    }
}
