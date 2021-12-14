using System;

namespace ConsoleApp
{
    #region SingleResponibility
    class UserService
    {
        private const string _username = "USER";
        private const string _password = "PASSWORD";

        public void SignIn(string username, string password)
        {
            var success = Login(username, password);


        }

        public bool Login(string username, string password)
        {
            if(username == _username && password == _password)
            {
                Console.WriteLine($"User {username} signed in");
                return true;
            }
            else
            {
                Console.WriteLine("Wrong user name or password");
                return false;
            }
        }

        public void SendEmail(string username) => Console.WriteLine($"Send email to {username}");
    }
    #endregion

    #region Open/Closed

    enum AnimalType
    {
        Cat, 
        Dog,
        Fish
    }

    class Animal
    {
        public AnimalType AnimalType { get; set; }

        public void MakeNoise()
        {
            Console.WriteLine();

        }

        private string Noise() => AnimalType switch
        {
            AnimalType.Cat => "Meow",
            AnimalType.Dog => "ruff",
            AnimalType.Fish => "bulp",
            _ => throw new ArgumentOutOfRangeException(nameof(AnimalType)),
        };
    }
    #endregion


    public class Program
    {
        static void Main()
        {
            var service = new UserService();
            service.Login("USER", "PASS");
            service.Login("U", "P");
        }
    }
}