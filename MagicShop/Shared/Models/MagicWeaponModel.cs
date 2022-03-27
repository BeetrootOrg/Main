using DLL.Enums;
using Shared.Models.Base;

namespace Shared.Models
{
    public class MagicWeaponModel : BaseWeaponModel
    {
        public MagicWeaponType MagicWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Magic;
    }
}
