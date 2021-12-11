using System;
namespace ConsoleApp
{

    class Animal
    {
        public int NumOfPaws { get; set; }
        public int Length { get; set; }
        public virtual bool HasTail { get; set; }
        public string Color { get; set; }

        public virtual string MakeNoise() => "Unknown animal says ???";
        public void Eat() => Console.WriteLine("Unknown animal eats ???");

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        protected virtual bool Equals(Animal animal)
        {
            if (animal == null)
            {
                return false;
            }
            if (ReferenceEquals(this, animal))
            {
                return true;
            }
            if (this.GetType() != animal.GetType())
            {
                return false;
            }

            return NumOfPaws == animal.NumOfPaws && Length == animal.Length && HasTail == animal.HasTail && Color == animal.Color;
        }



        public override int GetHashCode() => NumOfPaws.GetHashCode() ^ Length.GetHashCode() ^ HasTail.GetHashCode() ^ Color.GetHashCode();

        public override string ToString() => $"{nameof(NumOfPaws)}={NumOfPaws}";
    }

    class Cat : Animal
    {
        public string Breed { get; set; }

        public override string MakeNoise() => "Cat says 'meow'";
        public new void Eat() => Console.WriteLine("cat eats fish");
    }
    class Program
    {
        static void Main()
        {
            var animal = new Animal
            {
                Color = "red",
                HasTail = true,
                NumOfPaws = 5,
                Length = -1
            };
            var cat = new Cat
            {
                Color = "black",
                HasTail = true,
                NumOfPaws = 4,
                Length = 30
            };

            Console.WriteLine(cat);

            static void ShowAnimal(Animal animal)
            {
                Console.WriteLine(animal.MakeNoise());
                animal.Eat();

            }

        }

    }
}