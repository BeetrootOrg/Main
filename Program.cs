using System;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Define several variables in your program (byte, short, int, long, bool, char, float, double, decimal, string)
             and write to console the result of addition, subtraction, multiplication of several of them.
            Write to console result of several math functions:

            -6*x^3+5*x^2-10*x+15
            abs(x)*sin(x)
            2*pi*x
            max(x, y)
            */

            byte byteVariable;// 0 to 255
            short shortVariable;// short int
            int intVariable;// -2,147,483,648 to 2,147,483,647
            long longVariable;// long int

            bool boolVariable;// true or false

            float floatVariable;// floating-point numeric types
            double doubleVariable;// more accurate that float
            decimal decimalVariable;// more accurate that double

            char charVariable;// using to store one unicode character
            string stringVariable;// using to store more than one unicode character

            Console.WriteLine("Enter the byte number: ");
            byteVariable=Convert.ToByte(Console.ReadLine());
            shortVariable=1;
            shortVariable++;
            intVariable=2+1;
            longVariable=1000;
            floatVariable=0.5F;
            doubleVariable=1.2;
            decimalVariable=3.6m;
            charVariable='=';
            stringVariable="Simple examples: ";
            boolVariable=true;

            if(boolVariable)
            {
                Console.WriteLine(stringVariable);
                Console.WriteLine($"{byteVariable}*{shortVariable} {charVariable} {byteVariable*shortVariable}");
                Console.WriteLine($"{intVariable}+{longVariable} = {intVariable+longVariable} ");
                Console.WriteLine($"{floatVariable}+{doubleVariable} = {floatVariable+doubleVariable}\n");
                charVariable=stringVariable[0];
            }

            Console.WriteLine("Enter the x: ");
            double x=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the y: ");
            double y=Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"-6*{x}^3+5*{x}^2-10*{x}+15 = {-6*Math.Pow(x,3)+5*Math.Pow(x,2)-10*x+15}");
            Console.WriteLine($"abs({x})*sin({x}) = {Math.Abs(x)*Math.Sin(x)}");
            Console.WriteLine($"2*pi*{x} = {2*Math.PI*x}");
            Console.WriteLine($"max({x}, {y}) = {Math.Max(x,y)}\n");

            /*
            Write to console how many days left to New Year and how many days passed from New Year. 
            Result in console should look like this:

            X days left to New Year
            Y days passed from New Year
            */
            Console.WriteLine($"{365-DateTime.Now.DayOfYear} days left to New Year");
            Console.WriteLine($"{DateTime.Now.DayOfYear} days passed from New Year");
        }
    }
}
