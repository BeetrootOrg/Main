void FirstMethod()
{
    Console.WriteLine("1st method");
}
FirstMethod();

void ReturnMessage(string message)
{
    Console.WriteLine(message);
}
ReturnMessage("1st message");
ReturnMessage("2nd message");
ReturnMessage("3rd message");

void SumNum(int x, int y)
{
    int result = x + y;
    Console.WriteLine($"{x} + {y} = {result}");
}
SumNum(10, 20);
SumNum(30, 25);

void SumNum2(int x, int y) => Console.WriteLine($"{x} + {y} = {y + x}");
int a = 24, b = 16;
SumNum2(a, 10); // 34
SumNum2(5, 12); // 17
SumNum2(a, b); // 40

void PrintPerson(string name, int age)
{
    Console.WriteLine($"Name: {name}, Age: {age}");
}
int age1 = 24;
string name1 = "Bob";
PrintPerson(name1, age1); // "Name: Bob, Age: 24"
PrintPerson("Evgeniy", 24);

void UndefValue(string name, int age = 25, string company = "Undefined")
{
    Console.WriteLine($"Name: {name}, Age: {age}, Company: {company}");
}
UndefValue("Evgeniy", 24 );
UndefValue("Evgeniy", 24, "TestMatick");
UndefValue(name: "Evhenii", company: "TestMatick", age: 28); // {name}, {age}, {company}