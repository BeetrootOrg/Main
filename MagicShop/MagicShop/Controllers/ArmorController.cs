using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    [Route("armor")]
    public class ArmorController : Controller
    {
        private IArmorService _armorService;
        public ArmorController(IArmorService armorService)
        {
            _armorService = armorService;
        }

        [HttpGet ("getArmor")]
        public ActionResult Index()
        {
            var res = _armorService.GetAll();
            return View(res);
        }

        [HttpGet("getAccess/{id}")]
        public ActionResult Details(int id)
        {
            var model = _armorService.GetById(id);
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
        public ActionResult Create(Armor model)
        {
            try
            {
                _armorService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("edit")]
        public ActionResult Edit(int id)
        {
            var model = _armorService.GetById(id);
            return View(model);
        }

        [HttpPost("edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Armor updated)
        {
            try
            {
                _armorService.Edit(updated);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("delete")]
        public ActionResult Delete(int id)
        {
            var model = _armorService.GetById(id);
            return View(model);
        }

        [HttpPost("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _armorService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
