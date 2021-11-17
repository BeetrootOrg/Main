namespace ConsoleApp
{
    using System;
    class ConsoleApp
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n 03-other-kata\r\n");

            // 1.написати код, що буде виводити у консоль число з протилежним знаком, наприклад для 5 результат будет -5, для - 1 результат буде 1
            int aa = 5;
            Console.WriteLine("{0}", -aa);

            int bb = 1;
            Console.WriteLine("{0}", -(Math.Abs(bb)));
            // 2.написати код, що буде виводити у консоль число зі знаком мінус, наприклад для 5 результат будет -5, для - 1 результат буде -1

            // 3. написати код, що буде виводити у консоль чи є число квадратом якогось цілого числа,
            // наприклад 25 -> true (5^2), 24 -> false, 9 -> true (3^2), 1 -> true (1^2), 0 -> true (0^2), -1 -> false            
            Console.WriteLine("1. {0}", 25 == Math.Pow(5, 2));
            Console.WriteLine("2. {0}", 25 == Math.Pow(5, 2));
            Console.WriteLine("3. {0}", 9 == Math.Pow(3, 2));
            Console.WriteLine("4. {0}", 1 == Math.Pow(3, 2));
            Console.WriteLine("5. {0}", 0 == Math.Pow(0, 2));
            Console.WriteLine("6. {0}", 0 == Math.Pow(-1, 2));

            double aaa = -1;
            UInt32 bbb = 1;
            if(aaa > bbb)
            {
                Console.WriteLine("aaa{0} > bbb{1}", aaa, bbb);
            }
            else if(aaa < bbb)
            {
                Console.WriteLine("aaa{0} < bbb{1}", aaa, bbb);
            }
            else
            {
                Console.WriteLine("aaa{0} == bbb{1}", aaa, bbb);
            }
            
            
            
            
            Console.WriteLine("do whille");
            int iii = 0;
            do
            {
                Console.WriteLine("iii {0}", iii);
            } while (iii++ < 10);





            Console.Write("\r\n");
        }
    }
}