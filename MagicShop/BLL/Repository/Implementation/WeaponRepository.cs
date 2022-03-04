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

        public RangeWeapon GetRangeById(int id)
        {
            return _armoryDbContext.RangeWeapon.FirstOrDefault(x => x.Id == id);
        }
        public MeleeWeapon GetMeleeById(int id)
        {
            return _armoryDbContext.MeleeWeapon.FirstOrDefault(x => x.Id == id);
        }
        public MagicWeapon GetMagicById(int id)
        {
            return _armoryDbContext.MagicWeapon.FirstOrDefault(x => x.Id == id);
        }
        public void CreateRange(RangeWeapon model)
        {
            _armoryDbContext.RangeWeapon.Add(model);
            _armoryDbContext.SaveChanges();
        }
        public void CreateMelee(MeleeWeapon model)
        {
            _armoryDbContext.MeleeWeapon.Add(model);
            _armoryDbContext.SaveChanges();
        }
        public void CreateMagic(MagicWeapon model)
        {
            _armoryDbContext.MagicWeapon.Add(model);
            _armoryDbContext.SaveChanges();
        }
    }
}
