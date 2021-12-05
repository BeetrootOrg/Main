int x = Convert.ToInt32(Console.ReadLine());
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine((Enumerable.Range(Math.Min(x,y), Math.Max(x, y) - Math.Min(x, y) + 1)).Sum());
