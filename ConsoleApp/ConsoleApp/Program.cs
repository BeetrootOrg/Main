// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

string infonote = "input value x for calculation";
Console.WriteLine(infonote);

string outnum = Console.ReadLine();
var b = Convert.ToInt32(outnum);

Console.WriteLine($"-6*x^3+5*x^2-10*x+15: {-6 * b * b * b + 5 * b * b - 10 * b + 15}");





//double var1 = double.Parse(outval, CultureInfo.InvariantCulture);

double var1 = 22.33;

double first = Math.Abs(var1);

double second = Math.Sin(var1);
Console.WriteLine($"abs(x) * sin(x): {first * second}");

Console.WriteLine(); //space

// 2*pi*x

int x11 = 99;

const double pi = Math.PI;
Console.WriteLine($"2*pi*x: {2 * pi * x11}");

Console.WriteLine(); //space

// max(x, y)
Console.WriteLine("input value for x");
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
string rowstr = Console.ReadLine();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
int x = Int32.Parse(rowstr);


Console.WriteLine("input value for y");

#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
string rowstr2 = Console.ReadLine();
#pragma warning restore CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.

int y = Int32.Parse(rowstr2);

//int maxfunc = Math.Max(x, y);

Console.WriteLine($"max(x, y) {Math.Max(x, y)}");


// 
Console.WriteLine(); //space
double m = 3123.32;
double n = 1000.01;
Console.WriteLine(n + " before");

// changing variable values
m = m + n;
n = n - m;
n = -n;
m = m - n;
Console.WriteLine(n + " after");
