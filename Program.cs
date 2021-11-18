int xValue, yValue;
bool success = false;

do
{
    Console.WriteLine("Please, enter the value for X:");
    string? xPreValue = Console.ReadLine();

    Console.WriteLine("Please, enter the value for Y:");
    string? yPreValue = Console.ReadLine();

    bool xSuc = int.TryParse(xPreValue, out xValue);
    bool ySuc = int.TryParse(yPreValue, out yValue);
    success = xSuc && ySuc;
} while (!success);

Console.WriteLine("X: {0}, Y: {1}", xValue, yValue);
double sum = xValue;

while (xValue != yValue)
{
    sum += xValue > yValue ? --xValue : ++xValue;
}

Console.WriteLine("The sum of values between X and Y is {0}", sum);