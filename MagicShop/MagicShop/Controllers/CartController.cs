using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("cart")]
    public class CartController<TEntity, TModel> : Controller
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
    {
        private readonly ICrudService<TEntity, TModel> _crudService;
        private readonly ICartService _cartService;

        public CartController(ICrudService<TEntity, TModel> crudService, ICartService cartService)
        {
            _cartService = cartService;
            _crudService = crudService;
        }

        [HttpGet("check")]
        public IActionResult Check()
        {
            return View();
        }

        [HttpGet("addToCart/{id}")]
        public async Task<IActionResult> AddToCart(int id)
        {
            var entity = await _crudService.GetById(id);

            if (entity != null)
            {
                try
                {
                    _cartService.AddToCart(User, entity);
                }
                catch (UnauthorizedAccessException)
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet("remove/{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            var entity = await _crudService.GetById(id);

            if (entity != null)
            {
                try
                {
                    _cartService.AddToCart(User, entity);
                }
                catch (UnauthorizedAccessException)
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            return RedirectToAction("Index");
        }
        [HttpGet("remove/{id}")]
        public IActionResult ClearCart(int id)
        {
            var entity = _crudService.GetById(id);

            if (entity != null)
            {
                try
                {
                    _cartService.ClearCart(User);
                }
                catch (UnauthorizedAccessException)
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
