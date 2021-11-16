bool passed = true;

byte testByte = 100;
short testShort = 101;
int testInt = -1;
long testLong = 200;

float testFloat = 3.14F;
double testDouble = 545.1;
decimal testDecimal = 999.9999M;

char s = 'S';
string testString = "This is test string";

Console.WriteLine(s + testString);
Console.WriteLine(testLong - testInt);
Console.WriteLine(testFloat * testDouble);
Console.WriteLine(testShort / testByte);

Console.WriteLine("Type value for X:");
double testX = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Type value for Y:");
double testY = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("The entered values were X:{0}, Y:{1}", testX, testY);
double firstEquation = -6 * Math.Pow(testX, 3) + 5 * Math.Pow(testX, 2) - 10 * testX + 15;
Console.WriteLine("The result for -6*x^3+5*x^2-10*x+15 will be {0}", firstEquation);
double secondEquation = Math.Abs(testX) * Math.Sin(testX);
Console.WriteLine("The result for abs(x)*sin(x) will be {0}", secondEquation);
double thirdEquation = 2 * Math.PI * testX;
Console.WriteLine("The result for 2*pi*x will be {0}", thirdEquation);
double fourthEquation = Math.Max(testX, testY);
Console.WriteLine("The result for max(x, y) will be {0}", fourthEquation);

int test1 = 50;
int test2 = 55;
(test1, test2) = (test2, test1);
Console.WriteLine("New values for test1 is {0} and for test2 is {1}", test1, test2);

int currentDayInYear = DateTime.Now.DayOfYear;
int daysToNewYear = DateTime.IsLeapYear(DateTime.Now.Year) ? 366 - currentDayInYear : 365 - currentDayInYear;

Console.WriteLine("{0} days left to New Year", daysToNewYear);
Console.WriteLine("{0} days passed from the New Year", currentDayInYear);