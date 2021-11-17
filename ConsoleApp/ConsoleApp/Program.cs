try
{
    Console.WriteLine("Please define X variable");
    int x = Int32.Parse(Console.ReadLine());
    Console.WriteLine("Please define Y variable");
    int y = Int32.Parse(Console.ReadLine());
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
}
catch (FormatException)
{
    Console.WriteLine($"Invalid input");
}