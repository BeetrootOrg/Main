using System;

namespace ConsoleApp
{
    class Programm
    {
        static void Main()
        {
            Console.WriteLine("Write your first line:");
            string fstr = Console.ReadLine();
            Console.WriteLine("Write your second line :");
            string sstr = Console.ReadLine();
            Compare(fstr, sstr);
            Console.WriteLine(" ");

            Console.WriteLine("Write another one line:");
            string symstr = Console.ReadLine();
            Analyze(symstr);
            Console.WriteLine(" ");

            Console.WriteLine("Write another one line to sort symbols in alphabetical order:");
            string alfstr = Console.ReadLine();
            Sort(alfstr);
            Console.WriteLine(" ");

            Console.WriteLine("Write another one line to delite duplicated symbols in it:");
            string dupstr = Console.ReadLine();
            Duplicate(dupstr);
            Console.WriteLine(" ");

        }
        static void Compare(string fstr, string sstr)
        {
            bool cb;
            bool result = (fstr == sstr) ? cb = true : cb = false;
            Console.WriteLine($"Is this lines are equel: {cb}");

        }
        static void Analyze(string symstr)
        {
            int i;
            int symstrLength = symstr.Length;
            for (i = 0; i < symstrLength; ++i)
            {
                int symstr1 = symstr.Length - 1;
                symstr = symstr.Remove(symstr1);
            }
            Console.WriteLine($"There is {i} symbols");
        }
        static void Sort(string alfstr)
        {
            char[] alfstrX = alfstr.ToCharArray();
            Array.Sort(alfstrX);
            Console.WriteLine(alfstrX);
        }
        static void Duplicate(string dupstr)
        {
            dupstr = new string(dupstr.Distinct().ToArray());
            Console.WriteLine(dupstr);
        }
    }
}