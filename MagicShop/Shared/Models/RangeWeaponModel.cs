using DLL.Enums;
using Shared.Models.Base;

namespace Shared.Models
{
    public class RangeWeaponModel : BaseWeaponModel
    {
        public RangeWeaponType RangeWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Range;
    }
}
