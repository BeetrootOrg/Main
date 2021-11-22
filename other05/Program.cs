decimal FirstTask (decimal number)
{
    return Math.Ceiling((number + 1) / 5) * 5;
}

int SecondTask (int a, int b)
{
    int dec = 0;
    for (int i = Math.Min(a, b); i > 0; i--)
    {
        if (dec != 0 && a % i == 0 && b % i == 0)
        {
            dec = i;
        }
    }
    return dec;
}
