byte aLonLongName = 5;
Console.WriteLine(aLonLongName);

byte a = 3;
byte b = 4;
int c = a + b;
Console.WriteLine(c);

int mul = a / b;
Console.WriteLine(mul);

int i = 42;
int j = 90;
Console.WriteLine(j/i);
Console.WriteLine(j%i);

//x^3+2*x^2+5*x+6
double x = 3.6;
Console.WriteLine(x * x * x + 2 * (x * x) + 5 * x + 6);

decimal y = 3.6m;
Console.WriteLine(y * y * y + 2 * (y * y) + 5 * y + 6);

//same with Math
double z = 4;
Console.WriteLine(Math.Pow(z, 3) + 2 * Math.Pow(z, 2) + 5 * z + 6);


//increment/decrement

int incr = 5;
int result1 = incr++;
int result2 = ++incr;
Console.WriteLine($"{result1} {result2} {incr}");

// bool logic
var bool1 = true;
var bool2 = false;
Console.WriteLine($"AND: {bool1&&bool2}");
Console.WriteLine($"OR: {bool1 || bool2}");
Console.WriteLine($"Equal: {bool1 == bool2}");
Console.WriteLine($"Not bool1: {!bool1}");
Console.WriteLine($"Not bool12: {!bool2}");
Console.WriteLine($"XOR: {bool1^bool2}");

//math compare
int first = 1;
int second = 2;
int third = 1;
Console.WriteLine($"First>second:{first>second}");
Console.WriteLine($"First<second:{first < second}");
Console.WriteLine($"First==third:{first == third}");
Console.WriteLine($"First!=third:{first != third}");
Console.WriteLine($"First!=second:{first != second}");
Console.WriteLine($"First>=second:{first >= second}");
Console.WriteLine($"First>=third:{first >= third}");

//bool complex
var bool3 = true;
var bool4 = false;
var bool5 = false;
Console.WriteLine($"AND(bool):{bool3& bool4&bool5}");
Console.WriteLine($"AND(bool):{bool3 | bool4 | bool5}");

//int bool logic
int var1 = 10;
int var2 = 3;

Console.WriteLine(var1 & var2);
Console.WriteLine(var2 | var1);
Console.WriteLine(var2 << var1);
Console.WriteLine (var1 >> var2);