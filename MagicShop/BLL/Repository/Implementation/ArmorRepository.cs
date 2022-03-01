using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Implementation
{
    public class ArmorRepository : IArmorRepository
    {
        private readonly ArmoryDbContext _armoryDbContext;

        public ArmorRepository(ArmoryDbContext armoryDbContext)
        {
            _armoryDbContext = armoryDbContext;
        }
        public List<Armor> GetAll()
        {
            return _armoryDbContext.Armor.ToList();
            
        }
    }
}
