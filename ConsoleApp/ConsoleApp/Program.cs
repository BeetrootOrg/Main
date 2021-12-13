using System;

namespace ConsoleApp
{
    //i.safontev/classwork/13-interfaces
    interface IAddTwoNumbers
    {
        int Add(int i1, int i2);// public by default
    }
    interface IMultiplyTwoNumbers
    {
        int Mul(int i1, int i2);
    }

    public class Calculator: IAddTwoNumbers, IMultiplyTwoNumbers
    {
        public int Add(int i1, int i2) => i1 + i2;
        public int Mul(int i1, int i2) => i1 * i2;
    }
    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            System.Console.WriteLine(AddTwoNumbers(calculator, 1, 2));  

        }

        //for example, not necessary
        //for all classes that inherits that interface
        static int AddTwoNumbers(IAddTwoNumbers addTwoNumbers, int i1, int i2) => addTwoNumbers.Add(i1, i2);
        static int MultiplyTwoNumbers(IMultiplyTwoNumbers mulTwoNumbers, int i1, int i2) => mulTwoNumbers.Mul(i1, i2);
    }
}