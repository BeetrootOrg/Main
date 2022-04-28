using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("cart")]
    public class CartController: Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("check")]
        public IActionResult Check()
        {
            var cart = _cartService.GetCart(User);
            if (cart == null)
            {
                return RedirectToAction("Register", "Account");
            }
            return View(cart);
        }

        [HttpGet("clear")]
        public IActionResult Clear()
        {
            try
            {
                _cartService.ClearCart(User);
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToAction("Register", "Account");
            }

            return RedirectToAction("Check");
        }


    }
}
