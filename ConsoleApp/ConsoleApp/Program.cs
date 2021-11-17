string str = "dima";

if (str == "Dima" || str == "dima")
{
    Console.WriteLine("Hello, Dima");
}
else
{
    Console.WriteLine("Good Bye");
}

int a = 9;
int b;

// first option
if (a == 10)
{
    b = 10;
}
else
{
    b = 0;
}

Console.WriteLine(b);

// second option
b = a == 10 ? 10 : 0;
Console.WriteLine(b);

// third option
int c = a == 10 ? 10 : 0;

// impossible
// str == "Dima" ? Console.WriteLine("Hello, Dima") : Console.WriteLine("Hello, Another");

int d;
a = 3;
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
    _ => 0,
};

Console.WriteLine(e);