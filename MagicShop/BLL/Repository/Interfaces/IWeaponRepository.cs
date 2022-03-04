using DLL.Entites;
using DLL.Entites.Base;

namespace BLL.Repository.Interfaces
{
    public interface IWeaponRepository
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
