int X;
int Y;
bool isNumber;
do
{
    Console.WriteLine($"Input X: ");
    isNumber = int.TryParse(Console.ReadLine(), out X);
} while (!isNumber);
do
{
    Console.WriteLine($"Input Y");
    isNumber = int.TryParse(Console.ReadLine(), out Y);
} while (!isNumber);

int max, min;
if (X > Y) { max = X; min = Y; }
else { max = Y; min = X; }

int sum = 0;
for (int index = min; index <= max; ++index)
{
    sum += index;
}

Console.WriteLine($"Sum = {sum}");