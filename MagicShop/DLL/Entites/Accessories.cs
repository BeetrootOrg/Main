using DLL.Entites.Base;
using DLL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Entites
{
    public class Accessories : BaseEntity
    {
        public string ActiveEffect { get; set; }
        public AccessoriesType AccessoriesType { get; set; }
    }
}
