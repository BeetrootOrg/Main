using System;
using System.Linq;
using System.Text;

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
            var assembly = typeof(Program).Assembly;
            Console.WriteLine($"Info about assembly {assembly}");


            //About TestClass
            var aboutTestClass= typeof(TestClass);

            foreach (var item in aboutTestClass.GetProperties())
            {
                Console.WriteLine($"About TestClass Properties: {item}");
            }

            foreach (var item in aboutTestClass.GetMethods())
            {
                Console.WriteLine($"About TestClass Methods: {item}, return type {item.ReturnType}");

                foreach (var parameters in item.GetParameters())
                {
                    Console.WriteLine($"Method parameters: {parameters}");
                }
            }


            //About DefaultValueAttribute Class
            var aboutClass = typeof(DefaultValueAttribute);

            foreach (var item in aboutClass.GetProperties())
            {
                Console.WriteLine($"About DefaultValueAttribute Properties: {item}");
            }

            foreach (var item in aboutClass.GetMethods())
            {
                Console.WriteLine($"About DefaultValueAttribute Methods: {item}, return type {item.ReturnType}");

                foreach (var parameters in item.GetParameters())
                {
                    Console.WriteLine($"Method parameters: {parameters}");
                }
            }

        }
    }
}