
int n = 7;
Console.WriteLine(RoundToNext5(n));

static int RoundToNext5(int n)
{
    n /= 5;
    ++n;
    n *= 5;
    
    return n;
}

// NEXT PLEASE

int a = 6;
int b = 18;
Console.WriteLine(Gcd(a,b));

static int Gcd(int a, int b)
{
    int gcd = 1;

    for (int i = 1; i <= Math.Min(a,b); ++i)
    {
        if(a%i == 0 && b%i==0)
        {
            gcd = i;
        }
    }

    return gcd;
}