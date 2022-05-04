using BLL.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Shared.Models;
using Shared.Models.Base;
using System.Security.Claims;

namespace BLL.Services.Implementation
{
    public class CartService : ICartService
    {
        private readonly IMemoryCache _cache;

        public CartService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void AddToCart(ClaimsPrincipal user, BaseEntityModel entityModel)
        {
            var cart = GetCart(user);
            cart.AddItem(entityModel);
            var key = GetKey(user);
            _cache.Set(key, cart);
        }

       public void ClearCart(ClaimsPrincipal user)
        {
            var cart = GetCart(user);
            cart.Clear();
            var key = GetKey(user);
            _cache.Set(key, cart);
        }

        public void RemoveFromCart(ClaimsPrincipal user, BaseEntityModel entityModel)
        {
            var cart = GetCart(user);
            cart.RemoveItem(entityModel);
            var key = GetKey(user);
            _cache.Set(key,cart);
        }

        public CartModel GetCart(ClaimsPrincipal user)
        {
            var key = GetKey(user);
            _cache.TryGetValue(key, out CartModel cart);
            if (cart == null)
            {
                cart = new CartModel();
                _cache.Set(key, cart);
            }
            return cart;
        }
        private string GetKey(ClaimsPrincipal user)
        {
            var key = user.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType)?.Value;
            if (key == null)
            {
                throw new UnauthorizedAccessException();
            }
            return key;
        }
    }
}
