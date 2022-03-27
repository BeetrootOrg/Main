using AutoMapper;
using DLL.Entites.Base;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
