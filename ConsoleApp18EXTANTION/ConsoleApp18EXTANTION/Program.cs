using System;
using System.Collections.Generic;

namespace ConsoleApp18EXTANTION
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(Math.Ceiling((double)10/3));

            var test = new List<int>() { 1, 2, 3, 4, 5 };
            var rest = test.ChunkBy<List<int>, int>(2);
            Console.WriteLine(rest);
        }
    }
}
