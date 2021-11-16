// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
try
{
    Console.WriteLine("Please, enter the value for X:");
    double xValue = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("Please, enter the value for Y:");
    double yValue = Convert.ToDouble(Console.ReadLine());

    Console.WriteLine("X: {0}, Y: {1}", xValue, yValue);
    double sum = xValue;

    while (xValue != yValue)
    {
        sum += xValue > yValue ? --xValue : ++xValue;
    }

    Console.WriteLine("The sum of values between X and Y is {0}", sum);
}
catch (Exception e)
{
    Console.WriteLine("You have entered the invalid input(s)");
}