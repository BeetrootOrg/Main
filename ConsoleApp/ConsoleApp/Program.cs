using System;
using System.Linq;

namespace ConsoleApp
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class DefaultValueAttribute : Attribute
    {
        public object Value { get; init; }
        public bool NeedSetup { get; init; }

        public DefaultValueAttribute(object defaultValue)
        {
            Value = defaultValue;
        }
    }

    record TestClass
    {
        [DefaultValue("Dima", NeedSetup = true)]
        public string Name { get; set; }

        public string Description { get; set; }
        
        [DefaultValue(42)]
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
            SetDefaultValues(obj);

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
                        else if (propertyInfo.PropertyType == typeof(DateTime) && DateTime.TryParse(propertyValue, out var dateTime))
                        {
                            propertyInfo.SetValue(obj, dateTime);
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

        private static void SetDefaultValues(object obj)
        {
            var type = obj.GetType();

            foreach (var propertyInfo in type.GetProperties())
            {
                var attribute = propertyInfo.GetCustomAttributes(typeof(DefaultValueAttribute), true)
                    .FirstOrDefault();

                if (attribute is DefaultValueAttribute defaultValueAttribute && defaultValueAttribute.NeedSetup)
                {
                    propertyInfo.SetValue(obj, defaultValueAttribute.Value);
                }
            }
        }
    }
}