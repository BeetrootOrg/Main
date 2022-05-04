using AutoMapper;
using DLL.Entites.Base;
using Shared.Models.Base;

namespace MagicShop.MappingProfiles
{
    public class BaseWeaponProfile : Profile
    {
        public BaseWeaponProfile()
        {
            CreateMap<BaseWeapon, BaseWeaponModel>();
        }
    }
}
