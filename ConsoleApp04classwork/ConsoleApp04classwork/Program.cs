int value = 20;
int prev = 0;
int current = 1;
int temp;

Console.WriteLine(prev);

for (int i = 0; i <= value; i++)
{
    Console.WriteLine(current);
    temp = current;
    current = current + prev;
    prev = temp;
}
Console.ReadKey();
    

