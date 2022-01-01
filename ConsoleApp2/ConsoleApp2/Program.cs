using System;

namespace Game
{
    public static class Exit
    {
        public static bool gameLive=false;
    }
    class Program
    {
        public bool gameLive = false;
        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public Point(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
            public static Point Addition(Point point1, Point point2)
            {
                Point point3 = new Point(0, 0);
                point3.X = point1.X + point2.X;
                point3.Y = point1.Y + point2.Y;
                return point3;
            }
        }

        public class Snake : List<Point>
        {
            public Point direction { get; set; }
            public Point track { get; set; }

            public Snake()
            {
                this.Add(new Point(1, 1));
                this.Add(new Point(2, 1));
                this.Add(new Point(3, 1));
                direction = new Point(1, 1);
            }
            public void move()
            {
                track = this.Last();

                this.RemoveAt(this.Count - 1);
                this.Insert(0, Point.Addition(this.ElementAt(0), direction));

                try
                {
                    Console.SetCursorPosition(track.X, track.Y);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("!!!GAME OVER!!!");
                    Exit.gameLive = false;
                }

                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.Write(' ');

                try
                {
                    Console.SetCursorPosition(this.ElementAt(0).X, this.ElementAt(0).Y);
                }
                catch (Exception)
                {
                    Console.SetCursorPosition(20, 20);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("!!!GAME OVER!!!");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('*');
            }
            public void elongation()
            {
                this.Add(track);
            }

        }


        public class Scatter : List<Point>
            {
            public Scatter(int n)
            {
                Random r = new Random();

                for (int i = 0; i < n; i++)
                {
                    int x = r.Next(1,79);  
                    int y = r.Next(1,24);
                    this.Add(new Point(x, y));
                }
            }
            }

        static void Main()
        {
            ConsoleKeyInfo prevKey = default(ConsoleKeyInfo);
            ConsoleKeyInfo consoleKey = default(ConsoleKeyInfo);
            DateTime prevtime;
            DateTime xtime = DateTime.Now;
            TimeSpan interval = new TimeSpan();


            Snake snake = new Snake();

            snake.direction = new Point(1, 1);
            Console.WriteLine("SNAKE GAME by VICTOR PROHOROV.  Press any key to continue...");
            Console.ReadKey();

            Exit.gameLive = true;

            int dx = 1, dy = 0;

            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            int delayInMillisecs = 100;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("Arrows move up/down/right/left. 't' trail.  'c' clear  'esc' quit.");
            Scatter scatter = new Scatter(60);
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < scatter.Count-1; i++)
            {
                Console.SetCursorPosition(scatter.ElementAt(i).X, scatter.ElementAt(i).Y);
                Console.Write('*');
            }

            do 
            {


                if (Console.KeyAvailable)
                {
                    prevKey = consoleKey;
                    consoleKey = Console.ReadKey(true);
                    prevtime = xtime;
                    xtime = DateTime.Now;
                    interval = xtime - prevtime;
                    int f = interval.Milliseconds;
                    switch (consoleKey.Key)
                    {
                        case ConsoleKey.UpArrow: //UP
                            if (f < 300 && prevKey.Key == ConsoleKey.RightArrow)
                            {
                                dx = 1;
                            }
                            else if (f < 300 && prevKey.Key == ConsoleKey.LeftArrow)
                            {
                                dx = -1;
                            }
                            else
                            {
                                dx = 0;
                            }
                            dy = -1;
                            break;
                        case ConsoleKey.DownArrow: // DOWN
                            if (f < 300 && prevKey.Key == ConsoleKey.RightArrow)
                            {
                                dx = 1;
                            }
                            else if (f < 300 && prevKey.Key == ConsoleKey.LeftArrow)
                            {
                                dx = -1;
                            }
                            else
                            {
                                dx = 0;
                            }
                            dy = 1;
                            break;
                        case ConsoleKey.LeftArrow: //LEFT
                            dx = -1;
                            if (f < 300 && prevKey.Key == ConsoleKey.UpArrow)
                            {
                                dy = -1;
                            }
                            else if (f < 300 && prevKey.Key == ConsoleKey.DownArrow)
                            {
                                dy = 1;
                            }
                            else
                            {
                                dy = 0;
                            }
                            break;
                        case ConsoleKey.RightArrow: //RIGHT
                            dx = 1;
                            if (f < 300 && prevKey.Key == ConsoleKey.UpArrow)
                            {
                                dy = -1;
                            }
                            else if (f < 300 && prevKey.Key == ConsoleKey.DownArrow)
                            {
                                dy = 1;
                            }
                            else
                            {
                                dy = 0;
                            }
                            break;
                        case ConsoleKey.Escape: //END
                            Exit.gameLive = false;
                            break;
                    }
                }
                snake.direction = new Point(dx, dy);
                snake.move();
                for (int i = 0; i < scatter.Count-1; i++)
                {
                    Point p = snake.ElementAt(0);  
                    Point p2 = scatter.ElementAt(i);
             //   if (Point.Equals(snake.ElementAt(0), scatter.ElementAt(i)))
                 if (snake.ElementAt(0).X==scatter.ElementAt(i).X && snake.ElementAt(0).Y == scatter.ElementAt(i).Y)
                {
                snake.elongation();
                        scatter.RemoveAt(i);
                        break;
                }
                }

                System.Threading.Thread.Sleep(delayInMillisecs);

            } while (Exit.gameLive);
        }
    }
}