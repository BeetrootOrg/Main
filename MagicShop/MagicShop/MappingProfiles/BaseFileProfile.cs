using AutoMapper;
using DAL.Entites.Base;
using Shared.Models.Base;

namespace MagicShop.MappingProfiles
{
    public class BaseFileProfile : Profile
    {
        public BaseFileProfile()
        {
            CreateMap<BaseFile, BaseFileModel>();
        }
    }
}
