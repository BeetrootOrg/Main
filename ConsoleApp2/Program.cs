using System;

namespace ConsoleApp
{

    class SparePart
    {
        public string PartNumber { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
    class Engine : SparePart
    {
        public string EngineType { get; set; }
        public string FuelType { get; set; }
    }


    class Tire : SparePart
    {
        public double Diameter { get; set; }
        public string Mark { get; set; }
        public string Modle { get; set; }
    }

    class Car
    {
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public string TransmissionType { get; set; }
        public int PassangersQuantity { get; init; }
        public Tire[] Tires { get; set; }
    }

    class Program
    {
        static void Main()
        {
        }
    }
}