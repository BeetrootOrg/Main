using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;


namespace ConsoleApp
{
    class MyInnerClass
    {
        public string Name { get; set; }
        public int Number { get; set; }
    }
    class MyOuterClass
    {
        public MyInnerClass[] inner = new MyInnerClass[2];
        public string[] Answer = new string[2];

        public MyInnerClass this[int index]
        {
            get { return inner[index]; }
            set { inner[index] = value; }
        }
    }
    class MyClass
    {
        public String[] m_StringArray = { "Apples", "Oranges", "Pears" };
        public MyInnerClass[] inner { get; set; }

        public String[] StringArray
        {
            get { return m_StringArray; }
            set { m_StringArray = value; }
        }
        public MyClass()
        {
            inner = new MyInnerClass[2];
        }
    }
    class ConsoleApp
    {
        static void Main(string[] args)
        {

            Console.WriteLine("\r\n a.tkachenko/homework/20-Reflections \r\n");

            var assemblyName = "ConsoleApp";
            Console.WriteLine("Enter class name you want to create:");
            var classname = "Vote"; //  Console.ReadLine();
            Console.WriteLine(classname);
            var typeToCreate = Type.GetType($"{assemblyName}.{classname}, {assemblyName}", true);
            var obj = Activator.CreateInstance(typeToCreate);

            // var propertyName = "Question";
            // var propertyValue = "How are you?";







            
            var propertyInfo = typeToCreate.GetProperty("Question");
            SetProperty(obj, "Question", "How are you?", propertyInfo);

            propertyInfo = typeToCreate.GetProperty("Answer");
            SetProperty(obj, "Answer", "Fine", propertyInfo, 0);













            MyInnerClass mic0 = new MyInnerClass { Name = "Test0", Number = 9 };
            MyOuterClass moc = new MyOuterClass();
            PropertyInfo piInner = moc.GetType().GetProperty("Item");
            piInner.SetValue(moc, mic0, new object[] { (int)0 });
            if (moc[0] == mic0)
                Console.WriteLine("MyInnerClass wurde zugewiesen.");
            PropertyInfo piAnsw = typeof(MyOuterClass).GetProperty("Answer");
            // piAnsw.SetValue(moc, propertyValue, new object[] { (int)0 });
            MyClass mc = new MyClass();
            PropertyInfo pinfo = typeof(MyClass).GetProperty("StringArray");
            SetProperty(mc, "StringArray", "Fine", pinfo, 0);

        }
        public static void ApplyValue(object obj, string property, object value,  int? index)
        {
            object target = obj; //  Data;
            var pi = target.GetType().GetProperty(property);
            if (index.HasValue && pi.GetIndexParameters().Length != 1)
            {
                target = pi.GetValue(target, null);
                var pp = pi.GetIndexParameters().Length;
                // var p = pi.GetIndexParameters()[0].ParameterType;

                // pi = target.GetType().GetProperties().First(p => p.GetIndexParameters().Length == 1 && p.GetIndexParameters()[0].ParameterType == typeof(int));
            }
            pi.SetValue(obj, value, index.HasValue ? new object[] { index.Value } : null);
        }
        private static void SetProperty(object obj, string propertyName, string propertyValue, PropertyInfo propertyInfo, int index)
        {
            if (propertyInfo == null)
            {
                Console.WriteLine($"Missing property info {propertyName}");
            }
            else
            {
                if (propertyInfo.PropertyType == typeof(String[]))
                {
                    object[] value = (object[])propertyInfo.GetValue(obj, null);
                    value[index] = propertyValue;
                    // propertyInfo.SetValue(obj, propertyValue, index.HasValue ? new object[] { index.Value } : null);
                }
                else
                {
                    Console.WriteLine($"Cannot convert value to type {propertyInfo.PropertyType}");
                }
            }
        }
        private static void SetProperty(object obj, string propertyName, string propertyValue, System.Reflection.PropertyInfo propertyInfo)
        {
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
                else if (propertyInfo.PropertyType == typeof(String[]))
                {
                    propertyInfo.SetValue(obj, propertyValue, new object[] { 0 });
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
    }
}
