using System;

namespace ConsoleApp11HomeworkEncapsulation
{
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

    class Program
    {
        static void Main()
        {
            var userService = new UserService();

            SendEmail(userService.SignIn("USER", "PASS"), "USER");
            SendEmail(userService.SignIn("U", "P"), "U");
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