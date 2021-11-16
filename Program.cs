// See https://aka.ms/new-console-template for more information
/*Define several variables in your program (
    byte, short, int, long, bool, char, float, double, decimal, string) 
    and write to console the result of addition, subtraction, multiplication of several of them. */
byte tbyte =100;
short tshort=-25;
int tint=1235412;
double tempResult;
long tlong=135123512;
bool tbool=false;
char tChar='b';
decimal tdec=10.1M;
string tstring="some text";

tempResult=tbyte+tshort;
Console.WriteLine($"some addition {tempResult}");
tempResult=tbyte-tint;
Console.WriteLine($"some subtraction {tempResult}");
tempResult=tlong*tint;
Console.WriteLine($"some multuplication {tempResult}");

/* 
-6*x^3+5*x^2-10*x+15
abs(x)*sin(x)
2*pi*x
max(x, y)
*/

//Console.WriteLine("Type any digits for Y:");
//double tY=Convert.ToDouble(Console.ReadLine());
int tempX=2;
tempResult=-6*Math.Pow(tempX,3)+5*Math.Pow(tempX,2)-10*tempX+15;
Console.WriteLine($"Result of first equation {tempResult}");

tempResult=Math.Abs(tempX)*Math.Sin(tempX);
Console.WriteLine($"Result of second equation {tempResult}");

tempResult=2*Math.PI*tempX;
Console.WriteLine($"Result of third equation {tempResult}");

int tempY=3;
tempResult=Math.Max(tempX,tempY);
Console.WriteLine($"Result of forth equation {tempResult}");

Console.WriteLine($"{365-DateTime.Now.DayOfYear} days to the end of year");
Console.WriteLine($"{DateTime.Now.DayOfYear} days after NY");