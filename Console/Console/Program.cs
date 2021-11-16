
//Optional - define maual imput of parameters
Console.WriteLine("Input x as double");
var value1 = Console.ReadLine();
Console.WriteLine("Input y as double");
var value2 = Console.ReadLine();

//First part: define few diferent types of values and do simple operations
int v1 = 10;
float v2 = 2.34f;
double v3 = 0.346236746;
decimal v4 = 5.2143m;
Console.WriteLine($"Sum int/float {v1 + v2}");
Console.WriteLine($"Divide decimal/int {v4 / v1}");
Console.WriteLine($"Multiple float/double {v2 * v3}");

//Try to convert string input to a double, to prevert a app fail
try
{
    //Convert parameters and define formulas
    double x = Convert.ToDouble(value1);
    double y = Convert.ToDouble(value2);
    double formula1 = -6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15;
    double formula2 = Math.Abs(x) * Math.Sin(x);
    double formula3 = 2 * Math.PI * x;
    double formula4 = Math.Max(x, y);
    Console.WriteLine($"Formula - 1(-6*x^3+5*x^2-10*x+15): {formula1} ");
    Console.WriteLine($"Formula - 2(abs(x)*sin(x)): {formula2} ");
    Console.WriteLine($"Formula - 3(2*pi*x): {formula3} ");
    Console.WriteLine($"Formula - 4(max(x, y)): {formula4} ");
}
catch //Exception catch
{
    Console.WriteLine($" X or Y have a not a double value ");
}

//Additional block - operations with date
var dateNow = DateTime.Now;
TimeSpan daysToNewYear = (Convert.ToDateTime(DateTime.Now.Year.ToString() + "-12-31") - dateNow.Date);
TimeSpan daysFromNewYear = dateNow.Date - Convert.ToDateTime(DateTime.Now.Year.ToString() + "-01-01");
Console.WriteLine($"Days to New Year : {daysToNewYear.Days}");
Console.WriteLine($"Days from New Year : {daysFromNewYear.Days}");