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

for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
}

for (int i = 9; i >= 0; --i)
{
    Console.WriteLine(i);
}

int incr = 0;
while (incr < 10)
{
    Console.WriteLine(incr);
    ++incr;
}


Console.WriteLine("Pre increment");
incr = -1;
while (++incr < 10)
{
    Console.WriteLine(incr);
}

Console.WriteLine("Post increment");
incr = -1;
while (incr++ < 10)
{
    Console.WriteLine(incr);
}

Console.WriteLine("do while");
incr = -1;
do
{
    Console.WriteLine(incr);
} while (++incr < 10);


// difference
Console.WriteLine("Diff");
incr = 10;
while (incr++ < 10)
{
    Console.WriteLine(incr);
}

do
{
    Console.WriteLine(incr);
} while (++incr < 10);

// ++incr < 10 -> first increment, then condition
// incr++ < 10 -> first condition, then increment

Console.WriteLine("FOR");
for (; ; )
{
    break;
}

for (; incr < 15; ++incr)
{
    Console.WriteLine(incr);
}

for (; incr < 20;)
{
    Console.WriteLine(++incr);
}

int ii, jj = 20;

Console.WriteLine("Non-even numbers");
for (int i = 0; i < 20; ++i)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
    }
}

for (int i = 1; i < 20; i += 2)
{
    Console.WriteLine(i);
}


for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i * 2 + 1);
}