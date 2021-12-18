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

            list.Add(new Person("F", "L"));
            list.Add(new Person("D", "M"));
            list.Add(new Person("Dima", "Misik"));
            list.Add(new Person("G", "T"));
            list.Add(new Person("S", "P"));

            ShowAll(list);

            Console.WriteLine(list.Count);
            Console.WriteLine(list[1]);

            var deleted = list.Remove(new Person("F", "L"));
            Console.WriteLine(deleted);

            list.RemoveAt(0);
            list.RemoveRange(1, 2);

            list.AddRange(list);
            list.Insert(2, new Person("Y", "L"));
            list.InsertRange(3, list);

            // need to implement IComparable on Person to work
            // list.Sort();
            list.Reverse();

            var contains = list.Contains(new Person("F", "L"));
            Console.WriteLine(contains);

            list.Clear();
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