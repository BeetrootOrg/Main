using System;
namespace ConsoleApp
{
    class AutoService
    {
        public Tasks Tasks { get; set; }
    }
    class Tasks
    {
        public Client Client { get; set; }
        public int ToDoList{ get; set; }
        public int Terms { get; set; }
    }
    class Client
    {
        public string FullName { get; set; }
        public Vehicle Vehicle { get; set; }
        public int PhoneNumber { get; set; }
        public int FinancialSituation { get; init; }
    }
    class Vehicle
    {
        public string VehicleBrand { get; set; }
        public Engine Engine { get; set; }
        public Wheels Wheels{ get; set; }
        public Frame Frame { get; init; }
    }
    class Engine
    {
        public int Cylinders { get; set; }
        public string Fuel { get; set; }
    }
    class Wheels
    {
        public string TireType { get; set; }
        public float Diameter { get; set; }
    }
    class Frame
    {
        public int YearOfIssue { get; set; }
        public float Value{ get; set; }
    }

    class WorkProcess
    {
        public bool Diagnostics { get; init; }
        public bool PurchaseOfParts { get; init; }
        public Tasks Task { get; init; }
        public Staff Staff { get; init; }
    }
    class Staff
    {
        public Mechanic Mechanic { get; init; }
        public Electrician Electrician{ get; init; }
    }
    class Mechanic
    {
        public int PhoneNumber{ get; init; }
        public int Payment{ get; init; }
        public int WorkExperience{ get; init; }
    }
    class Electrician
    {
        public int PhoneNumber{ get; init; }
        public int Payment{ get; init; }
        public int WorkExperience{ get; init; }
    }
}