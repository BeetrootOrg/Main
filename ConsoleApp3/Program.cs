int x = 1;
int y = 3;
Console.WriteLine((Enumerable.Range(Math.Min(x,y), Math.Max(x, y) - Math.Min(x, y) + 1)).Sum());