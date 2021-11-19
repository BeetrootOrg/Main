//string str = "Arthur";

//if (str == "Arthur")
//{
//    Console.WriteLine("Hello,Arthur");
//}
//else
//{
//    Console.WriteLine($"Hello{str}");
//}

//int i = 0;
//while (i < 10)
//{
//    Console.WriteLine(i);
//    i++;
//}

//Console.WriteLine("Do while");
//int incr = -1;
//do
//{
//    Console.WriteLine(incr);
//} while (++incr < 10);
////
//for (int j = 0; j < 20; ++j)
//{
//    if (i % 2 == 1)
//    {
//        Console.WriteLine(j);
//    }
//}
//for (int k = 1; k < 20; k += 2)
//{
//    Console.WriteLine(k);
//}
//for (int p = 0; p < 10; p++)
//{
//    Console.WriteLine(p * 2 + 1);
//}


//for(int i = 0; i < 10; i++)
//{
//    if (i == 5) continue;
//    Console.WriteLine(i);
//}
////
//Console.WriteLine("Write your name: ");
//string? name = Console.ReadLine(); 
//Console.WriteLine($"Hello: {name}");
////
//Console.WriteLine("Write your number: ");
//string? number = Console.ReadLine();


// !! HOMEWORK AREA: !! //

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


