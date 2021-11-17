string str = "vova";
string str2 = "TestName";

if (str == "Vova") 
{
    Console.WriteLine($"Hello,{str}! ");
}
else if (str == "vova") 
{
    Console.WriteLine($"Hello, {str2}");
}


/*for (int i = 0; i < 10; ++i)
{
    Console.WriteLine(i);
}
*/


/*
 for (int i = 9; i >= 0; --i)
{
    Console.WriteLine(i);
}
*/

/*
 * int incr = 0;
while (incr < 10)
{
    Console.WriteLine(incr);
    ++incr;
}
*/

int incr = -1;
while (incr++ < 10)
{
    Console.WriteLine(incr);

}

Console.WriteLine("do while") ;

incr = -1;
do
{
    Console.WriteLine(incr);
} while (++incr < 10);

Console.WriteLine("try while");
incr = 10;
while (incr++ <10)
{
    Console.WriteLine(incr);
}
Console.WriteLine("diff between while and do");

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
for (; incr < 20;)
{
    Console.WriteLine(++incr);
}

//int ij, jj = 20;

Console.WriteLine("first try");

for (int i = 0; i < 20; ++i)
{
    if (i % 2 == 1)
    {
        Console.WriteLine(i);
    }
}

Console.WriteLine("second try");

for (int i = 1; i < 20; i += 2)
{
        Console.WriteLine(i);
}

Console.WriteLine("third try");
for (int i = 0; i < 10; ++i)
{ 
    Console.WriteLine(i*2+1);
}

Console.WriteLine("Write your name:");
string? name= Console.ReadLine();
Console.WriteLine($"Hi, {name}");

Console.WriteLine("Write digit:");
string? strNum = Console.ReadLine();
int num = int.Parse(strNum);
num =Convert.ToInt32(strNum);
Console.WriteLine($"{num}^2={num * num}");
Console.WriteLine($"{num}^2.5={Math.Pow(num,2.5)}");

Console.WriteLine("Write digits, please:");
strNum = Console.ReadLine();
bool success = int.TryParse(strNum, out num);
num = Convert.ToInt32(strNum);

Console.WriteLine(success? $"It is number{num}":"It is not number");

do
{
    Console.WriteLine("Write number, pleeeaseeeee:");
    strNum = Console.ReadLine();
    success = int.TryParse(strNum, out num);
} while (!success);