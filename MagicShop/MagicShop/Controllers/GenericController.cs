using BLL.Services.Interfaces;
using DAL.Entites;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Models;
using Shared.Models.Base;
using System.Security.Claims;

namespace MagicShop.Controllers
{
    public class GenericController<TEntity, TModel> : Controller
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
    {
        private readonly ICrudService<TEntity, TModel> _crudService;
        private readonly IMemoryCache _cache;
        public GenericController(ICrudService<TEntity, TModel> crudService, IMemoryCache cache)
        {
            _crudService = crudService;
            _cache = cache;
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
                GetCart().AddItem(entity);
            }
            return Ok();
        }
        public CartModel GetCart()
        {
            _cache.TryGetValue(
                User.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value,
                out CartModel cart);
            if (cart == null)
            {
                cart = new CartModel();
            }
            return cart;
        }
    }
}
