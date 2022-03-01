using DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entites.Base
{
    public class BaseWeapon : BaseEntity
    {
        public int Damage { get; set; }
        public DamageType DamageType { get; set; }
        public HandWeaponType HandWeaponType { get; set; }

    }
}

