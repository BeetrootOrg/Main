const int n = 10;
int res=0;
int a = 1;
int b = 0;
int c;

switch (n)
{
    case < 0: res = 0; break;
    case 0: res = 0; break;
    case 1: res = 1; break;
    case 2: res = 1; break;
    default: for (int i = 2; i < n; i++)
        {
            c = a;
            a = a + b;
            b = c;
            res = a + b;
           //Console.WriteLine($"{i} try of Fibonacci is {res}");
        }
        break;

}
Console.WriteLine($"{n} of Fibonacci is {res}" );
