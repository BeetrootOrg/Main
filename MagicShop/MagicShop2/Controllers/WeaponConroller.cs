using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagicShop.Controllers
{
    [Route("weapon")]
    public class WeaponConroller : Controller
    {
        private IWeaponService _weaponService;
        public WeaponConroller(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpGet("getAll")]
        public ActionResult Index()
        {
            var result = _weaponService.GetAllWeapons();
            return View(result);
        }
        [HttpGet("getRange")]
        public ActionResult Range()
        {
            var result = _weaponService.GetRangeWeapons();
            return View(result);
        }
        [HttpGet("getMelee")]
        public ActionResult Melee()
        {
            var result = _weaponService.GetMeleeWeapons();
            return View(result);
        }
        [HttpGet("getMagic")]
        public ActionResult Magic()
        {
            var result = _weaponService.GetMagicWeapons();
            return View(result);
        }
        // GET: WeaponConroller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WeaponConroller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WeaponConroller/Create
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

        // GET: WeaponConroller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WeaponConroller/Edit/5
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

        // GET: WeaponConroller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WeaponConroller/Delete/5
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
