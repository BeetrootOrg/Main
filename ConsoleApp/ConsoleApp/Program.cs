using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    //ГОЛОСОВАЛКА ЗА ЧТО УГОДНО

    public class Vote
    {
        public string VoteQuestion { get; set; }
        public List<Option> VoteOptions = new List<Option>();

        public Vote(string question)
        {
            VoteQuestion = question;
        }

        public void AddVoteOption(string optionText)
        {
            VoteOptions.Add(new Option(optionText));
        }

        public void AddVoter(int choise, string name)
        {
            VoteOptions[choise].voterList.Add(name);
        }

        public void ShowVoteQuestionOption()
        {
            Console.WriteLine($"{VoteQuestion}");

            int i = 0;
            foreach (var item in VoteOptions)
            {
                Console.WriteLine($"{i}) {item.textOption}");
                ++i;
            }
        }

        public void ShowVoteResult()
        {
            Console.WriteLine(VoteQuestion);

            foreach (var item in VoteOptions)
            {
                item.ShowVotePeople();

            }
        }
    }

    public class Option
    {
        public string textOption;
        public List<string> voterList = new List<string>();

        public Option(string text)
        {
            textOption = text;
        }

        public void ShowVotePeople()
        {
            if (voterList.Count > 0)
            {
                Console.WriteLine($"{textOption}: {voterList.Count} votes");
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
                    LetsVote();
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

        static void CreateVote()
        {
            Console.Clear();

            Console.WriteLine("Write a Voting topic:");
            string question = Console.ReadLine();

            if (!string.IsNullOrEmpty(question))
            {
                votes.Add(new Vote(question));
            }
            else
            {
                Console.WriteLine("Ah Shit, Here We Go Again!");
                question = Console.ReadLine();
                votes.Add(new Vote(question));
            }

            Console.WriteLine("Lets Add some options.");

            do
            {
                var option = Console.ReadLine();

                if (!String.IsNullOrEmpty(option) || votes[votes.Count - 1].VoteOptions.Count < 2)
                {
                    votes[votes.Count - 1].AddVoteOption(option);
                }
                else
                {
                    break;
                }

            } while (true);

        }

        static void ShowQuestions()
        {
            int i = 0;
            foreach (var vote in votes)
            {
                Console.WriteLine($"{i}) {vote.VoteQuestion}");
                ++i;
            }
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


        static void LetsVote()
        {
            if (votes.Count > 0)
            {
                Console.Clear();
                ShowQuestions();
                int voteIndex = 0;

                if (votes.Count > 1)
                {
                    Console.WriteLine("What vote you whant?");
                    voteIndex = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();
                    votes[voteIndex].ShowVoteQuestionOption();
                }

                Console.WriteLine("Write your Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Write what option you choose (write a number):");
                int optionIndex = Convert.ToInt32(Console.ReadLine());

                votes[voteIndex].AddVoter(optionIndex, name);
            }
            else
            {
                Console.WriteLine("Create any Vote!!!");
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
            Console.WriteLine("To back to menu type Enter...");
            Console.ReadLine();
        }
    }
}