using BLL.Services.Interfaces;
using DLL.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Shared.Models;

namespace MagicShop.Controllers
{
    [Route("Accessories")]
    public class AccessoriesController : GenericController<Accessories, AccessoriesModel>
    {
        public AccessoriesController(ICrudService<Accessories, AccessoriesModel> crudService, ICartService cartService) : base(crudService, cartService)
        {
        }
    }
}
