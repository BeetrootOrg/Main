int x, y;

Console.WriteLine("Please define X variable");
string? xInput = Console.ReadLine();
bool successX = int.TryParse(xInput, out x);

while (!successX)
{
    Console.WriteLine("X should be a number, so please define X variable again");
    xInput = Console.ReadLine();
    successX = int.TryParse(xInput, out x);
}

Console.WriteLine("Please define Y variable");
string? yInput = Console.ReadLine();
bool successY = int.TryParse(yInput, out y);

while (!successY)
{
    Console.WriteLine("Y should be a number, so please define Y variable again");
    yInput = Console.ReadLine();
    successY = int.TryParse(yInput, out y);
}
int sum = 0;

if (x == y)
{
    sum = x;
}
else
{
    int minVal = Math.Min(x, y);
    int maxVal = Math.Max(x, y);

    for (int i = minVal; i <= maxVal; i++)
    {
        sum += i;
    }
}
Console.WriteLine($"The sum of the integers between these two numbers is {sum}");
