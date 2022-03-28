using AutoMapper;
using DLL.Entites.Base;
using Shared.Models;

namespace MagicShop.MappingProfiles
{
    public class ArmorProfile : Profile
    {
        public ArmorProfile()
        {
            CreateMap<Armor, ArmorModel>();
        }
    }
}
