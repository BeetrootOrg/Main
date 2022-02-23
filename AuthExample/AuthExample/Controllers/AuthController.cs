using AuthExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AuthExample.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register([FromForm] RegisterModel registerModel)
        {
            throw new NotImplementedException();
        }
    }
}
