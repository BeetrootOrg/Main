// See https://aka.ms/new-console-template for more information

int n = 20;
int sum = 0;
int x0 = 0;
int x1 = 1111;

Console.WriteLine(x0);
Console.WriteLine(x1);

for (int i = 0; i < n - 2; i++)
{
    sum = x0 + x1;
    x0 = x1;
    x1 = sum;
    Console.WriteLine(sum);
}
Console.WriteLine($"{x1} / {x0} = {(double)x1 / (double)x0}");

