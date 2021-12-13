namespace ConsoleApp
{
    interface IAddTwoNumbers
    {
        int Add(int i1, int i2);
    }

    interface IMultiplyTwoNumbers
    {
        int Mul(int i1, int i2);
    }

    public class Calculator : IAddTwoNumbers, IMultiplyTwoNumbers
    {
        public int Add(int i1, int i2) => i1 + i2;
        public int Mul(int i1, int i2) => i1 * i2;
    }

    public class WrongAddCalculator : IAddTwoNumbers
    {
        public int Add(int i1, int i2) => i1 - i2;
    }

    class Program
    {
        static void Main()
        {
            Calculator calculator = new Calculator();
            WrongAddCalculator wrongCalculator = new WrongAddCalculator();
            System.Console.WriteLine(AddTwoNumbers(calculator, 1, 2));
            System.Console.WriteLine(AddTwoNumbers(wrongCalculator, 1, 2));

            System.Console.WriteLine(MulTwoNumbers(calculator, 1, 2));
        }

        static int AddTwoNumbers(IAddTwoNumbers addTwoNumbers, int i1, int i2) => addTwoNumbers.Add(i1, i2);
        static int MulTwoNumbers(IMultiplyTwoNumbers addTwoNumbers, int i1, int i2) => addTwoNumbers.Mul(i1, i2);
    }
}