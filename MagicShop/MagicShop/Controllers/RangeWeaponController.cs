using BLL.Services.Interfaces;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.Controllers
{
    public class RangeWeaponController : GenericController<RangeWeapon, RangeWeaponModel>
    {
        public RangeWeaponController(ICrudService<RangeWeapon, RangeWeaponModel> crudService) : base(crudService)
        {
        }
    }
}
