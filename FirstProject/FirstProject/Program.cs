int n = 4;
int f1=0, f2=1;
int sum = 0;

for (int i = 2; i < n; i++)
{
    sum = f1 + f2;
    f1 = f2;
    f2 = sum;
}
Console.WriteLine(sum);

        