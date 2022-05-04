using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("generic")]
    public class GenericController<TEntity, TModel> : Controller
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
    {
        private readonly ICrudService<TEntity, TModel> _crudService;
        private readonly ICartService _cartService;
        public GenericController(ICrudService<TEntity, TModel> crudService, ICartService cartService)
        {
            _crudService = crudService;
            _cartService = cartService;
        }

        [HttpGet("getAll")]
        public virtual async Task<ActionResult> Index()
        {
            var res = await _crudService.GetAll();
            return View(res);
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult> Details(int id)
        {
            var model = await _crudService.GetById(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TEntity entity)
        {
            try
            {
                await _crudService.Create(entity);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("edit")]
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _crudService.GetById(id);
            return View(model);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(TEntity updated)
        {
            try
            {
                await _crudService.Edit(updated);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var model = await _crudService.GetById(id);
            return View(model);
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _crudService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
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
        [HttpGet("removeFromCart/{id}")]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var entity = await _crudService.GetById(id);

            if (entity != null)
            {
                try
                {
                    _cartService.RemoveFromCart(User, entity);
                }
                catch (UnauthorizedAccessException)
                {
                    return RedirectToAction("Register", "Account");
                }
            }
            return RedirectToAction("Check", "Cart");
        }

    }
}
