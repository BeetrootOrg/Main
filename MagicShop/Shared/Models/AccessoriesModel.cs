using DLL.Enums;
using Shared.Models.Base;

namespace Shared.Models
{
    public class AccessoriesModel : BaseEntityModel
    {
        public string? ActiveEffect { get; set; }
        public AccessoriesType AccessoriesType { get; set; }
    }
}
