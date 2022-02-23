using AuthExample.Database;
using AuthExample.Models;
using AuthExample.Models.Db;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthExample.Controllers
{
    public class AuthController : Controller
    {
        private readonly AuthContext _authContext;

        public AuthController(AuthContext authContext)
        {
            _authContext = authContext;
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] RegisterModel registerModel,
            CancellationToken cancellationToken = default)
        {
            var user = await _authContext.Users.SingleOrDefaultAsync(x => x.Email == registerModel.Email,
                cancellationToken);

            if (user != null)
            {
                var hash = HashPassword(registerModel.Password);

                if (!user.Password.Equals(hash))
                {
                    ModelState.AddModelError(string.Empty, "Wrong password");
                    return View();
                }

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipals = new ClaimsPrincipal(claimsIdentity);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipals,
                    authProperties);

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "User does not exist");
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterModel registerModel, 
            CancellationToken cancellationToken = default)
        {
            var user = new User
            {
                Email = registerModel.Email,
                Password = HashPassword(registerModel.Password)
            };

            await _authContext.AddAsync(user, cancellationToken);
            await _authContext.SaveChangesAsync(cancellationToken);

            return RedirectToAction("Index", "Home");
        }

        private static string HashPassword(string password)
        {
            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(password);

            var hash = md5.ComputeHash(bytes);
            hash = md5.ComputeHash(hash);

            return Convert.ToBase64String(hash);
        }
    }
}
