﻿int x = 3;
byte a = 34;
short b = 77;
int c = 6;
long d = 4567;
bool e = true;
char f = 'P';
float g = 45.65f;
double h = 7665d;
decimal i = 52.34m;
string j = "russia";
double y1;
double y2;
double y3;

y1 = -6 * Math.Pow(d, 3) + 5 * Math.Pow(d, 2) - 10 * d + 15;
y2 = Math.Abs(x) * Math.Sin(x);
y3 = 2 * Math.PI * g;
Console.WriteLine(y1);
Console.WriteLine(y2);
Console.WriteLine(y3);
Console.WriteLine(Math.Max(Convert.ToSingle(i), g));
Console.WriteLine(f + j);
Console.WriteLine(b + c);
//by the way the bitwise "not" exists 
Console.WriteLine(Convert.ToString(a, 2));
Console.WriteLine(Convert.ToString(~a, 2));
//New Year is soon!!!
DateTime date1 = DateTime.Now;