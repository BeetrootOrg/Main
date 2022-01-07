using System;

namespace ConsoleApp
{
    
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
        public string GetAnswer()=> _answer;
    }
    class Poll
    {
        private string _question { get; set; }
        public List<Answer> Answers { get; set; }
        public Poll(string question)
        {
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
        public static List<Poll> polls = new();

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
                    ShowResultAndVote();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    ShowResultAndVote(true);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Exit();
                    break;
            }
        }

        private static void Wait()
        {
            Console.WriteLine("To back to menu type Enter.");
            Console.ReadLine();
        }
        private static void Exit()
        {
            Environment.Exit(0);
        }

        
        static void Main()
        {

//          TestPoll();
            while (true)
            Menu(); 

        }
 /*       static void TestPoll()
        {
            var poll = new Poll("123");
            string [] answersArr = new string[] { "da", "net" };
            foreach (var item in answersArr)
            {
                poll.AddAnswers(new Answer(item));
            }
            polls.Add(poll);
        }
*/
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
        //   Console.WriteLine("All good");
        }
        public static void ShowResultAndVote(bool Vote=false)
        {

            Console.Clear();
            Console.WriteLine("Here are your polls\n");
            ShowAllQuestion(polls);
            if (!Vote)
            {
                Console.WriteLine("PLease press any number to see results of voting\n");
                string userRequest = Console.ReadLine();
                int voteRequest;
                if (!int.TryParse(userRequest, out voteRequest))
                    throw new ArgumentException("sorry, not a number");

                ShowAllQuestion(polls, true,true);
            }
            else
            {
                Console.WriteLine("Please enter number of poll for voting");
                string userRequest = Console.ReadLine();
                int voteRequest;

                if (!int.TryParse(userRequest, out voteRequest))
                    throw new ArgumentException("sorry, not a number");

                if (voteRequest > polls.Count)
                    throw new ArgumentException("sorry, no such poll");
                
                Console.WriteLine($"Question: {polls[voteRequest-1].GetQuestion()}");

                ShowAllAnswers(polls[voteRequest - 1].Answers,false);

                Console.WriteLine("Please enter number of answer for voting");
                userRequest = Console.ReadLine();
                int voteNumber;
                if (!int.TryParse(userRequest, out voteNumber)|| (voteNumber > polls[voteRequest-1].Answers.Count))
                    throw new ArgumentException("sorry, not correct input number of answer");

                polls[voteRequest - 1].Answers[voteNumber-1].Vote();

                Console.WriteLine("Thank's for you Vote!");

            }

            Wait();
        }

        static void ShowAllQuestion(List<Poll> collection, bool showAnswer = false, bool showVotes=false)
        {
            var i   = 0;
            foreach (var item in collection)
            {
                ++i;
                Console.WriteLine($"Poll number {i}: {item.GetQuestion()}");
                if (showAnswer)
                { 
                    ShowAllAnswers(item.Answers, showVotes); 
                }
            }
        }
        static void ShowAllAnswers(List<Answer> collection, bool showVotes)
        {
            var i = 0;
            foreach (var item in collection)
            {
                ++i;
                if (showVotes)
                {
                    Console.WriteLine($"{i} Answer: {item.GetAnswer()} has: {item.GetVotes()} votes");
                } 
                else
                {
                    Console.WriteLine($"{i} Answer: {item.GetAnswer()}");
                }

            }


        }



    }
}