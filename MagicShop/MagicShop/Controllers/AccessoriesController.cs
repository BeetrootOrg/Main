using BLL.Services.Implementation;
using BLL.Services.Interfaces;
using DLL.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    [Route("Accessories")]
    public class AccessoriesController : Controller
    {
        private IAccessoriesService _accessoriesService;
        public AccessoriesController(IAccessoriesService accessoriesServic)
        {
            _accessoriesService = accessoriesServic;
        }

        [HttpGet("getAccess")]
        public ActionResult Index()
        {
            var rest = _accessoriesService.GetAll();
            return View(rest);
        }

        [HttpGet("getAccess/{id}")]
        public ActionResult Details(int id)
        {
            var model = _accessoriesService.GetById(id);
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
        public ActionResult Create(Accessories model)
        {
            try
            {
                _accessoriesService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccessoriesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccessoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccessoriesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccessoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
