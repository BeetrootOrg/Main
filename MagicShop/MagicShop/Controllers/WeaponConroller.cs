using BLL.Services.Interfaces;
using DLL.Entites;
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
        [HttpGet("getRangeWeapon/{id}")]
        public ActionResult DetailsRange(int id)
        {
            var model = _weaponService.GetRangeById(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet("getMeleeWeapon/{id}")]
        public ActionResult DetailsMelee(int id)
        {
            var model = _weaponService.GetMeleeById(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }
        [HttpGet("getMagicWeapon/{id}")]
        public ActionResult DetailsMagic(int id)
        {
            var model = _weaponService.GetMagicById(id);
            if (model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpGet("createRange")]
        public ActionResult CreateRange()
        {
            return View();
        }

        [HttpPost("createRange")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRange(RangeWeapon model)
        {
            try
            {
                _weaponService.CreateRange(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet("createMelee")]
        public ActionResult CreateMelee()
        {
            return View();
        }

        [HttpPost("createMelee")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMelee(MeleeWeapon model)
        {
            try
            {
                _weaponService.CreateMelee(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [HttpGet("createMagic")]
        public ActionResult CreateMagic()
        {
            return View();
        }

        [HttpPost("createMagic")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMagic(MagicWeapon model)
        {
            try
            {
                _weaponService.CreateMagic(model);
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
