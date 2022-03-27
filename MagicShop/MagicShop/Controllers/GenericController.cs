using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    public class GenericController<TEntity, TModel> : Controller
    {
        private readonly ICrudService<TEntity, TModel> _crudService;
        public GenericController(ICrudService<TEntity, TModel> crudService)
        {
            _crudService = crudService;
        }

        [HttpGet("getAll")]
        public async Task<ActionResult> Index()
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

    }
}
