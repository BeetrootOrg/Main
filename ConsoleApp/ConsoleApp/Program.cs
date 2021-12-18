using System;

namespace ConsoleApp
{
    class AutoService
    {
        Vehicle[] Vehicles { get; set; }
        Wheel[] Wheels { get; set; }
        Engine[] Engines { get; set; }
        Transmission[] Transmissions { get; set; }
    }

    class Vehicle
    {
        string Brand { get; init; }
        string CarClass { get; init; }
        string EngineType { get; init; }
    }

    class Wheel
    {        
        int Diagonal { get; set; }
        string TypeOfRubber { get; set; }

    }

    class Engine
    {
        int Power{ get; set; }
        string EngineType { get; init; }
        int  CylindersCount { get; set; }
    }

    class Transmission
    {
        byte NumberOfGears { get; init; }
        string TypeOfTransmission { get; init; }

    }

    public class Program
    {
        static void Main()
        {

        }           
    }
}