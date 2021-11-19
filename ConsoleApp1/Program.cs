string str = "dima";

if (str == "Dima" || str == "dima")
{
    Console.WriteLine("Hello Dima");
}
else
{
    Console.WriteLine("Good Bye");
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

b = a == 10 ? 10 :0;
Console.WriteLine(b);


int c = a == 10 ? 10 : 0;

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
Console.WriteLine(d);

for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
}

for (int i = 9; i >= 0; --i)
{
    Console.WriteLine(i);
}

Console.WriteLine("Pre increment");
int incr = -1;
while (++incr < 10)
{
    Console.WriteLine(incr);
}

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

for (; ; )
{
    break;
}

for (; incr < 15; ++incr)
{
    Console.WriteLine(incr);
}

for (int i, j = 20; incr < 20;)
{
    Console.WriteLine(++incr);
}
int ii, jj = 20;





for (int i = 0; i < 20; ++i)
{
    if (i % 2 ==1)
    {
        Console.WriteLine(i);
    }

}
for (int i = 1; i < 20; i +=2)
{  
    Console.WriteLine(i);

}
for (int i = 0; i < 10; ++i)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
    }
}



for (int i = 0; i < 20; ++i)
{
    if (i == 5) continue;
        Console.WriteLine(i);
}

for (int i = 0; i < 20; ++i)
{
    if (i == 5) break;
    Console.WriteLine(i);
}

while (true)
{
    if (true) break;
}

Console.WriteLine("Type ur name");
string? name = Console.ReadLine();
Console.WriteLine($"Hello, {name}");


Console.WriteLine("Write number");

string? strNum = Console.ReadLine();
int num = int.Parse(strNum);
num = Convert.ToInt32(strNum);
Console.WriteLine($"{num}^2={num * num}");
Console.WriteLine($"{num}^2.5={Math.Pow(num, 2.5)}");

Console.WriteLine("Write number, pls");
strNum = Console.ReadLine();
bool success = int.TryParse(strNum, out num);
//num = Convert.ToInt32(strNum);
//Console.WriteLine($"{num}^2={num * num}");
Console.WriteLine($"{num}^2.5={Math.Pow(num, 2.5)}");