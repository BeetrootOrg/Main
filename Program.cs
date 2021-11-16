byte byteVar = 12;
short shortVar = 10;
int intVar = 48;
long longVar = 1254;

int currentYearDayNumber = DateTime.Now.DayOfYear;

float floatVar = 125.4F;
double doubleVar = 465.4;
decimal decimalVar = 13454854.5548M;

char charVar = 'H';
string stringVar = "ere are the Calculation Results:";

bool boolVar = true;

string firstExample = "-6*x^3+5*x^2-10*x+15";
string secondExample = "abs(x)*sin(x)";
string thirdExample = "2*pi*x";
string fourthExample = "max(x, y)";


Console.WriteLine($"{charVar + stringVar}");
Console.WriteLine($"{byteVar} + {shortVar} = {byteVar + shortVar}");
Console.WriteLine($"{intVar} - {longVar} = {intVar - longVar}");
Console.WriteLine($"{floatVar} * {doubleVar} = {(decimal)floatVar * (decimal)doubleVar}");
Console.WriteLine($"√{decimalVar} = {Math.Sqrt((double)decimalVar)}");
if (boolVar)
{
    Console.WriteLine($"If x = 5 => {firstExample} = {-6 * Math.Pow(5, 3) + 5 * Math.Pow(5, 2) - 10 * 5 + 15}");
    Console.WriteLine($"If x = 45 => {secondExample} = {Math.Abs(45) * Math.Sin(45)}");
    Console.WriteLine($"If x = 12 => {thirdExample} = {2 * Math.PI * 12}");
    Console.WriteLine($"If x = 18 and y = 55 => {fourthExample} = {Math.Max(18, 55)}");

    Console.WriteLine($"{365 - currentYearDayNumber} days left to New Year (without current day)");
    Console.WriteLine($"{currentYearDayNumber} days passed from New Year");
}

//Replace var values
int a = 5;
int b = 8;
a += b;
b = a - b;
a -= b;
Console.WriteLine($"New a = {a} and new b = {b}");