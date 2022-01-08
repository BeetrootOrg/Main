using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    //Голосовалка

    public class Vote
    {
        public string Question { get; set; }
        public List<Option> Options = new List<Option>();

        public Vote(string question)
        {
            Question = question;
        }

        public void AddOption(string optionText)
        {
            Options.Add(new Option(optionText));
        }

        public void ToVote(int choise, string name)
        {
            Options[choise].voterList.Add(name);
        }

        public void ShowAll()
        {
            Console.WriteLine(Question);

            foreach (var item in Options)
            {
                Console.WriteLine($"{item.Text}");
                item.ShowVoters();
                
            }
        }
    }

    public class Option
    {
        public string Text;
        public List<string> voterList = new List<string>();

        public Option(string text)
        {
            Text = text;
        }

        public void ShowVoters()
        {
            if (voterList.Count > 0)
            {
                foreach (var item in voterList)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Nobody vote for this yet");
            }
        }
    }



    public class Program
    {
        static List<Vote> votes = new List<Vote>();

        static void Main()
        {
            while (true)
            {
                Menu();
            }
        }


        static void Menu()
        {
            Console.Clear();
            Console.WriteLine(" Welkome to vote Aplication!\n Lets try to create some Vote\n");

            Console.WriteLine("\t1. Create Vote");
            Console.WriteLine("\t2. Show All Vote");
            Console.WriteLine("\t0. Exit");
            

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CreateVote();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowAllVotes();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;
            }
        }

        static void CreateVote()
        {
            Console.Clear();

            Console.WriteLine("Write a Voting topic:");
            votes.Add(new Vote(Console.ReadLine()));

            Console.WriteLine("Lets Add some options!");
            do
            {
                votes[votes.Count - 1].AddOption(Console.ReadLine());
            } while (!String.IsNullOrEmpty(Console.ReadLine()));

        }

        static void ShowAllVotes()
        {
            Console.Clear();
            foreach (var vote in votes)
            {
                vote.ShowAll();
            }

            Wait();
        }

        private static void Wait()
        {
            Console.WriteLine("To back to menu type Enter...");
            Console.ReadLine();
        }
    }
}