using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12HomeworkInheritancePolymorphism
{
    public class Order
    {
        public int VehicleID { get; set; }
        public Client Client { get; set; }
        public decimal Sum { get; set; }
        public string Status { get; set; }

    }
}
