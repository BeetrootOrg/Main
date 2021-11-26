using System;

class ConsoleAppHomeworkRecurcion
{
    static void Main(string[] args)
    {
        //First task is so hard for me, sorry...
        //2 task:
        Console.WriteLine(Pow(2,2));
        //3 task:
        Foo(10);
    }
    static int Pow(int x, int y, int i = 1)
    {
        if (i < y)
        {
            x *= x;
            i++;
            x = Pow(x, y, i);
        }
        return x;
    }
    static int Foo(int n, int temp = 1)
    {
        if (temp <= n)
        {
            Console.WriteLine(temp);
            temp++;
            temp = Foo(n, temp);
        }

        return temp;
    }
    
}