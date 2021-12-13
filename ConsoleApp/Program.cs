﻿using System;

namespace ConsoleApp
{
    abstract class Animal
    {
        public int NumOfPaws { get; set; }
        public int Length { get; set; }
        public virtual bool HasTale { get; set; }
        public string Color { get; set; }

        public abstract string MakeNoise();
        public abstract void Eat();
        public abstract string GetAnimalType();

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

        protected override bool Equals(Animal animal) => base.Equals(animal) && animal is Cat cat && Equals(cat);
        protected virtual bool Equals(Cat cat) => Breed == cat.Breed;

        public override string MakeNoise() => "Cat says 'meow'";
        public override void Eat() => Console.WriteLine("Cat eats fish");
        public override string GetAnimalType() => $"this is a cat {Breed}";
    }

    class Dog : Animal
    {
        public override void Eat() => Console.WriteLine("Dog eats beef");
        public override string GetAnimalType() => "this is a dog";
        public override string MakeNoise() => "ruff";
    }

    abstract class WeightAnimal : Animal
    {
        public int Weight { get; set; }

        public override string GetAnimalType() => "Weight animal";
    }

    class Program
    {
        static void Main()
        {
            var cat = new Cat
            {
                Color = "black",
                Length = 30,
                NumOfPaws = 4,
                Breed = "breed1"
            };

            var dog = new Dog
            {
                Color = "white",
                Length = 35,
                NumOfPaws = 4
            };

            var cat1 = new Cat
            {
                Color = "black",
                Length = 30,
                NumOfPaws = 4,
                Breed = "breed2"
            };

            cat.Equals(cat1);

            Console.WriteLine("CAT");
            ShowAnimal(cat);

            Console.WriteLine(cat.HasTale);
            Console.WriteLine(cat);
            Console.WriteLine(cat.Equals(dog));

            Console.WriteLine(GetAnimalType1(cat));
            Console.WriteLine(GetAnimalType1(new Dog()));

            Console.WriteLine(GetAnimalType2(cat));
            Console.WriteLine(GetAnimalType2(new Dog()));

            Console.WriteLine(GetAnimalType3(cat));
            Console.WriteLine(GetAnimalType3(new Dog()));
        }

        static void ShowAnimal(Animal animal)
        {
            Console.WriteLine(animal.MakeNoise());
            animal.Eat();
        }

        // worse approach
        static string GetAnimalType1(Animal animal)
        {
            if (animal is Cat cat)
            {
                return $"this is a cat {cat.Breed}";
            }

            if (animal is Dog)
            {
                return $"this is a dog";
            }

            return "?";
        }

        // better approach - dynamic polimorphism
        static string GetAnimalType2(Animal animal) => animal.GetAnimalType();

        // better approach - static polimorphism
        // overload
        static string GetAnimalType3(Animal animal) => "?";
        static string GetAnimalType3(Cat cat) => $"this is a cat {cat.Breed}";
        static string GetAnimalType3(Dog dog) => $"this is a dog";
    }
}