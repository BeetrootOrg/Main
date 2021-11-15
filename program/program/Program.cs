//HOME WORK
Console.WriteLine("Homework:");

Random rnd = new Random();

//-6*x^3+5*x^2-10*x+15
int p = rnd.Next(0,100);
int f = rnd.Next(0, 100);
double result1 , result2, result3, result4;

result1 = -6 * Math.Pow(p, 3) + 5 * Math.Pow(p, 2) - 10 * p + 15;
Console.WriteLine($"При p={p}:");
Console.WriteLine($"\n-6*p^3+5*p^2-10*p+15={result1}");

//abs(x) * sin(x)
result2 = Math.Abs(p) * Math.Sin(p);
Console.WriteLine($"abs(p)*sin(p)={result2}");

//2 * pi * x
result3 = 2 * Math.PI * p;
Console.WriteLine($"2*pi*p={result3}");


//max(p, f)
result4 = Math.Max(p, f);
Console.WriteLine($"\nПри p={p},а f={f}:");
Console.WriteLine($"max(p,f)={result4}");




