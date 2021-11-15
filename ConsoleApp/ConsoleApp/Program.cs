// variable name - 'a long long name'
byte aLongLongName = 5;
Console.WriteLine(aLongLongName);

// define two variables
byte a = 3;
byte b = 4;
int c = a + b;
Console.WriteLine(c);

int mul = a / b;
Console.WriteLine(mul);

// next divide example
int i = 42;
int j = 90;
Console.WriteLine(j / i);
Console.WriteLine(j % i);

// x^3+2*x^2+5*x+6
double x = 3.6;
Console.WriteLine(x * x * x + 2 * x * x + 5 * x + 6);

// the same with decimal
decimal y = 3.6m;
Console.WriteLine(y * y * y + 2 * y * y + 5 * y + 6);

// the same with Math
double z = 4;
Console.WriteLine(Math.Pow(z, 3) + 2 * Math.Pow(z, 2) + 5 * z + 6);

// increment/decrement
int incr = 5;
int result1 = incr++; // first - return value, second - increment; result1 == 5; incr == 6
int result2 = ++incr; // first - increment, second - return value; result2 == 7; incr == 7
Console.WriteLine($"{result1}, {result2}, {incr}");

// bool logic
var bool1 = true;
var bool2 = false;
Console.WriteLine($"AND: {bool1 && bool2}");
Console.WriteLine($"AND (bool): {bool1 & bool2}");
Console.WriteLine($"OR: {bool1 || bool2}");
Console.WriteLine($"OR (bool): {bool1 | bool2}");
Console.WriteLine($"EQUAL: {bool1 == bool2}");
Console.WriteLine($"NOT bool1: {!bool1}");
Console.WriteLine($"NOT bool2: {!bool2}");
Console.WriteLine($"XOR: {bool1 ^ bool2}");

// math equality & comparison
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

// bool complex logic
var bool3 = true;
var bool4 = false;
var bool5 = false;
Console.WriteLine($"AND (bool): {bool3 & bool4 & bool5}");
Console.WriteLine($"OR (bool): {bool3 | bool4 | bool5}");

// int bool logic
int coolVar1 = 10; // in bin = 1010
int coolVar2 = 3;  // in bin = 0011
                   // and    = 0010 -> 2
                   // or     = 1011 -> 11
Console.WriteLine(coolVar1 & coolVar2);
Console.WriteLine(coolVar1 | coolVar2);
Console.WriteLine(coolVar1 << coolVar2); // 10 << 3; 00001010 << 3; 01010000
Console.WriteLine(coolVar1 >> coolVar2); // 10 >> 3; 00001010 >> 3; 00000001

// assign
int aa = 8;
int bb = 2;

aa = aa + bb;
aa += bb; // identical to the line above

aa %= bb; // aa = aa % bb
aa -= bb; // aa = aa - bb

Console.WriteLine(aa);

// temp
aa = 10;
bb = 5;
int temp = aa; // assign 10
aa = bb; // assign 5
bb = temp; // assign 10

Console.WriteLine(aa);
Console.WriteLine(bb);