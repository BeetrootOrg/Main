using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.IO;
using System.Text;

namespace ConsoleApp
    //i.safontev/classwork/20-reflection
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

        public void SayHello() => Console.WriteLine($"Hello, {Name}");
        public void SaySome(string something) => Console.WriteLine($"Hello, {something}");
        public void SayInteger(int number) => Console.WriteLine($"Hello, {number}");
        public void SayALot(string thing, int times, DateTime createdAt)
            => Console.WriteLine($"{thing} was created {createdAt} ({times} times)");
    }

    record ExampleClass
    {
        public string Example { get; set; }
    }

    class Program
    {
        static void Main()
        {
            var assembly = typeof(StringBuilder).Assembly;

            Console.WriteLine($"Types in assembly {assembly.FullName}:");
            foreach (var type in assembly.GetTypes())
            {
                Console.WriteLine($"\t{type.FullName}");
            }
        }

        static void DynamicInvocation()
        {
            var assemblyName = "ConsoleApp";

            Console.WriteLine("Enter class name you want to create:");
            var classname = Console.ReadLine();

            var typeToCreate = Type.GetType($"{assemblyName}.{classname}, {assemblyName}", true);

            var obj = Activator.CreateInstance(typeToCreate);
            SetDefaultValues(obj);

            while (true)
            {
                Console.WriteLine("Enter property/method name:");
                var propertyMethodName = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(propertyMethodName))
                {
                    var propertyInfo = typeToCreate.GetProperty(propertyMethodName);

                    if (propertyInfo == null)
                    {
                        var methodInfo = typeToCreate.GetMethod(propertyMethodName);

                        if (methodInfo == null)
                        {
                            Console.WriteLine($"Missing property/method info {propertyMethodName}");
                        }
                        else
                        {
                            var paramsInfo = methodInfo.GetParameters();

                            if (paramsInfo.Length == 0)
                            {
                                methodInfo.Invoke(obj, null);
                            }
                            else
                            {
                                var args = new object[paramsInfo.Length];
                                for (int i = 0; i < paramsInfo.Length; i++)
                                {
                                    Console.WriteLine($"Enter {i + 1} argument:");
                                    var arg = Console.ReadLine();
                                    args[i] = ConvertTo(arg, paramsInfo[i].ParameterType);
                                }

                                methodInfo.Invoke(obj, args);
                            }

                        }
                    }
                    else
                    {
                        Console.WriteLine("Enter property value:");
                        var propertyValue = Console.ReadLine();

                        propertyInfo.SetValue(obj, ConvertTo(propertyValue, propertyInfo.PropertyType));
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

        private static object ConvertTo(string value, Type type)
        {
            if (type == typeof(string))
            {
                return value;
            }

            if (type == typeof(int) && int.TryParse(value, out var intVal))
            {
                return intVal;
            }

            if (type == typeof(DateTime) && DateTime.TryParse(value, out var dateTime))
            {
                return dateTime;
            }

            throw new ArgumentException($"Cannot convert value to type {type}");
        }
    }
}