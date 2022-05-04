using AutoMapper;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.MappingProfiles
{
    public class MagicWeaponProfile : Profile
    {
        public MagicWeaponProfile()
        {
            CreateMap<MagicWeapon, MagicWeaponModel>();
        }
    }
}
