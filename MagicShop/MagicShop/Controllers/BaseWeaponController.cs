using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("weapon")]
    public class BaseWeaponController : GenericController<BaseWeapon,BaseWeaponModel>
    {
        private readonly IWeaponService _weaponService;
        public BaseWeaponController(ICrudService<BaseWeapon, BaseWeaponModel> crudService, IWeaponService weaponService, ICartService cartService) 
            : base(crudService, cartService)
        {
            _weaponService = weaponService;
        }

        [HttpGet("getAll")]
        public override async Task<ActionResult> Index()
        {
            return View(await _weaponService.GetAllWeapons());
        }
             
    }
}
