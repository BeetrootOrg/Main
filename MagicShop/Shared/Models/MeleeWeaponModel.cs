using DLL.Enums;
using Shared.Models.Base;

namespace Shared.Models
{
    public class MeleeWeaponModel : BaseWeaponModel
    {
        public MeleeWeaponType MeleeWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Meelee;
    }
}
