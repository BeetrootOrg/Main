using DLL.Enums;

namespace Shared.Models.Base
{
    public class BaseWeaponModel : BaseEntityModel
    {
        public int Damage { get; set; }
        public DamageType DamageType { get; set; }
        public HandWeaponType HandWeaponType { get; set; }

    }
}
