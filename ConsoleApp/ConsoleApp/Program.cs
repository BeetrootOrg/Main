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
        }

        static void ShowAnimal(Animal animal)
        {
            Console.WriteLine(animal.MakeNoise());
            animal.Eat();
        }
    }
}