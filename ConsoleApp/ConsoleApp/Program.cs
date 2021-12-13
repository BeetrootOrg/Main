using System;

namespace ConsoleApp
{
    class UserService
    {
        private const string _username = "USER";
        private const string _password = "PASS";

        public void SignIn(string username, string password)
        {
            var success = Login(username, password);

            if (success)
            {
                SendEmail(username);
            }
        }

        private bool Login(string username, string password)
        {
            if (username == _username && password == _password)
            {
                Console.WriteLine($"User {username} signed in");
                return true;
            } 

            Console.WriteLine("Wrong username or password used");
            return false;
        }

        private void SendEmail(string username) => Console.WriteLine($"Email sent to {username}");
    }

    class Program
    {
        static void Main()
        {
            var service = new UserService();
            service.SignIn("USER", "PASS");
            service.SignIn("U", "P");
        }
    }
}