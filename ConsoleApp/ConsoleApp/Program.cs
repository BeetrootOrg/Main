using System;
using System.Text;
namespace ConsoleApp
{
    class Program
    {
        //i.safontev/classwork/12-inheritance

        class Animal
        {
            public int NumOfPaws { get; set; }
            public double Length { get; set; }
            public virtual bool HasTail { get; set; }
            public string Color { get; set; }

            virtual public string MakeNoise() => "Unknown Animal says '???'";

            public virtual string GetAnimalType() => "this is ?";
            public void Eat() => Console.WriteLine("Unknown Animal eats '???'");

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

                return (NumOfPaws == animal.NumOfPaws && Length == animal.Length && Color == animal.Color);
            }

            public override int GetHashCode() => NumOfPaws.GetHashCode() ^
                Length.GetHashCode() ^
                HasTail.GetHashCode() ^
                Color.GetHashCode();

            public override string ToString() => $"{nameof(NumOfPaws)} = {NumOfPaws}; " +
               $" {nameof(Length)} = {Length}" +
               $" {nameof(HasTail)} = {HasTail}" +
               $" {nameof(Color)} = {Color}";

        }

        class Cat : Animal
        {
            public string Breed { get; set; }
            public override bool HasTail { get => true; set => throw new NotImplementedException("Cannot change tail"); }

            override public string MakeNoise() => "Cat says 'meow'";
            public override string GetAnimalType() => $"this is a cat {Breed}";

            public new void Eat() => Console.WriteLine("Car eats 'fish'");

        }

        class Dog : Animal
        {
            public override string GetAnimalType() => "this is a dog";
        }

        static void Main(string[] args)
        {
            var animal = new Animal
            {
                Color = "red",
                HasTale = true,
                NumOfPaws = 9,
                Length = -1,
            };

            var cat = new Cat
            {
                Color = "Black",
                NumOfPaws = 4,
                Length = 30,
                Breed="Britanec",
            };

            Console.WriteLine($"{animal.MakeNoise()}");
            Console.WriteLine($"{cat.MakeNoise()}");

            ShowAnimal(animal);
            ShowAnimal(cat);

            Console.WriteLine(animal);
            Console.WriteLine(cat);

            var animal2 = new Animal
            {
                Color = "red",
                NumOfPaws = 5,
                Length = -1
            };

            Console.WriteLine(animal == animal2);
            Console.WriteLine(animal.Equals(animal2));
            Console.WriteLine(animal.Equals(new object()));
            Console.WriteLine(animal.GetHashCode());
            Console.WriteLine(animal2.GetHashCode());

            Console.WriteLine(GetAnimalType1(cat));
            Console.WriteLine(GetAnimalType1(new Dog()));

            Console.WriteLine(GetAnimalType2(cat));
            Console.WriteLine(GetAnimalType2(new Dog()));

            Console.WriteLine(GetAnimalType3(animal));
            Console.WriteLine(GetAnimalType3(cat));
            Console.WriteLine(GetAnimalType3(new Dog()));


        }

        static void ShowAnimal(Animal animal)
        {
            Console.WriteLine(animal.MakeNoise());
            animal.Eat();
        }

        //worse approach
        static string GetAnimalType1(Animal animal)
        {
            if(animal is Cat cat)
            {
                return $"this is a cat {cat.Breed}";
            }
            if (animal is Dog dog)
            {
                return $"this is a dog";
            }

            return "?";
        }

        //2nd variant better approach - dynamic polimorphism
        static string GetAnimalType2(Animal animal) => animal.GetAnimalType();

        //good approach as 2nd varuant- 3rd variant - static polimorphism
        //overload 
        static string GetAnimalType3(Animal animal) => $"?";
        static string GetAnimalType3(Cat cat) => $"this is a cat {cat.Breed}";
        static string GetAnimalType3(Dog dog) => $"this is a dog";
    }
}
