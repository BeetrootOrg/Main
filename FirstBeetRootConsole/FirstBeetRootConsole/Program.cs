// See https://aka.ms/new-console-template for more information
int LongName = 5;
Console.WriteLine(LongName);

byte a = 3;
byte b = 4;
byte c = (byte)(a + b);
Console.WriteLine(c);


int mul = a / b;
Console.WriteLine(mul);

int i = 42;
int j = 90;
Console.WriteLine(j / i);
Console.WriteLine(i % j);

double x = 3.6;
Console.WriteLine(x * x * x + 2 * x * x + 5 * x + 6);

decimal y = 3.6m;
Console.WriteLine(y * y * y + 2 * y * y + 5 * y + 6);

double z = 3.6;
Console.WriteLine(Math.Pow(z, 3) + 2 * Math.Pow(z, 2) + 5 * z + 6);

int incr = 5;
int result1 = incr++;
int result2 = ++incr;
Console.WriteLine($"{result1}, {result2}, {incr}");


bool bool1 = true;
bool bool2 = false;
Console.WriteLine($"AND: {bool1 && bool2}");
Console.WriteLine($"OR: {bool1 || bool2}");
Console.WriteLine($"EQUAL: {bool1 == bool2}");
Console.WriteLine($"NOT: {!bool1}");
Console.WriteLine($"NOT: {!bool2}");
Console.WriteLine($"XOR: {bool1 ^ bool2}");


int first = 1;
int second = 2;
int third = 1;
Console.WriteLine($"first > second: {first > second}");
Console.WriteLine($"first < second: {first < second}");
Console.WriteLine($"first == third: {first == third}");
Console.WriteLine($"first != third: {first != third}");
Console.WriteLine($"first != second: {first != second}");
Console.WriteLine($"first >= third: {first >= third}");
Console.WriteLine($"first >= second: {first >= second}");


int aa = 8;
int bb = 2;

aa = aa + bb;
aa += bb;
Console.WriteLine(aa);