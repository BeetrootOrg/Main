namespace ConsoleApp
{
    using System;
    
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\r\n a.tkachenko/homework/17-SnakeGame \r\n");

            SnakeGame snakeGame = new SnakeGame(50, 22);

            TimerCallback timeCB = new TimerCallback(snakeGame.SnackFielProcessd);
            using Timer time = new Timer(timeCB, null, 2000, 70);

            TimerCallback timeDirectionCB = new TimerCallback(snakeGame.SetNewDirection);
            using Timer timeDirection = new Timer(timeDirectionCB, null, 2150, 700);

            while (true)
            {
                ConsoleKeyInfo ck = Console.ReadKey();
                if ((ck.Key == ConsoleKey.D4) || (ck.Key == ConsoleKey.NumPad4))
                {
                    Exit();
                }
            }
        }        
        private static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
