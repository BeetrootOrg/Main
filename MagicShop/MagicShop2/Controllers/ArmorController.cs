using BLL.Services.Interfaces;
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

        // GET: ArmorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArmorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArmorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ArmorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArmorController/Edit/5
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

        // GET: ArmorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArmorController/Delete/5
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
