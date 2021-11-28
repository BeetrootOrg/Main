try
{
    Console.WriteLine("Insert first integer:");
    int x = int.Parse(Console.ReadLine());
    Console.WriteLine("Insert second integer:");
    int y = int.Parse(Console.ReadLine());
    int sum = 0;

    int max = Math.Max(x, y);
    int min = Math.Min(x, y);

    for (int i = min; i <= max; i++)
    {
        sum += i;
    }
    Console.WriteLine($"Sum: {sum}");
}
catch (FormatException)
{
    Console.WriteLine("Incorrect input...");
}