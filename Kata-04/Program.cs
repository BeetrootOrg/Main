int x = 5;
int result = 0;
int prm;

if (x == 0) { result = 0; }
else if (x == 1) { result = 1; }
else
{
    for(int i = 2;i <= x; i++)
    {
        int y = i - 1;
        int z = i;
        if (result == 0) result = y;
        result = result * z;
    }

}
Console.WriteLine(result);