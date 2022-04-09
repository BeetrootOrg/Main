using DLL.Entites.Base;
using DLL.Enums;

namespace DLL.Entites
{
    public class MeleeWeapon : BaseWeapon
    {
        public MeleeWeaponType MeleeWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Meelee;
    }
}
