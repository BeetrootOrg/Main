using DLL.Enums;

namespace DLL.Entites.Base
{
    public class BaseWeapon : BaseEntity
    {
        public int Damage { get; set; }
        public DamageType DamageType { get; set; }
        public HandWeaponType HandWeaponType { get; set; }

    }
}

