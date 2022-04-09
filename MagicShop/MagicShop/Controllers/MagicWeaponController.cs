using BLL.Services.Interfaces;
using DLL.Context;
using DLL.Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MagicShop.Controllers
{
    [Route("magic-weapon")]
    public class MagicWeaponController : GenericController<MagicWeapon, MagicWeaponModel>
    {
        public MagicWeaponController(ICrudService<MagicWeapon, MagicWeaponModel> crudService) : base(crudService)
        {
        }

    }
}
