using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12HomeworkInheritancePolymorphism
{
    public class Vehicle
    {
        public List<Car> Cars { get; set; }
        public List<Moto> Motos { get; set; }
        public List<Truck> Trucks { get; set; }

        public virtual void Beep() => Console.WriteLine("beeeeeep");
    }
}
