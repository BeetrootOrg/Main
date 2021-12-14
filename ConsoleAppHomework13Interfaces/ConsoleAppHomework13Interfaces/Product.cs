using ConsoleAppHomework13Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces
{
    public class Product: IProduct
    {
        public string Name { get; set; } 
        public int Price { get; set; }
        public string Description { get; set; }

    }
}
