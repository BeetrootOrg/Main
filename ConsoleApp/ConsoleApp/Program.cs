using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class Program
    {
        static void Main()
        {
            Stack<string> peoples = new Stack<string>();

            peoples.Push("Ann");
            peoples.Push("Dave");
            peoples.Push("Ivan");
            peoples.Push("Pedro");
            peoples.Push("Luis");
            peoples.Push("Valera");

            foreach (string people in peoples)
            {
                Console.WriteLine(people);
            }

            peoples.Clear();

            foreach (string people in peoples)
            {
                Console.WriteLine(people);
            }

        }
    }
}