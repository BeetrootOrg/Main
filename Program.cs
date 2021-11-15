
Console.WriteLine("\r\nLesson 2: types and variables\r\n");

// Define several variables in your program (byte, short, int, long, bool, char, float, double, decimal, string) 
// and write to console the result of addition, subtraction, multiplication of several of them.

byte t_byte = 1;
short t_short = 2;
int t_int = 3;
long t_long = 4;
bool t_bool = false;
char t_char = '6';
float t_float = 7.123F;
double t_double = 8.567;
decimal t_decimal = 9;
string t_string = "10";

Console.WriteLine("01. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_byte.GetType(), t_byte.GetTypeCode(), byte.MaxValue, byte.MinValue, t_byte);
Console.WriteLine("02. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_short.GetType(), t_short.GetTypeCode(), short.MaxValue, short.MinValue, t_short);
Console.WriteLine("03. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_int.GetType(), t_int.GetTypeCode(), int.MaxValue, int.MinValue, t_int);
Console.WriteLine("04. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_long.GetType(), t_long.GetTypeCode(), long.MaxValue, long.MinValue, t_long);
Console.WriteLine("05. Type {0}, TypeCode {1}, Current value {2}"                              , t_bool.GetType(), t_bool.GetTypeCode(), t_bool);
Console.WriteLine("06. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_char.GetType(), t_char.GetTypeCode(), (int)char.MaxValue, (int)char.MinValue, t_char);
Console.WriteLine("07. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_float.GetType(), t_float.GetTypeCode(), float.MaxValue, float.MinValue, t_float);
Console.WriteLine("08. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_double.GetType(), t_double.GetTypeCode(), double.MaxValue, double.MinValue, t_double);
Console.WriteLine("09. Type {0}, TypeCode {1}, Max value {2}, Min value {3}, Current value {4}", t_decimal.GetType(), t_decimal.GetTypeCode(), decimal.MaxValue, decimal.MinValue, t_decimal);
Console.WriteLine("10. Type {0}, TypeCode {1}, Current value {2}"                              , t_string.GetType(), t_string.GetTypeCode(), t_string);

int a = -1;
uint b = 2;
if(a > b)
{
    Console.WriteLine("11. a ({0}) > b {1})" , a, b);
}
else if (a < b)
{
    Console.WriteLine("11. a ({0}) < b ({1})" , a, b);
}
else
{
    Console.WriteLine("11. a ({0}) == b ({1})" , a, b);
}
// addition
Console.WriteLine("12. a ({0}) + b ({1}) = {2}" , a, b, (a + b));
// subtraction
Console.WriteLine("13. a ({0}) - b ({1}) = {2}" , a, b, (a - b));
// multiplication
Console.WriteLine("14. a ({0}) * b ({1}) = {2}" , a, b, (a * b));
// divide
Console.WriteLine("15. a ({0}) / b ({1}) = {2}" , a, b, ((float)a / (float)b));

// Write to console result of several math functions:
int x = 1;
int y = -6*x^3+5*x^2-10*x+15; // ((-6 * x)^(3 + (5 * x)))^((2 - (10 * x)) + 15);
Console.WriteLine("16. y = {0}", y);
Console.WriteLine("17. abs(x)*sin(x) = {0:F2}", Math.Abs(x)*Math.Sin(x));
Console.WriteLine("18. 2*pi*x = {0:F2}", 2*Math.PI*x);
Console.WriteLine("19. max(1, 3) = {0}", Math.Max(1, 3));

// Write to console how many days left to New Year and how many days passed from New Year.
DateTime date_New_2021 = new DateTime(2021, 1, 1);
DateTime date_New_2022 = new DateTime(2022, 1, 1);
TimeSpan passed_from_New_Year = DateTime.Now - date_New_2021;
TimeSpan left_to_New_2022_Year = date_New_2022 - DateTime.Now;
Console.WriteLine("20. Passed {0} days in this Year: ", Convert.ToUInt32(passed_from_New_Year.TotalDays));
Console.WriteLine("21. {0} days left to New 2022 Year:", Convert.ToUInt32(left_to_New_2022_Year.TotalDays));

Console.WriteLine("\r\n");
