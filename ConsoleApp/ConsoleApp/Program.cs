using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    record Person(string FirstName, string LastName)
    {
    }

    class Program
    {
        static void Main()
        {
            var list = new List<Person>();

            list.Add(new Person("F", "L"));
            list.Add(new Person("First", "Last"));

            ShowAll(list);
        }

        static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}