using DLL.Entites.Base;
using DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entites
{
    public class MeleeWeapon : BaseWeapon
    {
        public MeleeWeaponType MeleeWeaponType { get; set; }
        public WeaponType WeaponType => WeaponType.Meelee;
    }
}
