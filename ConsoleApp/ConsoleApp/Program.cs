using System;

namespace ConsoleApp
{
    public class DefaultValueAttribute : Attribute
    {
        public object Value { get; init; }

        public DefaultValueAttribute(object defaultValue)
        {
            Value = defaultValue;
        }

    }

    record TestClass
    {
        [DefaultValue("Dima")]
        public string Name { get; set; }
        public string Description { get; set; }

    }

    public class Program
    {
        static void Main()
        {
            var asseblyName = "ConsoleApp";

            Console.WriteLine("Enter class name you want create:");
            var className = Console.ReadLine();

            var typeToCreate = Type.GetType($"{asseblyName}.{className}, {asseblyName}", true);

            var obj = Activator.CreateInstance(typeToCreate);

            while(true)
            {
                Console.WriteLine("Enter property name:");
                var propertyName = Console.ReadLine();

                if (!string.IsNullOrEmpty(propertyName))
                {
                    Console.WriteLine("Enter property value:");
                    var propertyValue = Console.ReadLine();

                    var propertyInfo = typeToCreate.GetProperty(propertyName);
                    
                    if (propertyInfo == null)
                    {
                        Console.WriteLine("Missing");
                    }

                }
                else
                {
                    break;
                }
            }
        }
    }
}