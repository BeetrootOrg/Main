using System;
using System.Text;
namespace FirstProject
{
    class Program
    {
        static void Main()
        {
            string str1 = "gav1";
            string str2 = "Hello";

            //COMPARE
            Console.WriteLine("Compare work: ");
            Console.WriteLine(Compare(str1, str2)+"\n");

            //ANALYZE
            Console.WriteLine("Analyze work: ");
            Console.WriteLine(Analyze(str1)+"\n");

            //SORT
            Console.WriteLine("Sort work: ");
            string st = "Hello";
            Console.WriteLine(SortString(st) + "\n");

            //DUPLICATE
            Console.WriteLine("Duplicate work: ");
            foreach (char str in Duplicate("Abbccdee"))
            {
                Console.WriteLine(str);
            }


        }
        //1 task(compare)
        static bool Compare(string a, string b)
        {
            char[] str1 = a.ToCharArray();
            char[] str2 = b.ToCharArray();
            if (str1.Length != str2.Length)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        return false;
                    }

                }
                return true;
            }

        }
        //2 task (analyze)
        static string Analyze(string str)
        {
            int alphChars = 0;
            int digits = 0;
            int specSymb = 0;
            str.ToCharArray();
            foreach (var item in str)
            {
                if (Char.IsDigit(item))
                {
                    digits++;
                }
                if (Char.IsLetter(item))
                {
                    alphChars++;
                }
                else specSymb++;
            }

            string res = $"Alphabetic chars in string: {alphChars}\n Digits in string:{digits}\n Special symbols in string: {specSymb} ";

            return res;

        }
        static string SortString(string str)
        {

            char[] tempStr = str.Replace(" ", "").ToLower().ToCharArray();

            for (int i = 0; i < tempStr.Length; i++)
            {
                for (int j = 0; j < tempStr.Length - 1 - i; j++)
                {
                    if (tempStr[j] > tempStr[j + 1])
                    {
                        char temp = tempStr[j + 1];
                        tempStr[j + 1] = tempStr[j];
                        tempStr[j] = temp;
                    }
                }
            }
            return String.Join("", tempStr);
        }
        //решение duplicate подсмотрел у коллег 
        static char[] Duplicate(string str)
        {
            char[] tempStr = str.Replace(" ", "").ToLower().ToCharArray();

            StringBuilder strCopy = new StringBuilder(str.Replace(" ", "").ToLower());
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                int currentLenght = strCopy.Length;

                if (currentLenght - strCopy.Replace(str[i].ToString(), "").Length > 1)
                {
                    result.Append(str[i]);
                }
            }
            return result.ToString().ToCharArray();


        }


    }
}
