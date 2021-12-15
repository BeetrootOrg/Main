using System;

namespace ConsoleApp
{
    struct Complex : IEquatable<Complex>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public override bool Equals(object obj) => obj is Complex complex && Equals(complex);

        public bool Equals(Complex other) => Real == other.Real &&
                   Imaginary == other.Imaginary;

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);
    }

    class Program
    {
        static void Main()
        {
            Complex complex1 = new()
            {
                Imaginary = 1,
                Real = 2
            };

            Complex complex2 = new()
            {
                Imaginary = 1,
                Real = 2
            };

            Complex complex3 = new()
            {
                Imaginary = 1.5,
                Real = 2
            };

            Console.WriteLine(complex1.Equals(complex2));
            Console.WriteLine(complex2.Equals(complex3));
        }
    }
}