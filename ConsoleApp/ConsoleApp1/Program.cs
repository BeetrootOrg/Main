Console.WriteLine(Fact(0));
Console.WriteLine(Fact(1));
Console.WriteLine(Fact(5));

static long Fact(int n)
{
	if (n == 0|| n == 1) return 1;
	return n * Fact(n - 1);
}

static int Gcd(int a, int b)
{
    return Gcd(a, b, Math.Min(a, b));
}

static int Gcd(int a, int b, int possibleGcd)
{
	if(a%possibleGcd == 0 || b % possibleGcd == 0)
    {
		return possibleGcd;
    }
    else
    {
        return Gcd(a, b, possibleGcd - 1);
    }
}
