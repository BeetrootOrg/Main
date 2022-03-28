using AutoMapper;
using DLL.Entites;
using Shared.Models;

namespace MagicShop.MappingProfiles

{
    public class AccessoriesProfile : Profile
    {
        public AccessoriesProfile()
        {
            CreateMap<Accessories, AccessoriesModel>();
        }
    }
}
