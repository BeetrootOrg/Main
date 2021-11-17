// input
int a = 25;

// 1.
Console.WriteLine(-a);

// 2.
Console.WriteLine(-1 * a * Math.Sign(a));

// 3.
double sqrt = Math.Sqrt(a);
Console.WriteLine(Math.Round(sqrt) == sqrt);