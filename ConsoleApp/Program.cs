int num;
Boolean success;
string strNum;
do
{
    Console.WriteLine("Write value of X, please (it must be number):");
    strNum = Console.ReadLine();
    success = Int32.TryParse(strNum, out num);
} while (!success);
int x,y;

x = Convert.ToInt32(strNum);

do
{
    Console.WriteLine("Write value of Y, please (it must be number):");
    strNum = Console.ReadLine();
    success = Int32.TryParse(strNum, out num);
} while (!success) ;

y = Convert.ToInt32(strNum);

Console.WriteLine($"X is {x}, Y is {y}");

if (x > y) 
{
    int tempInt = x;
    x = y;
    y = tempInt;

}

int sumResult =0;
int z = x;
do
{
    sumResult = sumResult + z++;

} while (z <= y);

Console.WriteLine($" sum of iteration X till Y by operator do...while is {sumResult}");

sumResult = 0;
for (z=x; z<= y; z++)
{
    sumResult = sumResult +z;
}
Console.WriteLine($"sum x and y be operator for is {sumResult}");

