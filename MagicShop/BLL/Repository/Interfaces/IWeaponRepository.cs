using DLL.Entites;
using DLL.Entites.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repository.Interfaces
{
    public interface IWeaponRepository
    {
        List<BaseWeapon> GetAllWeapons();
        List<RangeWeapon> GetRangeWeapons();
        List<MeleeWeapon> GetMeleeWeapons();
        List<MagicWeapon> GetMagicWeapons();
    }
}
