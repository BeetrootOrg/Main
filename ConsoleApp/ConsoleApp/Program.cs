using System;

namespace ConsoleApp
{
    class Animal
    {
        public int NumOfPaws { get; set; }
        public int Length { get; set; }
        public virtual bool HasTale { get; set; }
        public string Color { get; set; }

        public virtual string MakeNoise() => "Unknown Animal says ???";
        public void Eat() => Console.WriteLine("Unknwon Animal eats ???");

        public override bool Equals(object obj) => Equals(obj as Animal);

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

            return NumOfPaws == animal.NumOfPaws &&
                Length == animal.Length &&
                HasTale == animal.HasTale &&
                Color == animal.Color;
        }

        public override int GetHashCode() => NumOfPaws.GetHashCode() ^ 
            Length.GetHashCode() ^ 
            HasTale.GetHashCode() ^ 
            Color.GetHashCode();

        public override string ToString() => $"{nameof(NumOfPaws)} = {NumOfPaws}; " +
            $"{nameof(Length)} = {Length}; " +
            $"{nameof(HasTale)} = {HasTale}; " +
            $"{nameof(Color)} = {Color}";
    }

    class Cat : Animal
    {
        public string Breed { get; set; }
        public override bool HasTale { get => true; set => throw new NotImplementedException("Cannot change tale"); }

        public override string MakeNoise() => "Cat says 'meow'";
        public new void Eat() => Console.WriteLine("Cat eats fish");
    }

    class Program
    {
        static void Main()
        {
            var animal = new Animal
            {
                Color = "red",
                HasTale = true,
                NumOfPaws = 5,
                Length = -1
            };

            var cat = new Cat
            {
                Color = "black",
                Length = 30,
                NumOfPaws = 4
            };

            Console.WriteLine("ANIMAL");
            ShowAnimal(animal);

            Console.WriteLine("CAT");
            ShowAnimal(cat);

            Console.WriteLine(cat.HasTale);

            Console.WriteLine(animal);
            Console.WriteLine(cat);

            var animal2 = new Animal
            {
                Color = "red",
                HasTale = true,
                NumOfPaws = 5,
                Length = -1
            };

            Console.WriteLine(animal == animal2);
            Console.WriteLine(animal.Equals(animal2));
            Console.WriteLine(animal.Equals(new object()));
        }

        static void ShowAnimal(Animal animal)
        {
            Console.WriteLine(animal.MakeNoise());
            animal.Eat();
        }
    }
}