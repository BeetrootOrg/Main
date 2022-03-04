using BLL.Repository.Interfaces;
using BLL.Services.Interfaces;
using DLL.Entites;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class WeaponService : IWeaponService
    {
        private IWeaponRepository _weaponRepository;

        public WeaponService(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }
        public List<BaseWeapon> GetAllWeapons()
        {
            return _weaponRepository.GetAllWeapons();
        }
        public List<RangeWeapon> GetRangeWeapons()
        {
            return _weaponRepository.GetRangeWeapons();
        }
        public List<MeleeWeapon> GetMeleeWeapons()
        {
            return _weaponRepository.GetMeleeWeapons();
        }
        public List<MagicWeapon> GetMagicWeapons()
        {
            return _weaponRepository.GetMagicWeapons();
        }
        public RangeWeapon GetRangeById(int id)
        {
            return _weaponRepository.GetRangeById(id);
        }
        public MeleeWeapon GetMeleeById(int id)
        {
            return _weaponRepository.GetMeleeById(id);
        }
        public MagicWeapon GetMagicById(int id)
        {
            return _weaponRepository.GetMagicById(id);
        }
        public void CreateRange(RangeWeapon model)
        {
            _weaponRepository.CreateRange(model);
        }
        public void CreateMelee(MeleeWeapon model)
        {
            _weaponRepository.CreateMelee(model);
        }
        public void CreateMagic(MagicWeapon model)
        {
            _weaponRepository.CreateMagic(model);
        }
    }
}
