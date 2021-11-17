Console.WriteLine($"TUGUSHEV`S HOMEWORK C# INTRO");
Console.WriteLine($"Define several variables in your program (byte, short, int, long, bool, char, float, double, decimal, string)");

// string = UNICODE symbols

string homeWork = "1st task for homework";
Console.WriteLine(homeWork);

// bool = true or false

bool alive = true;
bool isDead = false;
Console.WriteLine(alive);
Console.WriteLine(isDead);

// byte = 0 - 255 

byte bit1 = 1;
byte bit2 = 254;
Console.WriteLine(bit1);
Console.WriteLine(bit2);

// sbyte = -128 - 127

sbyte sBit1 = -111;
sbyte sBit2 = 125;
Console.WriteLine(sBit1);
Console.WriteLine(sBit2);

// short = -32768 - 32767

short n1 = 1;
short n2 = 102;
Console.WriteLine(n1);
Console.WriteLine(n2);

// ushort = 0 - 65535

ushort uShort1 = 456;
ushort uShort2 = 22568;
Console.WriteLine(uShort1);
Console.WriteLine(uShort2);

// int -2147483648 - 2147483647

int i1 = 10;
int i2 = 860;
int i3 = 25;
Console.WriteLine($"{i1}, { i2}, { i3}");

//char Unicode '1 symbol'

char symbol = 'A';
char v = 'V';
Console.WriteLine($"{ symbol}, { v}");

// double

double weight = 60.54;
Console.WriteLine($"Weight: {weight}");

// decimal

decimal myPocketMoney = 1755.54M;
Console.WriteLine(myPocketMoney);

// float 

float h = 3.14F;
float o = 30.6f;
Console.WriteLine($"{h}, {o}");

// the result of addition, subtraction, multiplication

Console.WriteLine($"----------2nd task 'the result of addition, subtraction, multiplication'----------");
int s = 9;
int l = 18;
int q = s + l;
Console.WriteLine(q);
int w = s * l;
Console.WriteLine(w);
int r = s - l;
Console.WriteLine(r);
int d = l / s;
Console.WriteLine(d);

// result of several math functions

Console.WriteLine($"----------result of several math functions----------");
//-6*x^3+5*x^2-10*x+15
int x = 10;
// first method
Console.WriteLine($"1st method result if x = 10 -6*x^3+5*x^2-10*x+15 = {-6 * x * x * x + 5 * x * x - 10 * x + 15}");
// second method
Console.WriteLine($"2nd method result if x = 10 -6*x^3+5*x^2-10*x+15 = {-6 * Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 10 * x + 15}");
//abs(x) * sin(x)
Console.WriteLine($"abs(x) * sin(x) = {Math.Abs(x) * Math.Sin(x)}");
//2 * pi * x
double pi = Math.PI;
Console.WriteLine($"2 * pi * x = {2 * pi * x}");
//max(x, y)
Console.WriteLine(Math.Max(369, 6852));

// DATETIME TASK

Console.WriteLine($"-----------------DateTime Task-----------------");
var nowDate = DateTime.Now;
var prevNewYear = new DateTime(nowDate.Year, 1, 1);
var nextNewYear = new DateTime(nowDate.Year + 1, 1, 1);
var daysPassed = (nowDate - prevNewYear).Days;
var daysLeft = (nextNewYear - nowDate).Days;
Console.WriteLine($"{daysPassed} days passed from New Year");
Console.WriteLine($"{daysLeft} days left to New Year");


