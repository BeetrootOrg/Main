using System;

namespace ConsoleApp
{
    record TestClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Age { get; set; }
        public DateTime CreatedDate { get; set; }
    }

    record ExampleClass
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

            while (true)
            {
                Console.WriteLine("Enter property name:");
                var propertyName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(propertyName))
                {
                    Console.WriteLine("Enter property value:");
                    var propertyValue = Console.ReadLine();

                    var propertyInfo = typeToCreate.GetProperty(propertyName);
                    
                    if (propertyInfo == null)
                    {
                        Console.WriteLine($"Missing property info {propertyName}");
                    }
                    else
                    {
                        if (propertyInfo.PropertyType == typeof(string))
                        {
                            propertyInfo.SetValue(obj, propertyValue);
                        }
                        else if (propertyInfo.PropertyType == typeof(int) && int.TryParse(propertyValue, out var intVal))
                        {
                            propertyInfo.SetValue(obj, intVal);
                        }
                        else
                        {
                            Console.WriteLine($"Cannot convert value to type {propertyInfo.PropertyType}");
                        }
                    }
                } 
                else
                {
                    break;
                }
            }

            Console.WriteLine(obj);
        }
    }
}