using System.IO;
using System;

while (true)
{
try
{
        bool XP;
        int X;
        int Y;
        do
        {
            Console.WriteLine("Input integer X");

            XP = int.TryParse(Console.ReadLine(), out X);
        } while (!XP);
        do
        {
            Console.WriteLine("Input integer Y");            
            XP = int.TryParse(Console.ReadLine(), out Y);
        } while (!XP);

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
    if (key.KeyChar == 'y'|| key.KeyChar == 'Y') break; 
}