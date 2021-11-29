namespace Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    class Program
    {
        public class Person
        {
            public string phone;
            public string name;
            public string BirthDay;
        }

        public static List<Person> People = new List<Person>();
        static void Main()
        {
            GetFile();
            Menu();
  
        }

        public static void GetFile()
        {
            if (!File.Exists("DB.csv")) File.Create("DB.csv") ;
            else
            {

                string[] vs = File.ReadAllLines("DB.csv");
                int i = 0;
                foreach (string line in vs)
                {
                    if (i >= 1)
                    {
                        string[] p = line.Split(';');
                        People.Add(new Person { phone = p[0], name = p[1], BirthDay = p[2] });
                    }
                    i++;
                }
            }

        }

        public static void AddPerson(string name, string phone , string BDay)
        {
            People.Add(new Person { name = name, phone = phone ,BirthDay = BDay });
        }

        public static void Save()
        {
            string[] phones = new string[People.Count+1];
            phones[0] = "Name;Phone;BDay";
            int i = 1;
            foreach (Person person in People)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(person.name);
                sb.Append(";");
                sb.Append(person.phone);
                sb.Append(";");
                sb.Append(person.BirthDay);
                phones[i] = sb.ToString();
                i++;
            }
            File.WriteAllLines("DB.csv",phones); 
        }

        public static void Find(string value)
        {
            foreach (Person person in People)
            {
                if(person.phone == value)
                {
                    Console.WriteLine($"Name {person.name} , Phone {person.phone} , B-Day {person.BirthDay}");
                }
            }
        }

        public static void PrintAll()
        {

                foreach (Person person in People)
                {
                    Console.WriteLine($"Name {person.name} , Phone {person.phone} , B-Day {person.BirthDay}");
                }

        }

        public static void ReadPerson()
        {
            Console.WriteLine("Input name");
            string name = Console.ReadLine();
            Console.WriteLine("Input phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Input B-day");
            string birthDay = Console.ReadLine();
        }

        public static void Menu()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Here is Phone book");
            Console.WriteLine("Please choose option");
            Console.WriteLine("a. Add new");
            Console.WriteLine("b. Find");
            Console.WriteLine("c. Show all");
            var key = Console.ReadKey();
            switch (key)
            {
                
            }
        }
 
    }
}