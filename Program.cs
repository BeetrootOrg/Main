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

            byte byte_variable;// 0 to 255
            short short_variable;// short int
            int int_variable;// -2,147,483,648 to 2,147,483,647
            long long_variable;// long int

            bool bool_variable;// true or false

            float float_variable;// floating-point numeric types
            double double_variable;// more accurate that float
            decimal decimal_variable;// more accurate that double

            char char_variable;// using to store one unicode character
            string string_variable;// using to store more than one unicode character

            Console.WriteLine("Enter the byte number: ");
            byte_variable=Convert.ToByte(Console.ReadLine());
            short_variable=1;
            short_variable++;
            int_variable=2+1;
            long_variable=1000;
            float_variable=0.5F;
            double_variable=1.2;
            decimal_variable=3.6m;
            char_variable='=';
            string_variable="Simple examples: ";
            bool_variable=true;

            if(bool_variable)
            {
                Console.WriteLine(string_variable);
                Console.WriteLine($"{byte_variable}*{short_variable} {char_variable} {byte_variable*short_variable}");
                Console.WriteLine($"{int_variable}+{long_variable} = {int_variable+long_variable} ");
                Console.WriteLine($"{float_variable}+{double_variable} = {float_variable+double_variable}\n");
                char_variable=string_variable[0];
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
            Console.WriteLine($"{356-DateTime.Now.DayOfYear} days left to New Year");
            Console.WriteLine($"{DateTime.Now.DayOfYear} days passed from New Year");
        }
    }
}
