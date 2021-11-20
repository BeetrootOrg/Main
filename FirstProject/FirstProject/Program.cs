int n = 2;
int f1=0, f2=1;
int sum = 0;
if (n == 1) sum = f1;
else if (n == 2) sum = f2;
for (int i = 2; i <= n; i++)
{
    sum = f1 + f2;
    f1 = f2;
    f2 = sum;
}
Console.WriteLine(sum);

        