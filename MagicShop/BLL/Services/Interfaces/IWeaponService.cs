using BLL.Repository.Interfaces;
using DLL.Entites;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IWeaponService 
    {
        List<BaseWeapon> GetAllWeapons();
        List<RangeWeapon> GetRangeWeapons();
        List<MeleeWeapon> GetMeleeWeapons();
        List<MagicWeapon> GetMagicWeapons();
        RangeWeapon GetRangeById(int id);
        MeleeWeapon GetMeleeById(int id);
        MagicWeapon GetMagicById(int id);
        void CreateRange(RangeWeapon model);
        void CreateMelee(MeleeWeapon model);
        void CreateMagic(MagicWeapon model);
    }
}
