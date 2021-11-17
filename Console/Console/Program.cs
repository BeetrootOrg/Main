using System.IO;
using System;

while (true)
{
try
{
    Console.WriteLine("Input natural X");
    var X = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Input natural Y");
    var Y = Convert.ToInt32(Console.ReadLine());
    if (X != Y)
    {
        int max = Math.Max(X, Y);
        int min = Math.Min(X, Y);
        int sum = 0;
        for (int cnt = min; cnt <= max; cnt++)
        {
            sum += cnt;
        }
        Console.WriteLine($"Summ = {sum}");
    }
    else
    {
        Console.WriteLine($"Summ = {X}");
    }
}
catch
{
    Console.WriteLine("X or Y have wrong input");
}
    Console.WriteLine("Whant to exit? Y\\N");
    var key = Console.ReadKey();
    if (key.KeyChar == 'y') break; 
}