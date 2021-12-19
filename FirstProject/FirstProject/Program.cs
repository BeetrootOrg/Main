using System;

namespace ConsoleApp
{
    class AutoService
    {
        Vehicle[] Vehicles { get; set; }
        Wheel[] Wheels { get; set; }
        Engine[] Engines { get; set; }
        Suspension[] Suspension { get; set; }
    }

    class Vehicle
    {
        public string Brand { get; init; }
        public string BodyType { get; init; }
        public string EngineType { get; init; }
    }

    class Wheel
    {
        public int Size { get; set; }
        public string TypeOfRubber { get; set; }
        public string Rims { get; set; }

    }

    class Engine
    {
        public int Power { get; set; }
        public string EngineType { get; init; }
        public int CylindersCount { get; set; }
        public float EngineCapacity { get; set; }
    }

    class Suspension
    {
        public int SuspensionSide { get; init; }
        public string TypeOfSuspension { get; init; }

    }

    public class Program
    {
        static void Main()
        {

        }
    }
}