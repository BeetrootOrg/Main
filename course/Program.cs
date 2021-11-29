using System.Text;

namespace Course
{
    class Course
    {
        const string FileName = "phonebook.csv";

        public static void Main()
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to the club buddy!\n");
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Show all phone book");
            Console.WriteLine("\t2. Create phone record");
            Console.WriteLine("\t0. EXIT");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    ShowAllNumbers();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    CreatePhoneNumber();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    CreatePhoneNumber();
                    break;
                default:
                    Environment.Exit(0);
                    break;
            }
        }

        static void CreatePhoneNumber()
        {
            Console.Clear();
            Console.WriteLine("Enter first name...");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter second name...");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter phone number...");
            var phoneNumber = Console.ReadLine();

            File.AppendAllLines(FileName, new[] {$"{firstName},{lastName},{phoneNumber}"});
        }

        static void ShowAllNumbers()
        {
            Console.Clear();

            Console.WriteLine($"{"First name",-15} {"Last name",-15} {"Phone number",-15}");
            string[] lines = File.ReadAllLines(FileName);

            foreach (string line in lines)
            {
                string[] splitted = line.Split(',');
                Console.WriteLine($"{splitted[0], -15} {splitted[1], -15} {splitted[2], -15}");
            }
        }

        static (string firstName, string lastName, string phoneNumber)[] ReadPhoneBook()
        {
            string[] lines = File.ReadAllLines(FileName);

            var phoneBook = new (string, string, string)[lines.Length - 1];
            for (int i = 1; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(',');
                phoneBook[i] = (splitted[0], splitted[1], splitted[2]);
            }

            return phoneBook;
        }
    }
}
