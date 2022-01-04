using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    record Person(string FirstName, string LastName);

    public class Program
    {
        static void Main()
        {
            var list = new List<Person>
            {
                new Person("F", "L"),
                new Person("Fisrt", "Last"),
                new Person("D", "M"),
                new Person("Dima", "Last")
            };

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