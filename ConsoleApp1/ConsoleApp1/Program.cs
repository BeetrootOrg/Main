using System;

namespace Homework
{
    public class Homework
    {
        static void Main(string[] args)
        {
            
        }

        //створити метод Max приймає від 2 до 5 аргументів та повертає max відповідно значення серед цих аргументів
        public static int MaxV(int? v1, int? v2, int? v3 = null, int? v4 = null, int? v5 = null)
        {
            int result = 0;
            if (v3 != null)
            {
                if (v4 != null)
                {
                    if (v5 != null)
                    {
                        result = v5.Value > v4.Value ? v5.Value : v4.Value;
                    }
                    else result = v4.Value;
                    result = result > v3.Value ? result : v3.Value;
                }
                else result = v3.Value;
                result = result > v2.Value ? result : v2.Value;
            }
            else result = v2.Value;
            result = result > v1.Value ? result : v1.Value;
            return result;
        }

        //створити метод Min приймає від 2 до 5 аргументів та повертає min відповідно значення серед цих аргументів
        public static int MinV(int? v1, int? v2, int? v3 = null, int? v4 = null, int? v5 = null)
        {
            int result = 0;
            if (v3 != null)
            {
                if (v4 != null)
                {
                    if (v5 != null)
                    {
                        result = v5.Value < v4.Value ? v5.Value : v4.Value;
                    }
                    else result = v4.Value;
                    result = result < v3.Value ? result : v3.Value;
                }
                else result = v3.Value;
                result = result < v2.Value ? result : v2.Value;
            }
            else result = v2.Value;
            result = result < v1.Value ? result : v1.Value;
            return result;
        }

        //створити метод TryMulIfDividedByThree що повертає булеве значення true/false якщо хоче б одне з чисел ділиться на 3. за допомогою out параметру повернути результат добутку(або нуль якщо обидва числа не діляться на 3)

        public static bool TryMulIfDividedByThree(double var1, double var2,out double result)
        {
            if(var1%3==0 || var2 % 3 == 0)
            {
                result = var1 / var2;
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