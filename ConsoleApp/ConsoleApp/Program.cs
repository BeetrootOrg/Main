string str = "Sasha";

if (str == "Sasha" || str == "sasha")
{
    Console.WriteLine($"Hello, Sasha!");
}
else
{
    Console.WriteLine($"Hello, {str}!");
}

int a = 9;
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
    3 => 1,
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

int whileInt = 20;
while (whileInt < 30)
{
    Console.WriteLine(whileInt);
    ++whileInt;
};

whileInt = 20;
Console.WriteLine("Do while");
do
{
    Console.WriteLine(whileInt);
}
while (++whileInt < 30);


int incr = 10;
Console.WriteLine("while");

while (++incr < 10)
{
    Console.WriteLine(incr);
}

Console.WriteLine("dowhile");
do
{

    Console.WriteLine(incr);
} while (++incr < 10);

Console.WriteLine("Even Numbers");
for (int i = 0; i < 20; ++i)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("Odd Numbers");

for (int i = 0; i < 20; i += 2)
{
    Console.WriteLine(i);
}


for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i * 2 + 1);
}
Console.WriteLine("Task");

for (int i = 0; i < 10; ++i)
{
    if (i == 5) continue;
    Console.WriteLine(i);
}

for (int i = 0; i < 10; ++i)
{
    if (i == 5) break;
    Console.WriteLine(i);
}
//Console.WriteLine("Write your name:");
//string? name = Console.ReadLine();

//Console.WriteLine($"Hello, {name}");

//Console.WriteLine("Write number:");

string? strNum = Console.ReadLine();
//int num = int.Parse(strNum);
//int num = Convert.ToInt32(strNum);
//Console.WriteLine($"{num}^2={num * num}");

int num;
Console.WriteLine("Write number please:");
strNum = Console.ReadLine();
bool success = int.TryParse(strNum, out num);
Console.WriteLine(success ? $"It is number {num}" : "It is not a number.");