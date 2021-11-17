// See https://aka.ms/new-console-template for more information

int a = 5;
Console.WriteLine(-a);

int b = -7;
Console.WriteLine(-Math.Abs(b));

int c = 9;
Console.WriteLine(Math.Truncate(Math.Sqrt(c)) == Math.Sqrt(c));
Console.WriteLine();

//CONDITIONS

string str = "dima";

if (str == "Dima" || str == "dima")
{
    Console.WriteLine("Hello, Dima");
}
else Console.WriteLine($"Hello, {str}");


//Ternar operator

int a1 = 10;
int b1;

if (a1 == 10)
{
    b1 = 10;
}
else
{
    b1 = 0;
}
Console.WriteLine(b1);

b1 = a1 == 10 ? 10 : 0;
Console.WriteLine(b1);


//SWITCH

int d;
a = 3;
switch(a)
{
    case 0:
        d = 42;
        break;
    case 1:
        d = 43;
        break;
    case 2:
        d = 1;
        break;
    default:
        d = 0;
        break;
}
Console.WriteLine(d);

int e = a switch
{
    0 => 42,
    1 => 43,
    2 => 1,
    _ => 42,
};
Console.WriteLine(d + "\n\n");


//CICLES

Console.WriteLine("FOR cicle");
for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}


Console.WriteLine("\nWHILE cicle");
int j = 0;
while (j < 10)
{
    Console.WriteLine(j);
    j++;
}

Console.WriteLine("\nDO WHILE cicle");
int incr = -1;
do
{
    Console.WriteLine(incr);
}while (++incr < 10);


//BREAK & CONTINUE
Console.WriteLine("\nContinue");
for (int i = 0; i < 10; ++i)
{
    if (i == 5) continue;
    Console.WriteLine(i);
}

Console.WriteLine("\nBreak");
for (int i = 0; i < 10; ++i)
{
    if (i == 5) break;
    Console.WriteLine(i);
}

//CONSOLE

Console.WriteLine("Write your Name:");
string? name = Console.ReadLine();
Console.WriteLine(name);


Console.WriteLine("Write number, please:");
string strNum = Console.ReadLine();
bool success = int.TryParse(strNum, out int num);
num = int.Parse(strNum);
Console.WriteLine(success ? $"It is number {num}" : "It is not a number");