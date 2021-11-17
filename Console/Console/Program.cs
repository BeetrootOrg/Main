using System;
string str = Console.ReadLine();

if(str == "dima")
{
    Console.WriteLine("Hello dima");
}
else if (str == "Dima") Console.WriteLine("Hello Dima");
else
{
    Console.WriteLine($"Hello {str}");
}

//----------------------------------------------------
int a = 10;
int b;

if (a == 10)
{
    b = 1;
}
else
{
    b = 0;
}
Console.WriteLine(b);

int c = a == 10 ? 10 : 0;
Console.WriteLine(c);

int d;
a = 0;
switch (a)
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
        default: d = 0;
        break;
}

int e = a switch
{
    0 => 42,
    1 => 43,
    2 => 1,
    _ => 0
};

Console.WriteLine(e);