int x = 2;
byte a = 34;
short b = 77;
int c = 6;
long d = 4567;
bool e = true;
char f = 'R';
float g = 45.65f;
double h = 7665d;
decimal i = 52.34m;
string j = "ussia";
float y1;
double y2;
double y3;
y1 = -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15;
y2 = Math.Abs(g) * Math.Sin(g);
y3 = 2 * Math.PI * d;
Console.WriteLine(y1);
Console.WriteLine(y2);
Console.WriteLine(y3);
Console.WriteLine(Math.Max(Convert.ToSingle(i), g));
Console.WriteLine(f + j);

DateTime date1 = DateTime.Now;
DateTime date2 = new DateTime(2022, 1, 1, 0, 0, 0);
TimeSpan interval = date2 - date1;

Console.WriteLine("{1} {0}", "days left to New Year", (interval.Days).ToString());