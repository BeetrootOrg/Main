using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Car
    {
        public Wheel[] Wheels = new Wheel[4];
        public Engine[] Engines { get; set; }

        public Base Base { get; set; }
        public Roof Roof { get; set; }

        public Car CreateCar()
        {
            return new Car();
        }
    }
}
