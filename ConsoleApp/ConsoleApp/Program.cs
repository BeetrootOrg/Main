using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace ConsoleApp
{
    class TestClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    class ExampleClass
    {
        public string Example { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var assemblyName = "ConsoleApp";

            Console.WriteLine("Enter class name you want to create:");
            var classname = Console.ReadLine();

            var typeToCreate = Type.GetType($"{assemblyName}.{classname}, {assemblyName}", true);

            var obj = Activator.CreateInstance(typeToCreate);
        }
    }
}