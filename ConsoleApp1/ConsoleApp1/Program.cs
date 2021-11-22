using System;

namespace Homework
{
    public class Homework
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxV(1,2));
                Console.WriteLine(MaxV(2,3,5,6,7));
        }

        //створити метод Max приймає від 2 до 5 аргументів та повертає max відповідно значення серед цих аргументів
        public static int MaxV(int v1, int v2, int v3 = -2147483648, int v4 = -2147483648, int v5 = -2147483648)
        {
            int result = 0;
            result = v5 > v4 ? v5 : v4;
            result = result > v3 ? result : v3;
            result = result > v2 ? result : v2;
            result = result > v1 ? result : v1;
            return result;
        }

        //створити метод Min приймає від 2 до 5 аргументів та повертає min відповідно значення серед цих аргументів
        public static int MinV(int v1, int v2, int v3 = 2147483647, int v4 = 2147483647, int v5 = 2147483647)
        {
            int result = 0;
            result = v5 < v4 ? v5 : v4;
            result = result < v3 ? result : v3;
            result = result < v2 ? result : v2;
            result = result < v1 ? result : v1;
            return result;
        }

        //створити метод TryMulIfDividedByThree що повертає булеве значення true/false якщо хоче б одне з чисел ділиться на 3. за допомогою out параметру повернути результат добутку(або нуль якщо обидва числа не діляться на 3)

        public static bool TryMulIfDividedByThree(double var1, double var2,out double result)
        {
            if(var1%3==0 || var2 % 3 == 0)
            {
                result = var1 * var2;
                return true;
            }
            else
            {
                result = 0;
                return false;
            }
        }

        //створити метод Repeat що приймає строку str та число n і повертає строку str, що повторюється n разів(e.g.Repeat(‘str’, 3) returns ‘strstrstr’ = ‘str’ three times)
        public static string Repeat(string str, int count)
        {
            string concat = str;
            for(int i = 1; i < count; i++)
            {
                concat = concat + str;
            }
            return concat;
        }
        //створити функцію Pow(x, y) що буде підносити X в степінь Y(x та y цілі невід'ємні числа)
        public static int Pow(int value, int power)
        {
            int result = 0;
            if (power > 0 && power != 1)
            {
                result = value * Pow(value, power - 1);
            }
            else
            {
                result = value;
            }
            return result;
            
        }

    }

}