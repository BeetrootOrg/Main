﻿using System;

namespace ConsoleApp
{
    #region Single Responsibility

    class EmailService
    {
        public void SendEmail(string username) => Console.WriteLine($"Email sent to {username}");
    }

    class UserService
    {
        private const string _username = "USER";
        private const string _password = "PASS";

        public bool SignIn(string username, string password)
        {
            if (username == _username && password == _password)
            {
                Console.WriteLine($"User {username} signed in");
                return true;
            } 

            Console.WriteLine("Wrong username or password used");
            return false;
        }
    }

    #endregion

    #region Opend/closed

    enum AnimalType
    {
        Cat,
        Dog,
        Fish
    }

    class WrongAnimal
    {
        public AnimalType AnimalType { get; set; }

        public void MakeNoise()
        {
            Console.WriteLine($"{AnimalType} says {Noise()}");
        }

        private string Noise() => AnimalType switch
        {
            AnimalType.Cat => "meow",
            AnimalType.Dog => "ruff",
            AnimalType.Fish => "bulp",
            _ => throw new ArgumentOutOfRangeException(nameof(AnimalType)),
        };

        public void Swim()
        {
            Console.WriteLine($"{AnimalType} swim like a {SwimLike()}");
        }

        private string SwimLike() => AnimalType switch
        {
            AnimalType.Cat => throw new NotImplementedException("Cat cannot swim"),
            AnimalType.Dog => throw new NotImplementedException("Dog cannot swim"),
            AnimalType.Fish => "fish",
            _ => throw new ArgumentOutOfRangeException(nameof(AnimalType)),
        };
    }

    abstract class RightAnimal
    {
        protected abstract string AnimalType { get; }

        public void MakeNoise()
        {
            Console.WriteLine($"{AnimalType} says {Noise()}");
        }

        abstract protected string Noise();
    }

    class Cat : RightAnimal
    {
        protected override string AnimalType => "Cat";
        protected override string Noise() => "meow";
    }

    class Fish : RightAnimal
    {
        protected override string AnimalType => "Fish";
        protected override string Noise() => "bulp";


        public void Swim() => Console.WriteLine($"Fish swim like a fish");
    }

    #endregion

    #region Barbara Liskov Principle

    class WrongParent
    {
        public void Something() => Console.WriteLine("Something Parent");
    }

    class WrongChild : WrongParent
    {
        public void Something() => Console.WriteLine("Something Child");
    }

    class RightParent
    {
        public virtual void Something() => Console.WriteLine("Something Parent");
    }

    class RightChild : RightParent
    {
        public override void Something() => Console.WriteLine("Something Child");
    }

    #endregion

    class Program
    {
        static void Main()
        {
            var userService = new UserService();

            SendEmail(userService.SignIn("USER", "PASS"), "USER");
            SendEmail(userService.SignIn("U", "P"), "U");

            WrongParent wrongChild = new WrongChild();
            wrongChild.Something();

            RightParent rightChild = new RightChild();
            rightChild.Something();
        }

        static void SendEmail(bool success, string username)
        {
            if (success)
            {
                var emailService = new EmailService();
                emailService.SendEmail(username);
            }
        }
    }
}