using AutoMapper;
using DAL.Entites;
using Shared.Models;

namespace MagicShop.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserModel>();
        }
    }
}
