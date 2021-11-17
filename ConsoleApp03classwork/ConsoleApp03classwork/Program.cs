Console.WriteLine("Insert value");
int value = int.Parse(Console.ReadLine());

//1
Console.WriteLine(-value);
//2
Console.WriteLine(-Math.Abs(value));
//3
double sqrt = Math.Sqrt(value);
Console.WriteLine(Math.Round(sqrt)==sqrt);

