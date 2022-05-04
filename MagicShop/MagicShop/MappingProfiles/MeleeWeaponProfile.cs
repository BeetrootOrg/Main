using AutoMapper;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.MappingProfiles
{
    public class MeleeWeaponProfile : Profile
    {
        public MeleeWeaponProfile()
        {
            CreateMap<MeleeWeapon, MeleeWeaponModel>();
        }
    }
}
