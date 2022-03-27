using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Models.Base;

namespace MagicShop.Controllers
{
    [Route("weapon")]
    public class BaseWeaponConroller : GenericController<BaseWeapon,BaseWeaponModel>
    {
        public BaseWeaponConroller(ICrudService<BaseWeapon, BaseWeaponModel> crudService) : base(crudService)
        {
        }

    }
}
