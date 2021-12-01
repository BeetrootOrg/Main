namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class Program
    {
        //Класс з данними. Можна массив, але мені особисто просто так зручніше.
        public class Person
        {
            public string phone;
            public string name;
            public string lastName;
            public string BirthDay;
        }

        public static int indexer = 0;

        public static List<Person> People = new List<Person>();
        static void Main()
        {
            GetFile();
            Menu();
  
        }

        public static void GetFile() //Ініціалізуємо нашу "БД"
        {
            if (!File.Exists("DB.csv")) { File.Create("DB.csv").Close(); Save(); }

                string[] vs = File.ReadAllLines("DB.csv");
                
                int i = 0;
                foreach (string line in vs)
                {
                    if (i >= 1)
                    {
                        string[] p = line.Split(';');
                        People.Add(new Person { phone = p[0], name = p[1], lastName = p[2], BirthDay = p[3] });
                    }
                    i++;
                }           

        }

        public static void AddPerson(string name, string lastName,string phone , string BDay) //Додаємо новий контакт в список.
        {
            People.Add(new Person { name = name,lastName = lastName, phone = phone ,BirthDay = BDay });
        }

        public static void Save() //Зберігаємо базу
        {
            string[] phones = new string[People.Count+1];
            phones[0] = "Phone;Name;LastName;BDay";
            int i = 1;
            foreach (Person person in People)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(person.phone);
                sb.Append(";");
                sb.Append(person.name);
                sb.Append(";");
                sb.Append(person.lastName);
                sb.Append(";");
                sb.Append(person.BirthDay);
                phones[i] = sb.ToString();
                i++;
            }
            File.WriteAllLines("DB.csv", phones); 
        }

        public enum Search
        {
            Phone,
            Name,
            LastName,
            BirthDay
        }

        public static bool Find(string value,Search searchType)
        {
            indexer = 0;
            bool i = false;
            switch (searchType)
            {
                case Search.Phone:
                    {
                        foreach (Person person in People)
                        {
                            if (person.phone.ToLower() == value.ToLower())
                            {
                                Console.WriteLine($"Name {person.name} ,Last name {person.lastName} , Phone {person.phone} , B-Day {person.BirthDay}");i = true; 
                            }
                            indexer++;
                        }
                    } break;
                    case Search.Name:
                    {
                        foreach (Person person in People)
                        {
                            if (person.name.ToLower() == value.ToLower())
                            {
                                Console.WriteLine($"Name {person.name} ,Last name {person.lastName} , Phone {person.phone} , B-Day {person.BirthDay}"); i = true; 
                            }
                            indexer++;
                        }
                    }
                    break;
                    case Search.LastName:
                    {
                        foreach (Person person in People)
                        {
                            if (person.lastName.ToLower() == value.ToLower())
                            {
                                Console.WriteLine($"Name {person.name} ,Last name {person.lastName} , Phone {person.phone} , B-Day {person.BirthDay}"); i = true; break;
                            }
                            indexer++;
                        }
                    }
                    break;
            }
            if (!i) { Console.WriteLine("NOT FOUND"); Menu(); return false; }
            Menu();
            return true;
            
        }

        public static void PrintAll()
        {

                foreach (Person person in People)
                {
                    Console.WriteLine($"Name {person.name},Last name {person.lastName} , Phone {person.phone} , B-Day {person.BirthDay}");
                }
            Menu();
        }

        public static void ReadPerson()
        {
            Console.WriteLine("Input name");
            string name = Console.ReadLine();
            Console.WriteLine("Input Last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Input phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Input B-day");
            string birthDay = Console.ReadLine();
            if (Find(phone, Search.Phone)) 
            { 
                Console.WriteLine("Already Exists, press any key to continue"); 
                Console.ReadKey();
                Console.Clear();
                Menu(); 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Is correct? (y/n)");
                Console.WriteLine($"Name {name},Last name {lastName} , Phone {phone} , B-Day {birthDay}");
                var key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case ('y'):
                        {
                            AddPerson(name, lastName, phone, birthDay);
                            Save();
                            Console.Clear();
                            Menu();

                        }
                        break;
                    default:
                        Console.Clear();
                        ReadPerson();
                        break;
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Here is Phone book");
            Console.WriteLine("Please choose option");
            Console.WriteLine("1. Add new");
            Console.WriteLine("2. Find");
            Console.WriteLine("3. Show all");
            var key = Console.ReadKey();
            switch (key.KeyChar)
            {
                case ('1'):
                    {
                        Console.Clear();
                        ReadPerson();
                    }
                    break;
                case ('2'):
                    {
                        FindMenu();
                    }
                    break;
                case ('3'):
                    {
                        PrintAll();
                    }
                    break;
            }
        }

        public static void FindMenu()
        {
            Console.Clear();
            Console.WriteLine("Please choose option");
            Console.WriteLine("1. By phone");
            Console.WriteLine("2. By Name");
            Console.WriteLine("3. By Last Name");
            var s1 = Search.Phone;
            var s2 = Search.Name;
            var s3 = Search.LastName;
            var key = Console.ReadKey();
            Console.WriteLine("Input value ");
            string val = Console.ReadLine();
            switch (key.KeyChar)
            {
                case ('1'):
                    {
                        Find(val,s1);
                    }
                    break;
                case ('2'):
                    {
                        Find(val, s2);
                    }
                    break;
                case ('3'):
                    {
                        Find(val, s3);
                    }
                    break;
            }
            Menu();
        }

        public enum SortBy
        {
            LastName,
            FirstName,
            Phone
        }
        public static void Sorter()
        {
            List<Person> list = new List<Person>();
            List<Person> main = People;
            for(int i = 97; i <= 122; i++)
            {
                List<Person> people;
                Sorter((char)i, out people,SortBy.LastName);
                if (people.Count != 0)
                {
                    list.AddRange(people);
                }
            }
        }

        public static void Sorter(char c,out List<Person>people,SortBy sort)
        {
            if(sort == SortBy.LastName)
            {
                foreach (var prs in People)
                {

                }
            }

        }
    }
    }
 
