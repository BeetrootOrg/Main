using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{
    struct Complex : IEquatable<Complex>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }
        public override bool Equals(object obj) => obj is Complex complex && Equals((Complex)obj);

        public bool Equals(Complex other) => Real == other.Real && Imaginary == other.Imaginary;
        
        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public override string ToString() => Real.ToString();

        public static Complex operator+(Complex complex1, Complex complex2)
        {

        }
    }

    public class Program
    {
        static void Main()
        {
            Complex complex1 = new Complex()
            {
                Imaginary = 1,
                Real = 2
            };

            Complex complex2 = new Complex()
            {
                Imaginary = 1,
                Real = 2
            };
            Complex Complex3 = new Complex()
            {
                Imaginary = 1.5,
                Real = 2
            };
        }
    }
}