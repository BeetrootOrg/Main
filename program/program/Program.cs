using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {

        static void Main()
        {
            while (true)
            {
                MainMenu();
            }

        }
        
        static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("1.Create pool");
            Console.WriteLine("2.Show pool results");
            Console.WriteLine("3.Vote for something");
            Console.WriteLine("4.Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CreatePool();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:

                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:

                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:

                    break;
            }

        }

        static public void CreatePool()
        {
            var voteList = new Dictionary<string, int>
            {

            };

            Console.WriteLine("Enter your survey text:");
            string surveyText = Console.ReadLine();

            Console.WriteLine("Write the variant for vote or <Enter> when you finish add:");
            string newCandidate = Console.ReadLine();
            int i = 0;

            while (newCandidate != "Enter")
            {
                voteList.TryAdd(newCandidate, i);
                newCandidate = Console.ReadLine();
            }
        }

        static void VoteForSomething()
        {
            Console.WriteLine("Pls choose candidate: (For end write <Finish>)");
            ShowAll(voteList);

            string enterVote = Console.ReadLine();

            bool findCandidate = voteList.ContainsKey(enterVote);


            while (enterVote != "Finish")
            {
                if (findCandidate == true && voteList.ContainsKey(enterVote))
                {
                    voteList[enterVote]++;
                }
                else
                {
                    Console.WriteLine("You have mistake. Pls write a candidate");
                }
                enterVote = Console.ReadLine();
            }

        }

        static void ShowPoolResults()
        {
            Console.Write("Winer is: ");
            var result = voteList.Max(s => s.Key);
            //var result = voteList.Where(s => s.Value.Equals(max)).Select(s => s.Key).ToList();
            Console.WriteLine(result);
        }

        private static void Exit()
        {
            Environment.Exit(4);
        }

        static void ShowAll<T>(IEnumerable<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
        


    }

}