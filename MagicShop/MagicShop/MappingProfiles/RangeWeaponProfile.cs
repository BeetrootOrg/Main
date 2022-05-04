using AutoMapper;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.MappingProfiles
{
    public class RangeWeaponProfile : Profile
    {
        public RangeWeaponProfile()
        {
            CreateMap<RangeWeapon, RangeWeaponModel>();
        }
    }
}
