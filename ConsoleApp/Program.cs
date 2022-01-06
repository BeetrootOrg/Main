using System;

namespace ConsoleApp
{
    /*Create generic Stack<T>(what it is) class with next methods:

Push(obj) - adds obj at the top of stack
Pop() - returns top element of stack & removes it
Clear() - clear stack
Count - property return number of elements
Peek() - returns top element but doesn’t remove it
CopyTo(arr) - copies stack to array
    */

    class Answer
    {
        private string _answer { get; set; }
        private int _count { get; set; }

        public Answer(string answer)
        { 
            _answer = answer;
            _count = 0;
        }

        public void Vote() => ++_count;

        public int GetVotes() => _count;

    }
    class Vote
    {
        private int _id;
        private string _question { get; set; }
        public List<Answer> Answers { get; set; }
        public int ID
        {
            get => ID;
            init => ++_id;
        }
        public string Question()=> _question;

    }


    class Program
    {

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Phone Book Application!\n");
            Console.WriteLine("\tMenu");
            Console.WriteLine("\t1. Create poll");
            Console.WriteLine("\t2. Show poll results");
            Console.WriteLine("\t3. Try to vote");
            Console.WriteLine("\t4. Exit");

            ConsoleKeyInfo ck = Console.ReadKey();

            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    CreatePoll();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowPollResults();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    TryToVote();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Exit();
                    break;
            }
        }
        private static void Exit()
        {
            Environment.Exit(0);
        }
        static void Main()
        {

        }


        static void ShowArray<TElement>(TElement[] array)
        {
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }


    }
}