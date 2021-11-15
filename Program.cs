// See https://aka.ms/new-console-template for more information
/*Define several variables in your program (
    byte, short, int, long, bool, char, float, double, decimal, string) 
    and write to console the result of addition, subtraction, multiplication of several of them. */
byte tbyte =100;
short tshort=-25;
int tint=1235412;
double tresult;
long tlong=135123512;
bool tbool=false;
char tChar='b';
decimal tdec=10.1M;
string tstring="some text";

tresult=tbyte+tshort;
Console.WriteLine($"some addition {tresult}");
tresult=tbyte-tint;
Console.WriteLine($"some subtraction {tresult}");
tresult=tlong*tint;
Console.WriteLine($"some multuplication {tresult}");

/* 
-6*x^3+5*x^2-10*x+15
abs(x)*sin(x)
2*pi*x
max(x, y)
*/
Console.WriteLine("Type any digits for X:");
double tX=Convert.ToDouble(Console.ReadLine());
//Console.WriteLine("Type any digits for Y:");
//double tY=Convert.ToDouble(Console.ReadLine());

tresult=-6*Math.Pow(tX,3)+5*Math.Pow(tX,2)-10*tX+15;
Console.WriteLine($"Result of first equation {tresult}");