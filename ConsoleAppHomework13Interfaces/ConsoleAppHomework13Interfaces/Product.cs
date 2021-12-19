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
        public int Id { get; set; }
        public string Name { get; set; } 
        public int Price { get; set; }
        public string Description { get; set; }

        public Product(string name, int price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }
    }
}
