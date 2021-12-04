using System;
using System.Text;
namespace ConsoleApp
{
    class Program
    {
        //i.safontev/homework/06-strings
        static void Main(string[] args)
        {
            Console.WriteLine($"Enter two strings: ");
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine($"Are these two strings equal: {Compare(a, b)}");

            Console.WriteLine($"\nEnter the line: ");
            string c = Console.ReadLine();
            Analyze(c);

            Console.WriteLine($"\nEnter the line: ");
            string d = Console.ReadLine();
            Sort(d);
            Console.WriteLine($"\nAfter sorting: {Sort(d)}");

            Console.WriteLine($"\nEnter the line: ");
            string e = Console.ReadLine();
            char[] array1 = Duplicate(e);
            int charArrayLength = array1.Length;
            Console.WriteLine($"Duplicated chars is: ");
            for(int i = 0; i < charArrayLength; i++)
            {
                Console.Write($"{array1[i]} ");
            }
        }
        static void Swap(ref char a, ref char b)
        {
            char temp = a;
            a = b;
            b = temp;
        }
        static bool Compare(string a,string b)
        {
            if (a.Length != b.Length) { return false; }
            int length = a.Length;
            for(int i = 0; i < length; i++)
            {
                if (a[i] != b[i]) { return false; }
            }
            return true;
        }
        static void Analyze(string a)
        {
            int length = a.Length;
            int alphabeticCharUpperCount = 0;
            int alphabeticCharLowerCount = 0;
            int digitsCount = 0;
            int specialCharactersCount = 0;
            char[] array1 = a.ToCharArray();
            for (int i = 0; i < length; i++)
            {
                if (array1[i] >= 65 && array1[i] <= 90)  { alphabeticCharUpperCount++; }
                else if (array1[i] >= 97 && array1[i] <= 122) { alphabeticCharLowerCount++; }
                else if (array1[i] >= 48 && array1[i] <= 57) { digitsCount++; }
                else { specialCharactersCount++; }
            }
            Console.WriteLine($"Count of alphabetic upper chars is: {alphabeticCharUpperCount}");
            Console.WriteLine($"Count of alphabetic lower chars is: {alphabeticCharLowerCount}");
            Console.WriteLine($"Count of digits is: {digitsCount}");
            Console.WriteLine($"Count of other special characters chars is: {specialCharactersCount}");
        }
        static string Sort(string a)
        {
            int length = a.Length;
            char[] array1 = a.ToCharArray();
            for (int i = 1; i < length; i++)
            {
                for(int j = 0; j < length - i; j++)
                {
                    if (array1[j] > array1[j + 1])
                    {
                        Swap(ref array1[j], ref array1[j+1]);
                    }
                }
            }
            String result = new string(array1); 
            return result;
        }
        static char[] Duplicate(string a)
        {
            int length = a.Length;
            char[] array1 = new char[length/2];
            int k = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length - i; j++)
                {
                    if (a[i]==a[j]) 
                    {
                        array1[k] = a[i];
                        k++;
                    }
                }
            }
            return array1;
        }
    }
}
