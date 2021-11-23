string str = "Harry";
if (str == "Harry" || str == "harry")
{
    Console.WriteLine("Hello Harry");
}
else
{
    Console.WriteLine("Hello another");
}

int a = 10;
int b = a == 10 ? 10 : 0;

if (a == 10)
{
    b = 10;
}
else
{
    b = 0;
}
Console.WriteLine(b);

int y;
a = 42;
switch (a)
{
    case 1:
        y = 42;
        break;
    case 2:
        y = 43;
        break;
    case 3:
        y = 1;
        break;
    default:
        y = 0;
        break;
}
Console.WriteLine(y);
//int e = a switch
//{
//    1 => 42,
//    2 => 43,
//    3 => 1,
//    4 => 0,
//};
//Console.WriteLine(e);

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}
//Console.WriteLine();

//for (int i = 9; i >= 0; --i)
//{
//    Console.WriteLine(i);
//}
int incr = 0;
while (incr < 0)
{
    Console.WriteLine(incr);
    incr++;
}
Console.WriteLine("pre");
int inc = -1;
while (++inc < 0)
{
    Console.WriteLine(inc);
    inc++;
}
Console.WriteLine("post");
int j = -1;
while (j++ < 0)
{
    Console.WriteLine(j);
    j++;
}