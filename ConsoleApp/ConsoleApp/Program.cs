using System;

namespace ConsoleApp
{
    struct Complex : IEquatable<Complex>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public override bool Equals(object obj) => obj is Complex complex && Equals(complex);

        public bool Equals(Complex other) => Real == other.Real &&
                   Imaginary == other.Imaginary;

        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public override string ToString() => $"{Real}+{Imaginary}i";

        public static Complex operator +(Complex complex1, Complex complex2) =>
            new(complex1.Real + complex2.Real, complex1.Imaginary + complex2.Imaginary);

        public static Complex operator *(Complex complex1, Complex complex2) =>
            new(complex1.Real * complex2.Real - complex1.Imaginary * complex2.Imaginary,
                complex1.Real * complex2.Imaginary + complex1.Imaginary * complex2.Real);

        public static bool operator ==(Complex complex1, Complex complex2) => complex1.Equals(complex2);
        public static bool operator !=(Complex complex1, Complex complex2) => !complex1.Equals(complex2);

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
            set 
            { 
                switch(i)
                {
                    case 0:
                        Real = value;
                        break;
                    case 1:
                        Imaginary = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(i));
                }
            }
        }
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
                Real = 3
            };

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

            complex1[0] = 5;
            Console.WriteLine(complex1);
        }
    }
}