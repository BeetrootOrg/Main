using System;
namespace Course
{
    enum BinaryOperationType
    {
        Plus,
        Minus
    }
    class UnaryOperation
    {
        public virtual int Operation(int num) => throw new NotImplementedException();
    }
    class UnaryPlusOperation : UnaryOperation
    {
        public override int Operation(int num) => num;
    }
    class UnaryMinusOperation : UnaryOperation
    {
        public override int Operation(int num) => -num;
    }

    class BinaryOperation
    {
        public virtual int Operation(int num1, int num2) => throw new NotImplementedException();
    }
    class PlusOperation : BinaryOperation
    {
        public override int Operation(int num1, int num2) => num1 + num2;
    }
    class MinusOperation : BinaryOperation
    {
        public override int Operation(int num1, int num2) => num1 - num2;
        // factory method
        public static BinaryOperation Create() => new MinusOperation();
    }

    class Calculator
    {
        public int Calculate(BinaryOperation operation, int num1, int num2) => operation.Operation(num1, num2);
    }
    // abstract factory
    class BinaryFactory
    {
        public BinaryOperation CreateOperation(BinaryOperationType binaryOperation) => binaryOperation switch
        {
            BinaryOperationType.Plus => new PlusOperation(),
            BinaryOperationType.Minus => new MinusOperation(),
            _ => throw new NotImplementedException(nameof(binaryOperation)),
        };
    }

    class Program
    {
        static void Main()
        {

        }
    }
}
