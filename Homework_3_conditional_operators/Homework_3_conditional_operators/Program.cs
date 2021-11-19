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


// newyear
var nowDate = DateTime.Now;
var prevNewYear = new DateTime(nowDate.Year, 1, 1);
var nextNewYear = new DateTime(nowDate.Year + 1, 1, 1);
var daysPassed = (nowDate - prevNewYear).Days;
var daysLeft = (nextNewYear - nowDate).Days;
Console.WriteLine($"{daysPassed} days passed from New Year");
Console.WriteLine($"{daysLeft} days left to New Year");