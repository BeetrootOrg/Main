using BLL.Repository.Interfaces;
using DLL.Context;
using DLL.Entites.Base;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repository.Implementation
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ArmoryDbContext _armoryDbContext;
        public WeaponRepository(ArmoryDbContext armoryDbContext)
        {
            _armoryDbContext = armoryDbContext;
        }

        public async Task<List<BaseWeapon>> GetAllWeapons()
        {
            var result = new List<BaseWeapon>();
            var melee = await _armoryDbContext.MeleeWeapon.ToListAsync();
            var magic = await _armoryDbContext.MagicWeapon.ToListAsync();
            var range = await _armoryDbContext.RangeWeapon.ToListAsync();
            result.AddRange(melee);
            result.AddRange(magic);
            result.AddRange(range);
            return result;
        }

    }
}
