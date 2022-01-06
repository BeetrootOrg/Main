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
    class Poll
    {

        private int _id;
        private string _question { get; set; }
        public List<Answer> Answers { get; set; }
        public int ID
        {
            get => _id;
            init => ++_id;
        }

        public Poll(string question)
        {
            _id = ID;
            Answers=new List<Answer>();
            _question = question;
        }
        public void AddAnswers(Answer answer)
        {
            Answers.Add(answer);
        }
        public string GetQuestion()=> _question;


    }


    class Program
    {

        static void Menu()
        {
  
            Console.Clear();
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
                   // TryToVote();
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

        public static List<Poll> polls = new();
        static void Main()
        {
            

            while (true)
            Menu(); 

        }

        static void CreatePoll()
        {

            Console.Clear();
            Console.WriteLine("Please enter your question");
            var newQestion= Console.ReadLine();
            Console.WriteLine("Please enter your answers separated with comas");
            var newAnswers=Console.ReadLine();
              var answersArr = newAnswers.Split(',');
            var poll = new Poll(newQestion);
            foreach (var item in answersArr)
            {
                poll.AddAnswers(new Answer(item));
            }
            
            polls.Add(poll);
            Console.WriteLine("All good");
        }
        static void ShowPollResults()
        {

            Console.Clear();
            Console.WriteLine("Here are your polls\n");
            ShowAll(polls);

            Console.WriteLine("Please enter your answers separated with comas");
            var newAnswers = Console.ReadLine();
            var answersArr = newAnswers.Split(',');
            var poll = new Poll(newQestion);
            foreach (var item in answersArr)
            {
                poll.AddAnswers(new Answer(item));
            }
            Console.WriteLine("All good");

        }




        static void ShowAll(List<Poll> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }


    }
}