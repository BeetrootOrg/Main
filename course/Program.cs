using System;

namespace ConsoleApp
{
    class Engine
    {
        public string EngineType { get; set; }
        public string FuelType { get; set; }
    }

    class ElectricEngine : Engine
    {
        public string ChargeCapacity { get; init; }
    }

    class Tire
    {
        public double Diameter { get; set; }
        public string Mark { get; set; }
        public string Modle { get; set; }
    }

    class Vehicle
    {
        public Engine Engine { get; set; }
        public string Color { get; set; }
        public string TransmissionType { get; set; }
        public int PassangersQuantity { get; init; }
        public Tire[] Tires { get; set; }
    }

    class Truck : Vehicle
    {
        public int CargoMaxCapacity { get; init; }
        public int SuspensionQuantity { get; init; }
    }

    class Car : Vehicle
    {
        public int DoorsQuantity { get; init; }
        public bool WithRoof { get; set; }
    }

    class Worker
    {
        public string Name { get; set; }
        public string JobPosition { get; set; }
    }

    class RepairTask
    {
        public string RepairName { get; set; }
        public string RepairDescription { get; set; }
        public Vehicle VehicleToRepair { get; init; }
        public DateTime EndOfWorkTime { get; set; }
        public Worker ResponsibleWorker { get; set; }
    }

    class AutoService
    {
        public string Name { get; set; }
        public Worker[] Workers { get; set; }
        private RepairTask[] RepairTasks { get; set; }
    }
}
