//X
Console.WriteLine("Write X value: ");
string? strNumX = Console.ReadLine();
bool successX = int.TryParse(strNumX, out int numX);

//Y
Console.WriteLine("Write Y value: ");
string strNumY = Console.ReadLine();
bool successY = int.TryParse(strNumY, out int numY);

int sum = 0;
if (successY && successX == true)
{
    for (int i = numX; i <= numY; i++)
    {
        sum += i;
    }
    Console.WriteLine(sum);
}

else
{
    Console.WriteLine("It`s not number");
}


