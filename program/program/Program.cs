string str = "another";

if (str == "Dima")
{
    Console.WriteLine("Hello, Dima");
}
else if (str == "dima")
{
    Console.WriteLine("Hello, Dima");
}
else
{
    Console.WriteLine($"Good Bye");
}


int a = 10;
int b;

if (a == 10)
{
    b = 10;
}
else
{
    b = 0;
}

Console.WriteLine(b);

b = a == 10 ? 10 : 0;
Console.WriteLine(b);


int d;
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

for (int i = 0; i < 10; i++)
{
    Console.WriteLine(i);
}

for (int i = 9; i>= 0; --i)
{
    Console.WriteLine(i);
}
int incr = 0;


while (incr<10)
{
    Console.WriteLine(incr);
    ++incr;
}