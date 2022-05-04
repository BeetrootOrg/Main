using Shared.Models;
using Shared.Models.Base;
using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface ICartService
    {
        void AddToCart(ClaimsPrincipal user, BaseEntityModel entityModel);
        void ClearCart(ClaimsPrincipal user);
        void RemoveFromCart(ClaimsPrincipal user, BaseEntityModel entityModel);
        CartModel GetCart(ClaimsPrincipal user);
    }
}
