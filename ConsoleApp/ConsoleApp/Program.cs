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
            var list = new List<Person>
            {
                new Person("F", "L"),
                new Person("First", "Last")
            };

            // almost analogue to above
            //new Person[]
            //{
            //    new Person("F", "L"),
            //    new Person("First", "Last")
            //};

            list.Add(new Person("D", "M"));

            ShowAll(list);

            Console.WriteLine(list.Count);
            Console.WriteLine(list[1]);
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