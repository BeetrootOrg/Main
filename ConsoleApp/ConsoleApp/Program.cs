//визначити значення N-ого числа Фібоначчі
//Числа Фібоначчі - це послідовність чисел, що задана наступними формулами
//F(0) = 0
//F(1) = 1
//F(n) = F(n-1) + F(n-2), n>=2
int x = 4;
int a = 0;
int b = 1;
int res = 0;

if (x == 0)
{
    res = 0;
}
else if (x == 1)
{
    res = 1;
}
else
{
    for (int i = 0; i < x; ++i)
    {
        res = b;
        b = a + b;
        a = b - a;

    }
}
Console.WriteLine(res);