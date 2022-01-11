using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    public class VoteList
    {

        Dictionary<string, int> _voteList = new Dictionary<string, int>();

        public Dictionary<string, int> Parameter
        {
            get
            {
                return _voteList;
            }
            set
            {
                _voteList = value;
            }
        }
    }

    class Program
    {
        static VoteList voteList = new VoteList();

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
                    ShowPoolResults();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    VoteForSomething();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Exit();
                    break;
            }

        }


        
        

        static void CreatePool()
        {
            Console.Clear();
            
           

            Console.WriteLine("Enter your survey text:");
            string surveyText = Console.ReadLine();

            Console.WriteLine("Write the variant for vote or <Enter> when you finish add:");
            string newCandidate = Console.ReadLine();
            int i = 0;

                        

            while (newCandidate != "Enter")
            {
                voteList.Parameter.TryAdd(newCandidate, i);
                newCandidate = Console.ReadLine();
                
            }
            
        }

        static void VoteForSomething()
        {
            Console.Clear();
            

            ShowAll(voteList.Parameter);

            Console.WriteLine("Pls choose candidate: (For end write <Finish>)");

            string enterVote = Console.ReadLine();

            bool findCandidate = voteList.Parameter.ContainsKey(enterVote);


            while (enterVote != "Finish")
            {
                if (findCandidate == true && voteList.Parameter.ContainsKey(enterVote))
                {
                    voteList.Parameter[enterVote]++;
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
            Console.Clear();
            

            ShowAll(voteList.Parameter);

            Console.Write("Winer is: ");
            var result = voteList.Parameter.Max(s => s.Key);
            
            Console.WriteLine(result);
            Console.ReadLine();
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