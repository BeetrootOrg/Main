using System;
using System.Text;

namespace ConsoleAppBeetrootOther
{
    class ConsoleAppBeetrootOther
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compare("AD","BC"));
            Console.WriteLine(Compare("AD","DD"));
            Console.WriteLine(Compare("aa", "AA"));


        }
        static int Compare(string str1, string str2)
        {
            var bytes1 = Encoding.Unicode.GetBytes(str1);
            var sum1 = Sum(bytes1);
            var bytes2 = Encoding.Unicode.GetBytes(str2);
            var sum2 = Sum(bytes2);
            if (sum1 == sum2)
            {
                return 0;
            }
            return sum1 > sum2 ? 1 : -1;
        }
        static int Sum(byte[] bytes)
        {
            var sum = 0;
            for (int i = 0; i < bytes.Length; i++)
            {
                sum += bytes[i];
            }
            return sum;
        }
        //написати метод int Compare(string str1, string str2), що буде порівнювати строки використовуючи суму UTF-16 кодів кожного символу.
        //результат:
        //будь-яке число менше 0, якщо str1<str2 за тим алгоритмом
        //0, якщо str1 == str2
        //будь-яке число більше за 0, якщо str1 > str2
        //наприклад:
        //Compare('AD', 'BC') повертає 0, бо код(A)=65, код(В)=66, код(С)=67, код(D)=68, код(AD)=65+68=133, код(BC)=66+67=133, код(AD)=код(BC) тому результат 0
        //Compare('AD', 'DD') повертає 1, бо код('AD')=65+68=133, код('DD')=68+68=136, код(AD)<код(DD), тому -1
    }
}
