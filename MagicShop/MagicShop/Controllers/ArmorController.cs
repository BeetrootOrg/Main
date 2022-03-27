using BLL.Services.Interfaces;
using DLL.Entites.Base;
using Microsoft.AspNetCore.Mvc;
using Shared.Models;

namespace MagicShop.Controllers
{
    [Route("armor")]
    public class ArmorController : GenericController<Armor, ArmorModel>
    {
        public ArmorController(ICrudService<Armor, ArmorModel> crudService) : base(crudService)
        {
        }
    }
}
