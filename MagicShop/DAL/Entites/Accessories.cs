using DLL.Entites.Base;
using DLL.Enums;

namespace DLL.Entites
{
    public class Accessories : BaseEntity
    {
        public string? ActiveEffect { get; set; }
        public AccessoriesType AccessoriesType { get; set; }
    }
}
