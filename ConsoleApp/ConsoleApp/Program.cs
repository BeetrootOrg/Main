using System;

namespace ConsoleApp
{
    enum BinaryOperationType
    {
        Plus,
        Minus,
        Multiply
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

    // 1st strategy
    class AddOperation : BinaryOperation
    {
        public override int Operation(int num1, int num2) => num1 + num2;
    }

    // 2nd strategy
    class MinusOperation : BinaryOperation
    {
        public override int Operation(int num1, int num2) => num1 - num2;

        // factory method
        public static BinaryOperation Create() => new MinusOperation();
    }

    class MultiplyOperation : BinaryOperation
    {
        public override int Operation(int num1, int num2) => num1 * num2;
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
            BinaryOperationType.Plus => new AddOperation(),
            BinaryOperationType.Minus => new MinusOperation(),
            BinaryOperationType.Multiply => new MultiplyOperation(),
            _ => throw new ArgumentOutOfRangeException(nameof(binaryOperation)),
        };
    }

    class Animal
    {
        public int NumOfPaws { get; set; }
        public string Type { get; set; }

        public override string ToString() => $"Paws = {NumOfPaws}; Type = {Type}";

        public Animal Prototype() => new Animal
        {
            NumOfPaws = NumOfPaws,
            Type = Type
        };
    }

    class Singleton
    {
        public static Singleton Instance => new Singleton();
        private Singleton() { }

        public int Method() => 42;
    }


    // builder
    class AnimalBuilder
    {
        private string _type;
        private int? _numOfPaws;

        public AnimalBuilder SetNumOfPaws(int num)
        {
            if (_numOfPaws == null)
            {
                if (num < 0)
                {
                    throw new ArgumentOutOfRangeException("Num of paws must be positive");
                }

                _numOfPaws = num;
            }
            else
            {
                throw new Exception("Num of paws already initialized");
            }

            return this;
        }

        public AnimalBuilder SetType(string type)
        {
            if (_type != null)
            {
                throw new Exception("Type already initialized");
            }

            _type = type;

            if (type == "cat" || type == "dog")
            {
                if (_numOfPaws != null && _numOfPaws != 4)
                {
                    throw new Exception("Are you idiot?");
                }
                
                _numOfPaws = 4;
            }

            return this;
        }

        public Animal Build()
        {
            if (_numOfPaws == null || _type == null)
            {
                throw new Exception("Please provide values");
            }

            return new Animal
            {
                NumOfPaws = _numOfPaws.Value,
                Type = _type
            };
        }
    }

    class Program
    {
        static void Main()
        {
            var calculator = new Calculator();
            var factory = new BinaryFactory();

            Console.WriteLine(calculator.Calculate(factory.CreateOperation(BinaryOperationType.Multiply), 
                5, 
                new UnaryMinusOperation().Operation(3)));

            var animalBuilder = new AnimalBuilder();

            Animal animal = animalBuilder
                .SetType("cat")
                .Build();

            Console.WriteLine(animal);

            var copy = animal.Prototype();
            copy.Type = "dog";

            Console.WriteLine(animal);
            Console.WriteLine(copy);

            var instance = Singleton.Instance;
            Console.WriteLine(instance.Method());
        }
    }
}