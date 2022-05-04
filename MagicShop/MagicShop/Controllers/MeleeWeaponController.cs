using BLL.Services.Interfaces;
using DLL.Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MagicShop.Controllers
{
    [Route("melee-weapon")]

    public class MeleeWeaponController : GenericController<MeleeWeapon, MeleeWeaponModel>
    {
        public MeleeWeaponController(ICrudService<MeleeWeapon, MeleeWeaponModel> crudService, ICartService cartService) : base(crudService, cartService)
        {
        }
    }
}
