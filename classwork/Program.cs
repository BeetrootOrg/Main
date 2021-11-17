Console.WriteLine("Enter value:");
int value = (int)Convert.ToDouble(Console.ReadLine());

Console.WriteLine("First task - opposite value of enter number is {0}", -value);
Console.WriteLine("Second task - always negative value of number is {0}", -Math.Abs(value));

int sqrtOfValue = (int)Math.Sqrt(value);
Console.WriteLine("Third task - if SQRT - {0}", sqrtOfValue * sqrtOfValue == value);