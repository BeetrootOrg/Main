using BLL.Services.Interfaces;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.Controllers
{
    public class MeleeWeaponController : GenericController<MeleeWeapon, MeleeWeaponModel>
    {
        public MeleeWeaponController(ICrudService<MeleeWeapon, MeleeWeaponModel> crudService) : base(crudService)
        {
        }
    }
}
