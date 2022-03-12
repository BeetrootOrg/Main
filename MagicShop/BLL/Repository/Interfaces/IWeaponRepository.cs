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
        void EditRange(RangeWeapon updated);
        void DeleteRange(int id);
        void EditMelee(MeleeWeapon updated);
        void DeleteMelee(int id);
        void EditMagic(MagicWeapon updated);
        void DeleteMagic(int id);
    }
}
