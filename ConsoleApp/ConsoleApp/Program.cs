using System;
using System.Collections.Generic;

namespace ConsoleApp
{

    public class Vote
    {
        public string question { get; set; }
        public List<Option> options = new List<Option>();

        public Vote(string question)
        {
            this.question = question;
        }

        public void AddVoteOption(string optionText)
        {
            options.Add(new Option(optionText));
        }

        public void AddVoter(int choise, string name)
        {
            options[choise].voterList.Add(name);
        }

        public void ShowVoteQuestionOption()
        {
            Console.WriteLine($"{question}");

            int i = 0;
            foreach (var item in options)
            {
                Console.WriteLine($"{i}) {item.TextOption}");
                ++i;
            }
        }

        public void ShowVoteResult()
        {
            Console.WriteLine(question);

            foreach (var item in options)
            {
                item.ShowVotePeople();

            }
        }
    }

    public class Option
    {
        public string TextOption;
        public List<string> voterList = new List<string>();

        public Option(string text)
        {
            TextOption = text;
        }

        public void ShowVotePeople()
        {
            if (voterList.Count > 0)
            {
                Console.WriteLine($"{TextOption}: {voterList.Count} votes");
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
            Console.WriteLine(" Welcome!For start choose action!");

            Console.WriteLine("\t1. Create Vote");
            Console.WriteLine("\t2. Show All Votes");
            Console.WriteLine("\t3. Lets Vote");
            Console.WriteLine("\t4. Show Results");
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
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    DoVote();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowResults();
                    break;

                case ConsoleKey.D0:
                case ConsoleKey.NumPad0:
                    Environment.Exit(0);
                    break;
            }
        }


        static void ShowQuestions()
        {
            int i = 0;
            foreach (var vote in votes)
            {
                Console.WriteLine($"{i}) {vote.question}");
                ++i;
            }
        }
        static void CreateVote()
        {
            Console.Clear();

            Console.WriteLine("Write a voting name:");
            string question = Console.ReadLine();

            if (!string.IsNullOrEmpty(question))
            {
                votes.Add(new Vote(question));
            }
            else
            {
                Console.WriteLine("Again pls!");
                question = Console.ReadLine();
                votes.Add(new Vote(question));
            }

            Console.WriteLine("Lets Add some options.");

            do
            {
                var option = Console.ReadLine();

                if (!String.IsNullOrEmpty(option) || votes[votes.Count - 1].options.Count < 2)
                {
                    votes[votes.Count - 1].AddVoteOption(option);
                }
                else
                {
                    break;
                }

            } while (true);

        }
        static void ShowAllVotes()
        {
            Console.Clear();
            foreach (var vote in votes)
            {
                vote.ShowVoteQuestionOption();
            }

            Wait();
        }

        static void DoVote()
        {
            if (votes.Count > 0)
            {
                Console.Clear();
                ShowQuestions();
                int index = 0;

                if (votes.Count > 1)
                {
                    Console.WriteLine("What vote you whant?");
                    index = Convert.ToInt32(Console.ReadLine());
                }

                Console.Clear();
                votes[index].ShowVoteQuestionOption();

                Console.WriteLine("Write your Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Write what option you choose : ");
                int optionIndex = Convert.ToInt32(Console.ReadLine());

                votes[index].AddVoter(optionIndex, name);
            }
            else
            {
                Console.WriteLine("Create one more vote pls");
            }
        }

        static void ShowResults()
        {
            Console.Clear();

            foreach (var vote in votes)
            {
                vote.ShowVoteResult();
                Console.WriteLine();
            }

            Wait();
        }

        static void Wait()
        {
            Console.WriteLine("Type Enter if u want back...");
            Console.ReadLine();
        }
    }
}