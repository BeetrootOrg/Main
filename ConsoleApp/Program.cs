byte aLongLongLongname = 5;
Console.WriteLine(aLongLongLongname);

//define 2 var
byte a = 3;
byte b = 4;
int c = a + b;
Console.WriteLine(c);

int mal1 = a / b;
int mal2 = b / a;

//next divide;
Console.WriteLine(mal2);
int i = 42;
int j = 90;

Console.WriteLine(j/i);
Console.WriteLine(j%i);

//x^3+3*x^2+5*x+6
double x = 3.6;
Console.WriteLine(x * x * x + 2 * x * x + 5 * x + 6);

//y^3+3*y^2+5*y+6
decimal y = 3.6M;
Console.WriteLine(y * y * y + 2 * y * y + 5 * y + 6);

// with math

double z = 4;
Console.WriteLine(Math.Pow(z, 3)+2*Math.Pow(z,2)+5*z+6);

int incr = 5;
int result1 = incr++;
int result2 = ++incr;

Console.WriteLine($"some result {result1} and {result2}");

//boolean

var bool1 = true;
var bool2 = false;


Console.WriteLine($"AND {bool1 &&bool2}");
Console.WriteLine($"OR {bool1 || bool2}");
Console.WriteLine($"EQUAL {bool1 == bool2}");
Console.WriteLine($"NOT bool1 {!bool1}");
Console.WriteLine($"NOT bool2 {!bool2}");
Console.WriteLine($"XOR {bool1^bool2}");

//comparison

int first = 1;
int second=2;
int third = 1;
Console.WriteLine($"first >second: {first > second}");
Console.WriteLine($"first <second: {first < second}");
Console.WriteLine($"first ==third: {first ==third}");
Console.WriteLine($"first !=third: {first != third}");
Console.WriteLine($"first !=second: {first != second}");
Console.WriteLine($"first >=third: {first >= third}");
Console.WriteLine($"first >=second: {first >= second}");

//bool
var bool3 = true;
var bool4 = false;
var bool5 = false;
Console.WriteLine($"AND (bool): {bool3 & bool4 & bool5}");
Console.WriteLine($"OR (bool): {bool3 | bool4 | bool5}");

//int bool;

int CoolVar1 = 10; 
int CoolVar2 = 3;
Console.WriteLine(CoolVar1 & CoolVar2);
Console.WriteLine(CoolVar1 | CoolVar2);
Console.WriteLine(CoolVar1 << CoolVar2); //10<<3;
Console.WriteLine(CoolVar1 >> CoolVar2); //10<<3;

//assign

int aa = 8;
int bb = 2;

aa = aa + bb;
aa += bb;
Console.WriteLine(aa);

//temp;
aa = 10;
bb = 5;
int temp = aa;
aa = bb;
bb = temp;
Console.WriteLine($"aa: {aa}, bb: {bb}");

