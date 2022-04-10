using DLL.Entites.Base;
using DLL.Enums;

namespace DLL.Entites
{
    public class MagicWeapon : BaseWeapon
    {
        public MagicWeaponType MagicWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Magic;

    }
}
