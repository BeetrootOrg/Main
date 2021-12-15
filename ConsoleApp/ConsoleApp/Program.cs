using System;

namespace ConsoleApp
{
    #region Record

    record struct Complex(double Real, double Imaginary) : IEquatable<Complex>
    {
        public static Complex operator +(Complex complex1, Complex complex2) =>
            new(complex1.Real + complex2.Real, complex1.Imaginary + complex2.Imaginary);

        public static Complex operator *(Complex complex1, Complex complex2) =>
            new(complex1.Real * complex2.Real - complex1.Imaginary * complex2.Imaginary,
                complex1.Real * complex2.Imaginary + complex1.Imaginary * complex2.Real);

        public static explicit operator double(Complex complex) =>
            Math.Sqrt(Math.Pow(complex.Real, 2) + Math.Pow(complex.Imaginary, 2));

        public double this[int i]
        {
            get 
            { 
                return i switch 
                { 
                    0 => Real, 
                    1 => Imaginary, 
                    _ => throw new ArgumentOutOfRangeException(nameof(i)) 
                }; 
            }
        }
    }

    #endregion

    #region Readonly Struct

    readonly struct ReadonlyStruct
    {
        public int MyProperty { get; }

        // next line = compilation error
        // public int MyProperty1 { get; set; }
    }

    #endregion

    #region Sealed class

    public sealed class A
    {
        public void MethodA()
        {
            Console.WriteLine("A");
        }
    }

    // compilation error - cannot derive
    //public class B : A
    //{
    //}

    #endregion

    #region IComparable

    struct Number : IComparable<Number>, IFormattable
    {
        public double Num { get; set; }
        public int CompareTo(Number other)
        {
            if (Num - other.Num < 0) return -1;
            if (Num - other.Num > 0) return 1;
            return 0;
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == "F")
            {
                return $"{Num:F3}";
            }

            return Num.ToString();
        }
    }

    #endregion


    class Program
    {
        static void Main()
        {
            Complex complex1 = new(1, 2);
            Complex complex2 = new(1, 2);
            Complex complex3 = new(1.5, 3);

            Console.WriteLine(complex1.Equals(complex2));
            Console.WriteLine(complex2.Equals(complex3));

            Console.WriteLine(complex1);

            var sum = complex1 + complex3;
            Console.WriteLine(sum);

            Console.WriteLine($"{complex1}*{complex3}={complex1 * complex3}");
            Console.WriteLine(complex1 == complex2);

            double d = (double)complex1;
            Console.WriteLine(d);

            // complex[0] -> real
            // complex[1] -> imaginary
            Console.WriteLine(complex1[0]);
            Console.WriteLine(complex1[1]);

            Console.WriteLine(complex1);

            var num = new Number { Num = 5.1234 };
            Console.WriteLine($"{num:F}");
        }
    }
}