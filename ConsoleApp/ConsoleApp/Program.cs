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