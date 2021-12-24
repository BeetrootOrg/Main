namespace ConsoleApp
{
    using System;
    
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/16-Vote \r\n");

            Vote vote = new Vote();
            while (true)
            {
                Menu(ref vote);
            }
        }
        static void Menu(ref Vote v)
        {            
            Console.Clear();
            Console.WriteLine("Welcome to Vote Application!\n");
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
                    EnterPoolQuestion(ref v);
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ShowPollResult(ref v);
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    VoteForSomething(ref v);
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    ShowPollResultAndExit(ref v);
                    Exit();
                    break;
            }
        }
        static void EnterPoolQuestion(ref Vote v)
        {
            Console.Clear();
            Console.WriteLine("Enter the question...\r\n");
            Console.Write("Question: ");
            string? question = Console.ReadLine();

            Console.Write("Enter the comma-separated answers...\r\n0. Answer ");
            var answer1 = Console.ReadLine();

            Console.Write("1. Answer ");
            var answer2 = Console.ReadLine();

            v.SetQuestion(question);
            v.Answer[0] = answer1;
            v.Answer[1] = answer2;
        }        
        static void ShowPollResult(ref Vote v)
        {
            Console.Clear();
            Console.WriteLine("\r\n Poll Result...\r\n");
            v.ShowQuestion();
            v.ShowVoteResult();
            Wait();
        }
        static void VoteForSomething(ref Vote v)
        {
            Console.Clear();
            Console.WriteLine("\r\n Vote for Something: \r\n");
            v.ShowQuestion();
            v.ShowVoteResult();
            if (v.Question != null)
            {
                Console.Write("\r\nYour Name: ");
                string? name = Console.ReadLine();
                Console.Write("Your answer: ");
                var answer = Console.ReadLine();
                v.AddNewVotedPerson(name, answer);
            }
            else
            {
                Wait();
            }
        }
        static void ShowPollResultAndExit(ref Vote v)
        {
            Console.Clear();
            Console.WriteLine("\r\n Poll Result and Exit...\r\n");
            v.ShowQuestion();
            v.ShowVoteResult();
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
