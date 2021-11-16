Console.WriteLine("Insert 'a' integer");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("Insert 'b' integer");
int b = int.Parse(Console.ReadLine());
Console.WriteLine("Insert 'e' double");
double e = double.Parse(Console.ReadLine());
Console.WriteLine("Insert 'r' double");
double r = double.Parse(Console.ReadLine());

//-6*x^3+5*x^2-10*x+15
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6 * a ^ 3 + 5 * a ^ 2 - 10 * a + 15} | x ={a}");
Console.WriteLine($"-6*x^3+5*x^2-10*x+15 = {-6 * b ^ 3 + 5 * b ^ 2 - 10 * b + 15} | x ={b}");

//abs(x)*sin(x)
// I applied the "Math.Round" for less digits after the decimal point
Console.WriteLine($"abs(x)*sin(x) {Math.Round(Math.Abs(a) * Math.Sin(a), 2)} | x = {a}");
Console.WriteLine($"abs(x)*sin(x) {Math.Round(Math.Abs(b) * Math.Sin(b), 2)} | x = {b}");
Console.WriteLine($"abs(x)*sin(x) {Math.Round(Math.Abs(e) * Math.Sin(e), 2)} | x = {e}");
Console.WriteLine($"abs(x)*sin(x) {Math.Round(Math.Abs(r) * Math.Sin(r), 2)} | x = {r}");

//2*pi*x
Console.WriteLine($"{Math.Round(2 * Math.PI * a, 2)} | x = {a}");
Console.WriteLine($"{Math.Round(2 * Math.PI * b, 2)} | x = {b}");
Console.WriteLine($"{Math.Round(2 * Math.PI * e, 2)} | x = {e}");
Console.WriteLine($"{Math.Round(2 * Math.PI * r, 2)} | x = {r}");

//max(x, y)
Console.WriteLine($"{Math.Max(a, b)} | x = {a} | y = {b}");
Console.WriteLine($"{Math.Max(e, r)} | x = {e} | y = {r}");

//Exchange the values of 2 variables without using the third variable
Console.WriteLine("Insert 'first' integer");
int first = int.Parse(Console.ReadLine());
Console.WriteLine("Insert 'second' integer");
int second = int.Parse(Console.ReadLine());
Console.WriteLine($"first={first},second={second}");
second += first;
first = second - first;
second -= first;
Console.WriteLine($"first={first},second={second}");