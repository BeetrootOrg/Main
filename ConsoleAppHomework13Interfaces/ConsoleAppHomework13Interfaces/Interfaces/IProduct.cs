using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces.Interfaces
{
    internal interface IProduct
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
