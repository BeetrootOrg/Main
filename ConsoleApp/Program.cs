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

int incr = 5;
int result1 = incr++;
int result2 = ++incr;