using DLL.Enums;
using Shared.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    internal class ArmorModel : BaseEntityModel
    {
        public ArmorMaterialType ArmorMaterialType { get; set; }
        public ArmorType ArmorType { get; set; }
        public int Protection { get; set; }
        public int PhysicalRezist { get; set; }
        public int MagicRezist { get; set; }
        public int FireRezist { get; set; }
        public int IceRezist { get; set; }
        public int PoisonRezist { get; set; }
    }
}
