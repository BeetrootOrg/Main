try
{
    Console.WriteLine("Write number X: ");
    int numX = int.Parse(Console.ReadLine());
    Console.WriteLine("Write number Y: ");
    int numY = int.Parse(Console.ReadLine());
    int sum = 0;
    int max = Math.Max(numX, numY);
    int min = Math.Min(numX, numY);

    if (numX == numY)
    {
        sum = numX;
    }
    else
    {
        for (int i = min; i <= max; i++)
        {
            sum += i;
        }
    }
    Console.WriteLine($"The sum of numbers from {max} to {min} is: {sum}");
}
catch (FormatException)
{
    Console.WriteLine("Please, write a number");
}