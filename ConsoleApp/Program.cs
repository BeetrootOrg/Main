namespace ConsoleApp
{
    using System;
    
    class ConsoleApp
    {
        static void PrintTime(object state)
        {
            Console.Clear();
            Console.WriteLine("Time:  " + DateTime.Now.ToLongTimeString());
        }
        static void Main(string[] args)
        {
            /*Console.WriteLine("\r\n a.tkachenko/homework/16-Vote \r\n");

            Vote vote = new Vote();
            while (true)
            {
                Menu(ref vote);
            }*/

            Console.WriteLine("\r\n a.tkachenko/homework/17-SnakeGame \r\n");

            SnakeGame snakeGame = new SnakeGame(50, 22);

            TimerCallback timeCB = new TimerCallback(snakeGame.SnackField);
            using Timer time = new Timer(timeCB, null, 2000, 50);

            TimerCallback timeDirectionCB = new TimerCallback(snakeGame.SetNewDirection);
            using Timer timeDirection = new Timer(timeDirectionCB, null, 2150, 300);

            while (true)
            {
                ConsoleKeyInfo ck = Console.ReadKey();
                if ((ck.Key == ConsoleKey.D4) || (ck.Key == ConsoleKey.NumPad4))
                {
                    Exit();
                }
                // snakeGame.SetDirection(ck);
            }

        }
        public static void Count(object obj)
        {
            //int x = (int)obj;
            //for (int i = 1; i < 9; i++, x++)
            //{
            //    Console.WriteLine($"{x * i}");
            //}
            Console.WriteLine("Message");
        }
        private static void DoWorkEvery5Seconds(TimerCallback callback)
        {
            //Timer timer;
            //try
            //{
            //    timer = new Timer(callback, null, 0, 1000);
            //    Thread.Sleep(TimeSpan.FromSeconds(5));
            //    Console.WriteLine("FINISHED");
            //}
            //finally
            //{
            //    timer?.Dispose();
            //}

            // the same as above
            using var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("FINISHED");
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
