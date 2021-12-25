using System;

namespace ConsoleApp
{


    class Engine
    { 
        bool isElectric { get; init; }
        int Capacity { get; set; }

    }
    class Base
    { 
        int Length { get; set; }    
        int Width { get; set; }
        int Clearance { get; set; }
    }
    class Wheel
    {
        string Tire { get; set; }
        string Disk { get; set; }
    }

    class Door
    { 
        bool Glass { get; set; }
        bool Decors { get; set; }
    }
    class Roof
    { 
        bool isGlass { get; set; }
        bool isMovable { get; set; }
    }

    class Vehicle
    { 
        Engine engines;
        Base bases;
        Wheel wheels;
        Door doors;
        Roof roof;
    
    }

    class Worker
    { 
        bool isStaff { get; set; }
        string FullName { get; set; }
    }

    class Moto : Vehicle
    {
        Engine engine;
        Base bases;
        Wheel[] wheels;

    }

    class Auto : Vehicle
    {
        Engine engine;
        Base bases;
        Wheel[] wheels;
        Door[] doors;
        Roof roof;

    }

    public class Autoservice
    {
        Vehicle[] vehicles { get; set; }
        Worker[] workers { get; set; }
    }
    public class Program
    {

        static void Main()
        {
            {      
                
            }
        }
    }
}