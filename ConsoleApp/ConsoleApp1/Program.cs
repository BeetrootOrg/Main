
Console.WriteLine(Gcd(15, 10));

static int RoundToNext5(int n)
{
	int x = 0;
    while ((n + x) % 5 != 0)
    {
        x++;
    }
    return n + x;
}

static int Gcd(int a, int b)
{
    int c = a > b ? b : a; 
    while(a%c !=0 || b%c !=0 )
    {
        c--;
    }
    return c;
}