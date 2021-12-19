using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppHomework13Interfaces.Interfaces
{
    public interface IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
    }
}
