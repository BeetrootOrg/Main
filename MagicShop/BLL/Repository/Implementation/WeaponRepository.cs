using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Implementation
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ArmoryDbContext _armoryDbContext;

        public WeaponRepository(ArmoryDbContext armoryDbContext)
        {
            _armoryDbContext = armoryDbContext;
        }
        public List<BaseWeapon> GetAllWeapons()
        {
            var result = new List<BaseWeapon>();
            result.AddRange(_armoryDbContext.RangeWeapon);
            result.AddRange(_armoryDbContext.MagicWeapon);
            result.AddRange(_armoryDbContext.MeleeWeapon);

            return result;
        }
        public List<RangeWeapon> GetRangeWeapons()
        {
            var result = new List<RangeWeapon>();
            result.AddRange(_armoryDbContext.RangeWeapon);
            return result;
        }
        public List<MeleeWeapon> GetMeleeWeapons()
        {
            var result = new List<MeleeWeapon>();
            result.AddRange(_armoryDbContext.MeleeWeapon);
            return result;
        }
        public List<MagicWeapon> GetMagicWeapons()
        {
            var result = new List<MagicWeapon>();
            result.AddRange(_armoryDbContext.MagicWeapon);
            return result;
        }

    }
}
