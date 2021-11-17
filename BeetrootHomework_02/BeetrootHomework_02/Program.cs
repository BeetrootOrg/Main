// See https://aka.ms/new-console-template for more information

//This some examples with Double type
double xDouble = 7.56;
double yDouble = 8;
Console.WriteLine("This is DOUBLE numbers:");
Console.WriteLine(-6 * Math.Pow(xDouble, 3) + 5 * Math.Pow(xDouble, 2) - 10 * xDouble + 15);
Console.WriteLine(Math.Abs(xDouble) * Math.Sin(xDouble));
Console.WriteLine(2 * Math.PI * xDouble);
Console.WriteLine(Math.Max(xDouble, yDouble) + "\n\n");



//This some examples with Float type
float xFloat = 7.56f;
float yFloat = 8;
Console.WriteLine("This is FLOAT numbers:");
Console.WriteLine(-6 * Math.Pow(xFloat, 3) + 5 * Math.Pow(xFloat, 2) - 10 * xFloat + 15);
Console.WriteLine(Math.Abs(xFloat) * Math.Sin(xFloat));
Console.WriteLine(2 * Math.PI * xFloat);
Console.WriteLine(Math.Max(xFloat, yFloat) + "\n\n");


//This some examples with Int type
int xInt = 7;
int yInt = 8;
Console.WriteLine("This is INT numbers:");
Console.WriteLine(-6 * Math.Pow(xInt, 3) + 5 * Math.Pow(xInt, 2) - 10 * xInt + 15);
Console.WriteLine(Math.Abs(xInt) * Math.Sin(xInt));
Console.WriteLine(2 * Math.PI * xInt);
Console.WriteLine(Math.Max(xInt, yInt) + "\n\n");


//This some examples with Decimal type
int xDecimal = 7;
int yDecimal = 8;
Console.WriteLine("This is DECIMAL numbers:");
Console.WriteLine(-6 * Math.Pow(xDecimal, 3) + 5 * Math.Pow(xDecimal, 2) - 10 * xDecimal + 15);
Console.WriteLine(Math.Abs(xDecimal) * Math.Sin(xDecimal));
Console.WriteLine(2 * Math.PI * xDecimal);
Console.WriteLine(Math.Max(xDecimal, yDecimal) + "\n\n");


//Some work with Decimal
//In Interstellar main character was on planet where time was very slowed down, and 1 hour on those planet equal 7 years on Earth.
//Also if you move at a speed close to the speed of light, your time will be slower too. Let's count on what speed our time will be slow like on planet from Interstellar.

const int C = 299792458; //light speed m/s
decimal t0 = 3600;       // 1 hour in second
decimal t = 220924800;   // 7 years in second

decimal v = C*Sqrt(1.0m - Decimal.Divide(t0, t) * Decimal.Divide(t0, t));
Console.WriteLine(Sqrt(1.0m - Decimal.Divide(t0, t) * Decimal.Divide(t0, t)));
Console.WriteLine($"Our speed need to be: {Decimal.Round(v, 9)} m/s \n\n");

static decimal Sqrt(decimal x)
{
    decimal a = 0.9m;

    for (int i = 0; i <= 10; i++)
    {
        a = 0.5m * (a + x / a);
    }
    return a;
}

//How many days are left until the new year???
DateTime newYear = new DateTime(2022, 01, 01);
TimeSpan diff = newYear - DateTime.Now;
Console.WriteLine($"До Нового Года осталось: {diff.Days} дней");


//Switch two numbers without third
int a = 3;
int b = 8;
int c = 10;

Console.WriteLine($"{a}, {b}");
(a, b, c) = (b, c, a);
Console.WriteLine($"{a}, {b}");