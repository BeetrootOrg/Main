using DLL.Entites.Base;
using DLL.Enums;

namespace DLL.Entites
{
    public class RangeWeapon : BaseWeapon
    {
        public RangeWeaponType RangeWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Range;
    }
}
