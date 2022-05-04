using BLL.Services.Interfaces;
using DLL.Entites;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MagicShop.Controllers
{
    [Route("range-weapon")]
    public class RangeWeaponController : GenericController<RangeWeapon, RangeWeaponModel>
    {
        public RangeWeaponController(ICrudService<RangeWeapon, RangeWeaponModel> crudService, ICartService cartService) : base(crudService, cartService)
        {
        }
    }
}
