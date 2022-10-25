using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp
{
    //i.safontev/homework/11-polymoprhism

    class AutoService
    {
        public string Name { get; set; }
        public Client[] Clients { get; set; }

    }

    class Vehicle
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public bool IsFinished { get; set; }

        public Engine Engine { get; set; }
        public Wheel[] Wheels { get; set; }
        public double MaxSpeed { get; set; }

    }
    class Engine
    {
        public string TypeOfPower { get; set; }
        public int CountOfCylinders { get; set; }
        public double Capacity { get; set; }

    }

    class Wheel
    {
        public int CountOfWheel { get; set; }
        public string TypeOfTire { get; set; }

    }

    class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OrderID { get; set; }
        public Vehicle ClientVehicle { get; set; }

    }
    class Program
    {
        static void Main()
        {

        }
    }
}