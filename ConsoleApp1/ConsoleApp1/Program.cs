using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Input;
using System.Threading;
using System.Threading.Tasks;

namespace Snake
{

    public static class keyThread
    {
        public static List<ConsoleKey> keyBuffer = new List<ConsoleKey>();

        public static void Trd()
        {

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (keyThread.keyBuffer.Count > 0)
                    {
                        if (keyThread.keyBuffer[keyThread.keyBuffer.Count - 1] != key)
                            keyThread.keyBuffer.Add(key);
                    }
                    else
                        keyThread.keyBuffer.Add(key);
                }

                Thread.Sleep(1);

            }

        }

        public static async void TaskAsync()
        {
            await Task.Run(() => Trd());
        }
    }



    public static class GameMenu
    {
        public class Score
        {
            public string Name;
            public string Value;
            public override string ToString()
            {
                return $"{Name};{Value}";
            }
            public Score(string n, string s)
            {
                Name = n;
                Value = s;
            }
        }
        private static List<Score> _scores = new List<Score>();


        public static void Start()
        {
            Menu();
        }

        private static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose option: \n 1.New Game. \n 2.Check chempions. \n 3.Exit.");
                var key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.D1:
                        {
                            Game.Controller();

                        }
                        break;
                    case ConsoleKey.D2:
                        {
                            Console.Clear();
                            GetScore();
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.D3:
                        {
                            return;
                        }
                        break;

                }
            }
        }
        private static void ReadScoreFile()
        {
            try
            {
                _scores.Clear();
                var file = File.ReadAllLines("scores.txt");
                foreach (string s in file)
                {
                    var line = s.Split(';');
                    if (line.Length == 2)
                    {
                        _scores.Add(new Score(line[0], line[1]));
                    }
                }
            }
            catch
            {

            }
        }
        private static void GetScore()
        {
            ReadScoreFile();
            Console.WriteLine("Scores");
            if (_scores.Count > 0)
                foreach (var s in _scores)
                {
                    Console.WriteLine(s.ToString());
                }
        }
        public static void UpdateScore(int score)
        {
            GameOver(score);
            Console.WriteLine("Input your name:");
            string name = Console.ReadLine();
            _scores.Add(new Score(name, score.ToString()));
            List<string> vs = new List<string>();
            foreach (var sc in _scores)
            {
                vs.Add(sc.ToString());
            }
            var ar = vs.ToArray();
            File.WriteAllLines("scores.txt", ar);
        }

        private static void GameOver(int score)
        {
            Console.WriteLine($"Your score is {score}");
        }
    }
    public static class Extension
    {
        public static List<Point> ToList(this Point[] points)
        {
            List<Point> toList = new List<Point>();
            for (int i = 0; i < points.Length; i++)
            {
                toList.Add(points[i]);
            }
            return toList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            keyThread.TaskAsync();
            GameMenu.Start();
        }
    }
    public enum Rotate
    {
        Up,
        Down,
        Left,
        Right
    }
    public static class Game
    {

        public readonly struct Resolution
        {
            public static int Vertical = 24;
            public static int Hoirzontal = 32;
        }
        public static void Controller()
        {
            Snake.Init();
            Matrix.Init();
            Matrix.Update();
            Matrix.Redraw();
            int count = 0;
            int rank = 52;
            int tread = 1000;
            if (tread > 200)
                tread = 20 * (rank - Snake.Points.Count);
            while (true)
            {
                bool status = true;
                if (keyThread.keyBuffer.Count > 0)
                {
                    var key = keyThread.keyBuffer[0];
                    switch (key)
                    {
                        case ConsoleKey.W:
                            status = MoveWorm(Rotate.Up);
                            break;
                        case ConsoleKey.S:
                            status = MoveWorm(Rotate.Down);
                            break;
                        case ConsoleKey.A:
                            status = MoveWorm(Rotate.Left);
                            break;
                        case ConsoleKey.D:
                            status = MoveWorm(Rotate.Right);
                            break;
                    }
                    keyThread.keyBuffer.Clear();
                }
                if (!status)
                {
                    GameMenu.UpdateScore(Snake.Points.Count);
                    break;
                }
                else
                {
                    if (!MoveWorm(Snake.Rotation)) GameMenu.UpdateScore(Snake.Points.Count);
                }
                if (count >= 4)
                {
                    AppleCreate();
                    count = 0;
                }
                else { count++; }
                Matrix.Init();
                Matrix.Update();
                Matrix.Redraw();
                System.Threading.Thread.Sleep(tread);
            }
        }

        public static bool MoveWorm(Rotate r)
        {
            bool eat = false;
            int x;
            int y;
            bool stat = Snake.Scan(r, out eat, out x, out y);
            if (stat && eat)
            {
                Snake.Turn(r);
                Snake.Rotation = r;
                return true;
            }
            else if (stat && !eat)
            {

                Snake.Turn(r);
                Snake.RemoveLast();
                Snake.Rotation = r;
                return true;
            }
            else return false;

        }

        public static List<Apple> Apples = new List<Apple>();
        public static void RemoveApple(int x, int y)
        {
            int count = 0;
            foreach (var a in Apples)
            {

                if (a.point.x == x && a.point.y == y)
                {
                    Apples.RemoveAt(count);
                    var arr = Apples.ToArray();
                    Apples.Clear();
                    for (int i = 0; i < arr.Length; i++)
                    {
                        Apples.Add(arr[i]);
                    }
                    return;
                }
                count++;
            }
        }
        public static class Snake
        {
            public static List<Point> Points = new List<Point>();
            public static Rotate Rotation = Rotate.Right;
            public static void Init()
            {
                Points.Clear();
                Points.Add(new Point(3, 2));
                Points.Add(new Point(3, 3));
            }

            public static void Turn(Rotate r)
            {
                if (r == Rotate.Up && Rotation == Rotate.Down) return;
                if (r == Rotate.Left && Rotation == Rotate.Right) return;
                if (r == Rotate.Down && Rotation == Rotate.Up) return;
                if (r == Rotate.Right && Rotation == Rotate.Left) return;
                CreatePoint(r);
            }

            internal static void CreatePoint(Rotate r)
            {
                var ar = Points.ToArray();
                int x = ar[ar.Length - 1].x;
                int y = ar[ar.Length - 1].y;
                Points = ar.ToList();
                switch (r)
                {
                    case Rotate.Up:
                        {
                            x--;
                        }
                        break;
                    case Rotate.Down:
                        {
                            x++;
                        }
                        break;
                    case Rotate.Left:
                        {
                            y--;
                        }
                        break;
                    case Rotate.Right:
                        {
                            y++;
                        }
                        break;
                }
                Points.Add(new Point(x, y));

            }


            public static void RemoveLast()
            {
                var ar = Points.ToArray();
                int x = ar[0].x;
                int y = ar[0].y;
                Points = ar.ToList();
                Points.RemoveAt(0);
                Matrix.Screen[x, y] = ".";
            }

            public static bool Scan(Rotate r, out bool eat, out int ax, out int ay)
            {
                var ar = Points.ToArray();
                int x = ar[ar.Length - 1].x;
                int y = ar[ar.Length - 1].y;
                ax = x;
                ay = y;
                Points = ar.ToList();
                try
                {
                    switch (r)
                    {
                        case Rotate.Up:
                            if (Matrix.Screen[x - 1, y] == "." || Matrix.Screen[x - 1, y] == "O")
                            {
                                if (Matrix.Screen[x - 1, y] == "O")
                                {
                                    eat = true; RemoveApple(x - 1, y);
                                }
                                else eat = false;
                                return true;
                            }
                            else
                            {
                                eat = false;
                                return false;
                            }
                            break;
                        case Rotate.Down:
                            if (Matrix.Screen[x + 1, y] == "." || Matrix.Screen[x + 1, y] == "O")
                            {
                                if (Matrix.Screen[x + 1, y] == "O")
                                {
                                    eat = true; RemoveApple(x + 1, y);
                                }
                                else eat = false;
                                return true;
                            }
                            else
                            {
                                eat = false;
                                return false;
                            }
                            break;
                        case Rotate.Left:
                            if (Matrix.Screen[x, y - 1] == "." || Matrix.Screen[x, y - 1] == "O")
                            {
                                if (Matrix.Screen[x, y - 1] == "O")
                                {
                                    eat = true; RemoveApple(x, y - 1);
                                }
                                else eat = false;
                                return true;
                            }
                            else
                            {
                                eat = false;
                                return false;
                            }
                            break;
                        case Rotate.Right:
                            if (Matrix.Screen[x, y + 1] == "." || Matrix.Screen[x, y + 1] == "O")
                            {
                                if (Matrix.Screen[x, y + 1] == "O")
                                {
                                    eat = true; RemoveApple(x, y + 1);
                                }
                                else eat = false;
                                return true;
                            }
                            else
                            {
                                eat = false;
                                return false;
                            }
                            break;
                        default:
                            {
                                eat = false;
                                return false;
                            }
                            break;
                    };
                }
                catch
                {
                    {
                        eat = false;
                        return false;
                    }
                }
            }
        }

        public static class Matrix
        {
            public static string[,] Screen = new string[Resolution.Vertical, Resolution.Hoirzontal];
            public static void Init()
            {
                for (int i = 0; i < Resolution.Vertical; i++)
                {
                    for (int j = 0; j < Resolution.Hoirzontal; j++)
                    {
                        Screen[i, j] = ".";
                    }
                }
            }

            public static void Update()
            {
                foreach (var a in Apples)
                {
                    Matrix.Screen[a.point.x, a.point.y] = "O";
                }
                foreach (var s in Snake.Points)
                {
                    Matrix.Screen[s.x, s.y] = "S";
                }
            }

            public static void Redraw()
            {
                Console.Clear();

                for (int i = 0; i < Resolution.Vertical; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < Resolution.Hoirzontal; j++)
                    {
                        sb.Append(Matrix.Screen[i, j]);
                    }
                    Console.WriteLine(sb.ToString());
                }
            }
        }
        public class Apple
        {
            public Point point;
            public Apple(int x, int y)
            {
                point = new Point(x, y);
            }

        }

        public static void AppleCreate()
        {
            bool stat = true;
            while (stat)
            {
                if (Apples.Count >= 4) break;
                var r1 = new Random();
                var r2 = new Random();
                int x = r1.Next(0, Resolution.Vertical);
                int y = r1.Next(0, Resolution.Hoirzontal);
                if (Matrix.Screen[x, y] == ".")
                {
                    Apples.Add(new Apple(x, y));
                }
            }
        }


    }
    public class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int xv, int yv)
        {
            x = xv;
            y = yv;
        }
    }

}