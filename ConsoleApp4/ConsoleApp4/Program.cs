
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace ConsoleApp
{

 
    public class Program
    {

        public class QList : List<QA>
        {
     
            public void ShowQuestion(int i)
            {
    
                if (this.ElementAt(i).Question == null)
                {
                    Console.WriteLine("No Question!");
                }

                Console.WriteLine("Question: {0}", this.ElementAt(i).Question);
            }

             public void ShowVoteResult(int i)
                {
                    Console.WriteLine("Answer 0: {0} - {1} person(s)", this.ElementAt(i).Answer1, this.ElementAt(i).Voter);
                    Console.WriteLine("Answer 1: {0} - {1} person(s)", this.ElementAt(i).Answer2, this.ElementAt(i).Voter);
                }
            public void AddVoter(int number, string voter)
            {
                this.ElementAt(number).Voter = voter;   
            }
            public void AddChoice(int number, string choice)
            {
                this.ElementAt(number).Choice = choice;
            }
        }
        public class QA
        {

            public string Question { get; set; }
            public string Answer1 { get; set; }
            public string Answer2 { get; set; }
            public string Voter { get; set; }
            public string Choice { get; set; }
            public QA(string question="", string answer1="", string answer2="", string voter = "", string choice = "")
            {
                this.Question = question;
                this.Answer1 = answer1;
                this.Answer2 = answer2;
                this.Voter = voter;
                this.Choice = choice;
            }
            public void ShowQuestion()
            {
                if (Question == null)
                {
                    Console.WriteLine("No Question!");
                    return;
                }

                Console.WriteLine("Question: {0}", Question);
            }
        }



        static void Main()
        {

      QList ql = new QList();

            ql.Add(new QA("0", "0", "0"));


            while (true)
            {
                Menu( ref ql);
            }
        }
        static void Menu( ref QList ql )
        {



            Console.Clear();
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Create poll");
            Console.WriteLine("\t2. Show poll results");
            Console.WriteLine("\t3. Vote for something");
            Console.WriteLine("\t4. Show Result and Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    EnterPoolQuestion( ref ql);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowPollResult( ref ql);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    VoteForSomething( ref ql);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowPollResultAndExit( ref ql);
                    Exit();
                    break;
            }
        }

        static void EnterPoolQuestion(ref QList ql)
        {
            Console.Clear();
            Console.WriteLine("Enter the question...\r\n");
            Console.Write("Question: ");
            string? question = Console.ReadLine();

            Console.Write("Enter the option...\r\n0. Option ");
            var answer1 = Console.ReadLine();

            Console.Write("1. Answer ");
            var answer2 = Console.ReadLine();

            QList qlx=new QList();
            
                ql.Add(new QA( question, answer1, answer2 ));
            

            ql.ElementAt(0).Answer1= answer1;
            ql.ElementAt(0).Answer2 = answer2;
            ql.ElementAt(0).Question = question;
        }
        static void ShowPollResult( ref QList ql)
        {
            Console.Clear();
            Console.WriteLine("\r\n Poll Result...\r\n");


            ql.ShowQuestion(1);
            ql.ShowVoteResult(1);
 
            Wait();
        }
        static void VoteForSomething( ref QList ql)
        {
            Console.Clear();
            Console.WriteLine("\r\n Vote for Something: \r\n");
            ql.ShowQuestion(0);
            ql.ShowVoteResult(0);

            
            if (ql.ElementAt(0).Question != null)
            {
                Console.Write("\r\nYour Name: ");
                string? name = Console.ReadLine();
                Console.Write("Your answer: ");
                var answer = Console.ReadLine();
                ql.AddVoter(0, name);
                ql.AddChoice(0, answer);
            }
            else
            {
                Wait();
            }
        }
        static void ShowPollResultAndExit( ref QList ql)
        {
            Console.Clear();
            Console.WriteLine("\r\n Poll Result and Exit...\r\n");

            ql.ShowQuestion(0);
            ql.ShowVoteResult(0);
        }
        private static void Wait()
        {
            Console.WriteLine("\r\nTo back to menu type Enter...\r\n");
            Console.ReadLine();
        }
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}