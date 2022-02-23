using AuthExample.Database;
using AuthExample.Models;
using AuthExample.Models.Db;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Register([FromForm] RegisterModel registerModel, 
            CancellationToken cancellationToken = default)
        {
            using var md5 = MD5.Create();
            var bytes = Encoding.UTF8.GetBytes(registerModel.Password);

            var hash = md5.ComputeHash(bytes);
            hash = md5.ComputeHash(hash);

            var user = new User
            {
                Email = registerModel.Email,
                Password = Convert.ToBase64String(hash)
            };

            await _authContext.AddAsync(user, cancellationToken);
            await _authContext.SaveChangesAsync(cancellationToken);

            return RedirectToAction("Index", "Home");
        }
    }
}
