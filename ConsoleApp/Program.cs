/*
C# Conditions and If Statements
Less than: a < b
Less than or equal to: a <= b
Greater than: a > b
Greater than or equal to: a >= b
Equal to a == b
Not Equal to: a != b
*/

//first equation

int x = 5;
int y = 11;

int sumResult = 0;

while (x < y)
{
    sumResult = sumResult + x + y;
    x++;

}
Console.WriteLine($"full sum of iteration x and y is {sumResult}");

sumResult = 0;
for (int z = 0; z < y; z++)
{
    sumResult = sumResult + z + y;
}
Console.WriteLine($"some sum of iteration z and y {sumResult}");

Console.WriteLine("write some X");
double tX = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("You need to write some Y");
double tY = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"your x is {tX} and your y is {tY}");