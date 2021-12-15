using System;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp
{

    //i.safontev/classwork/14-structs
    struct Complex: IEquatable<Complex>
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public Complex(Complex another)
        {
            Real = another.Real;
            Imaginary = another.Imaginary;
        }

        public override bool Equals(object obj) => obj is Complex complex && Equals(complex);
        public bool Equals(Complex other) => Real == other.Real &&
                   Imaginary == other.Imaginary;
        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public override string ToString() => $"{Real}+ {Imaginary}i";

        public static Complex operator +(Complex complex1, Complex complex2) =>
            new Complex(complex1.Real + complex2.Real, complex1.Imaginary + complex2.Imaginary);
        public static Complex operator *(Complex complex1, Complex complex2) =>
            new Complex(complex1.Real + complex2.Real - complex1.Imaginary * complex2.Imaginary,
                        complex1.Real + complex2.Imaginary + complex1.Imaginary * complex2.Real);

        public static bool operator ==(Complex complex1, Complex complex2) => complex1.Equals(complex2);
        //complex1.Real == complex2.Real && complex1.Imaginary == complex2.Imaginary;
        public static bool operator !=(Complex complex1, Complex complex2) => !complex1.Equals(complex2);

        public static explicit operator double(Complex complex) =>//implicit- не явное приведение типа, explicit- явное (d=double(complex))
            Math.Sqrt(Math.Pow(complex.Real, 2) + Math.Pow(complex.Imaginary, 2));

        //complex[0]-> Real
        //complex[1]-> Imaginary
        //Realisatiion
        //Indexation
        public double this[int i]
        {
            get 
            {
                return  i switch 
                { 
                    0 => Real, 
                    1 => Imaginary, 
                    _ => throw new ArgumentOutOfRangeException(nameof(i)),
                };
            }
            /*
            set 
            {
                switch (i)
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
            */
        }

    }

    class Program
    {
        static void Main()
        {
            Complex complex1 = new Complex
            {
                Real = 2,
                Imaginary = 1,
            };
            Complex complex2 = new Complex
            {
                Real = 2,
                Imaginary = 1,
            };
            Complex complex3 = new Complex
            {
                Real = 2,
                Imaginary = 1.5,
            };

            Console.WriteLine(complex1.Equals(complex2));
            Console.WriteLine(complex3);

            Console.WriteLine($"{complex1}+ {complex2}= {complex1 + complex2} ");

            Console.WriteLine($"{complex1}* {complex2}= {complex1 * complex2} ");

            Console.WriteLine(complex1 == complex2);

            double d = (double)complex3;
            Console.WriteLine(d);

            Console.WriteLine(complex1[0]);
            Console.WriteLine(complex2[1]);


        }

    }
}