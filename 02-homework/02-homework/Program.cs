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




// DATETIME TASK

var nowDate = DateTime.Now;
var prevNewYear = new DateTime(nowDate.Year, 1, 1);
var nextNewYear = new DateTime(nowDate.Year + 1, 1, 1);
var daysPassed = (nowDate - prevNewYear).Days;
var daysLeft = (nextNewYear - nowDate).Days;
Console.WriteLine($"-----------------DateTime Task-----------------");
Console.WriteLine($"{daysPassed} days passed from New Year");
Console.WriteLine($"{daysLeft} days left to New Year");









// variable name 'a Long Long Name'
byte aLongLongName = 5;
Console.WriteLine(aLongLongName);

// define two variables
byte a = 3;
byte b = 4;
int c = a + b;
Console.WriteLine(c);


int mul = a / b;
Console.WriteLine(mul);

int i = 42;
int j = 90;
Console.WriteLine(j / i);
Console.WriteLine(j % i);

// y^3 + 2*x^2 + 5*x + 6 

double x = 3.6;
Console.WriteLine(x * x * x + 2 * x * x + 5 * x + 6);

// the same with math

double z = 4;
Console.WriteLine(z * z * z + 2 * z * z + 5 * z + 6);
Console.WriteLine(Math.Pow(z, 3) + 2 * Math.Pow(z, 2) + 5 * z + 6);


decimal y = 3.6m;
Console.WriteLine(y * y * y + 2 * y * y + 5 * y + 6);

// increment/decrement

int incr = 5;
int result1 = incr++;
int result2 = ++incr;
Console.WriteLine($"{result1}, {result2}, {incr}");

// bool logic
var bool1 = true;
var bool2 = false;
Console.WriteLine($"AND: {bool1 && bool2}");
Console.WriteLine($"OR: {bool1 || bool2}");
Console.WriteLine($"EQUAL: {bool1 == bool2}");
Console.WriteLine($"NOT BOOL1: {!bool1}");
Console.WriteLine($"NOT BOOL1: {!bool2}");
Console.WriteLine($"XOR: {bool1 ^ bool2}");

// math equality & comparison

int first = 1;
int second = 2;
int third = 1;
Console.WriteLine($"first > second: {first > second}");
Console.WriteLine($"first < second: {first < second}");
Console.WriteLine($"first == second: {first == second}");
Console.WriteLine($"first != third: {first != third}");
Console.WriteLine($"first != second: {first != second}");
Console.WriteLine($"first >= third: {first >= third}");
Console.WriteLine($"first <= second: {first <= second}");

// bool complex logic
int coolVar1 = 10;
int coolVar2 = 3;
Console.WriteLine(coolVar1 & coolVar2);
Console.WriteLine(coolVar1 | coolVar2);
Console.WriteLine(coolVar1 << coolVar2);
Console.WriteLine(coolVar1 >> coolVar2);


// assign
int aa = 18;
int bb = 12;
aa = aa + bb;// 30
Console.WriteLine(aa);
aa += bb;// 42 aa + bb
Console.WriteLine(aa);
aa %= bb; // 6 aa & bb
Console.WriteLine(aa);
aa -= bb; // -6 aa - bb
Console.WriteLine(aa);

// temp
aa = 10;
bb = 5;
int temp = aa; // assign 10
aa = bb; //assign 5
bb = temp; //assign 10
Console.WriteLine(aa);
Console.WriteLine(bb);


