using System;
namespace FirstProject
{
    class Program
    {
        static void Main()
        {
            //1 задание
            Console.WriteLine(MaxV(33,10,5,11,12));
            Console.WriteLine(MinV(33, 1, 5, 11, 12));


            //2 задание
            int a = 5;
            int b = 6;

            int summ;
            if(TryMulIfDividedByThree(a,b,out summ))
            {
                Console.WriteLine(summ);    
            }
            else
            {
                Console.WriteLine("Error");
            }
            //3 задание 
            Console.WriteLine(Repeat("str", 5));
        }
     





        //Находим максимальное значение 

        static int MaxV(int n1, int n2)
        {
            int res = 0;
            res = n2 > n1 ? n2 : n1;
            return res;
        }
        static int MaxV(int n1, int n2, int n3)
        {
            int res = 0;
            res = n3 > n2 ? n3 : n2;
            res = res > n1 ? res : n1;
            return res;
        }
        static int MaxV(int n1, int n2, int n3, int n4)
        {
            int res = 0;
            res = n4 > n3 ? n4 : n3;
            res = res > n2 ? res : n2;
            res = res > n1 ? res : n1;
            return res;
        }
        static int MaxV(int n1, int n2, int n3, int n4, int n5)
        {
            int res = 0;
            res = n5 > n4 ? n5 : n4;
            res = res > n3 ? res : n3;
            res = res > n2 ? res : n2;
            res = res > n1 ? res : n1;
            return res;

        }
        //находим минимальное значение
        static int MinV(int n1, int n2)
        {
            int res = 0;
            res = n2 < n1 ? n2 : n1;
            return res;
        }
        static int MinV(int n1, int n2, int n3)
        {
            int res = 0;
            res = n3 < n2 ? n3 : n2;
            res = res < n1 ? res : n1;
            return res;
        }
        static int MinV(int n1, int n2, int n3, int n4)
        {
            int res = 0;
            res = n4 < n3 ? n4 : n3;
            res = res < n2 ? res : n2;
            res = res < n1 ? res : n1;
            return res;
        }
        static int MinV(int n1, int n2, int n3, int n4, int n5)
        {
            int res = 0;
            res = n5 < n4 ? n5 : n4;
            res = res < n3 ? res : n3;
            res = res < n2 ? res : n2;
            res = res < n1 ? res : n1;
            return res;

        }
        // Вывести произведение чисел если кратно 3
        static bool TryMulIfDividedByThree(int a,int b,out int summ)
        {
            if (a % 3 == 0 || b % 3 == 0)
            {
                summ = a + b * 2;
                return true;
            }
            summ = 0;
            return false;
        }

        // Повтор строки введеного кол-во раз
        static string Repeat(string str, int num)
        {
            string res = "str";
            for (int i = 0; i <= num; i++)
            {
                res += str;
            }
            return res;
        }



    }
}