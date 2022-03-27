using DLL.Enums;
using Shared.Models.Base;

namespace Shared.Models
{
    public class ArmorModel : BaseEntityModel
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
