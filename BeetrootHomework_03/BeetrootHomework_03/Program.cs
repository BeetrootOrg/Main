// See https://aka.ms/new-console-template for more information

bool successX, successY = false;
int x, y;

do
{
    Console.WriteLine("Write integer X:");
    successX = int.TryParse(Console.ReadLine(), out x);
    Console.WriteLine("Write integer Y:");
    successY = int.TryParse(Console.ReadLine(), out y);

    if((successX || successY) == false)
    {
        Console.WriteLine("Please, write INTEGER NUMBER!");
    }

} while (!(successX && successY));

if (x != y)
{
    int sum = 0;
    for (int i = Math.Min(x, y); i <= Math.Max(x, y); i++)
    {
        sum += i;
    }
    Console.WriteLine(sum);
}
else Console.WriteLine(x);