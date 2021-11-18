int x, y;
bool successX = true,
    successY = true;
string? xInput, yInput;

do
{
    Console.WriteLine(successX ? "Please define X variable" : "X should be a number, so please define X variable again");
    xInput = Console.ReadLine();
    successX = int.TryParse(xInput, out x);
}
while (!successX);

do
{
    Console.WriteLine(successY ? "Please define Y variable" : "Y should be a number, so please define Y variable again");
    yInput = Console.ReadLine();
    successY = int.TryParse(yInput, out y);
}
while (!successY);

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
