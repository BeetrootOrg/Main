namespace Homework
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Formats;
    using System.Text.RegularExpressions;
    using System.Windows.Input;


    public class Program
    {

        public static void Main()
        {
            Game game = new Game();
            game.matrix.OnUpdate(ref game);
            game.GameController.Move(ref game);

        }

    }

    public static class Extension
    {
        public static Game.Snake Grow(this Game.Snake snake)
        {
            var snN = snake;
            switch (snN.turn)
            {
                case 0: snN.head.x--; break;
                case 1: snN.head.y++; break;
                case 2: snN.head.x++; break;
                case 3: snN.head.y--; break;
            }
            return snN;
        }
    }

    public class Game
    {
        public Game()
        {
            matrix = new Game.Matrix();
            snake = new Game.Snake();
            GameController = new Game.Controller();
        }
        public Matrix matrix;
        public Snake snake;
        public Controller GameController;
        public List<Apple> Apples = new List<Apple>();
        public class Matrix
        {
            public Matrix()
            {
                for (int i = 0; i < 24; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < 32; j++)
                    {
                        matrix[i, j] = ".";
                    }
                }
            }
            public string[,] matrix = new string[24, 32];
            public void OnUpdate(ref Game game)
            {
                game.matrix = new Matrix();
                game.DrawSnake(ref game);
                game.DrawApple(ref game);
                Console.Clear();
                for (int i = 0; i < 24; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    for (int j = 0; j < 32; j++)
                    {
                        sb.Append(game.matrix.matrix[i, j]);
                    }
                    Console.WriteLine(sb.ToString());
                }
            }


        }

        private void DrawApple(ref Game game)
        {
            if (Apples.Count > 0)
                foreach (Apple apple in Apples)
                {
                    game.matrix.matrix[apple.x, apple.y] = "A";
                }
        }

        public class Apple
        {
            public int x;
            public int y;
        }
        public void DrawSnake(ref Game game)
        {
            var point = snake.tail;
            if (snake.waypoints.Count > 0)
            {
                foreach (var sn in snake.waypoints)
                {
                    if (point.x != sn.x)
                    {
                        if (point.x < sn.x)
                        {
                            int v = sn.x - point.x;
                            for (int i = 0; i < v; i++)
                            {
                                game.matrix.matrix[point.x + i, point.y] = "S";
                            }
                        }
                        if (point.x > sn.x)
                        {
                            int v = point.x - sn.x;
                            for (int i = v; i > 0; i--)
                            {
                                game.matrix.matrix[point.x - i, point.y] = "S";
                            }
                        }
                    }
                    if (point.y != sn.y)
                    {
                        if (point.y < sn.y)
                        {
                            int v = sn.y - point.y;
                            for (int i = 0; i < v; i++)
                            {
                                game.matrix.matrix[point.x, point.y + i] = "S";
                            }
                        }
                        if (point.y > sn.y)
                        {
                            int v = point.y - sn.y;
                            for (int i = v; i > 0; i--)
                            {
                                game.matrix.matrix[point.x, point.y - i] = "S";
                            }
                        }
                    }
                    point = sn;
                }
            }
            var snt = snake.head;
            if (point.x != snt.x)
            {
                if (point.x < snt.x)
                {
                    int v = snt.x - point.x;
                    for (int i = 0; i < v; i++)
                    {
                        game.matrix.matrix[point.x + i, point.y] = "S";
                    }
                }
                if (point.x > snt.x)
                {
                    int v = point.x - snt.x;
                    for (int i = v; i > 0; i--)
                    {
                        game.matrix.matrix[point.x - i, point.y] = "S";
                    }
                }
            }
            if (point.y != snt.y)
            {
                if (point.y < snt.y)
                {
                    int v = snt.y - point.y;
                    for (int i = 0; i < v; i++)
                    {
                        game.matrix.matrix[point.x, point.y + i] = "S";
                    }
                }
                if (point.y > snt.y)
                {
                    int v = point.y - snt.y;
                    for (int i = v; i > 0; i--)
                    {
                        game.matrix.matrix[point.x, point.y - i] = "S";
                    }
                }
            }
            if(point.x == snt.x && point.y == snt.y&& game.snake.waypoints.Count>0)
            {
                game.snake.waypoints.RemoveAt(game.snake.waypoints.Count - 1);
            }

        }

        public class Snake
        {
            public Snake()
            {
                head = new Waypoint() { x = 6, y = 3 };
                tail = new Waypoint() { x = 3, y = 0 };
                turn = 2;
                length = 3;
                waypoints = new List<Waypoint>() { new Waypoint { x=3,y=3} };
            }
            public Waypoint head;
            public Waypoint tail;
            public int turn;
            public List<Waypoint> waypoints;
            public int length;
            public bool MoveScanner(int way, Matrix matrix, out bool eat)
            {
                if (way == 0)
                {
                    try
                    {
                        if (matrix.matrix[head.x - 1, head.y] != "S")
                        {

                            eat = false;
                            return true;
                        }
                        else if (matrix.matrix[head.x - 1, head.y] != "A") { eat = true; return true; }
                        else { eat = false; return false; };
                    }
                    catch
                    {
                        { eat = false; return false; };
                    }

                }
                else if (way == 1)
                {
                    try
                    {
                        if (matrix.matrix[head.x, head.y + 1] != "S")
                        {

                            eat = false;
                            return true;
                        }
                        else if (matrix.matrix[head.x, head.y + 1] != "A") { eat = true; return true; }
                        else { eat = false; return false; };
                    }
                    catch
                    {
                        { eat = false; return false; };
                    }

                }
                else if (way == 2)
                {
                    try
                    {
                        if (matrix.matrix[head.x + 1, head.y] != "S")
                        {

                            eat = false;
                            return true;
                        }
                        else if (matrix.matrix[head.x + 1, head.y] != "A") { eat = true; return true; }
                        else { eat = false; return false; };
                    }
                    catch
                    {
                        { eat = false; return false; };
                    }

                }
                else if (way == 3)
                {
                    try
                    {
                        if (matrix.matrix[head.x, head.y - 1] != "S")
                        {
                            eat = false;
                            return true;
                        }
                        else if (matrix.matrix[head.x, head.y - 1] != "A") { eat = true; return true; }
                        else { eat = false; return false; };
                    }
                    catch
                    {
                        { eat = false; return false; };
                    }

                }
                else { eat = false; return false; };
            }


        }


        public class Waypoint
        {
            public int x;
            public int y;
        }

        public class Controller
        {

            public void Move(ref Game game)
            {

                bool stat = true;
                while (stat)
                {

                    game.matrix.OnUpdate(ref game);
                    bool eat = false;
                    if (game.snake.MoveScanner(game.snake.turn, game.matrix, out eat))
                    {
                        game.snake = game.snake.Grow();
                        if (!eat)
                        {
                            var tx = game.snake.tail;
                            Waypoint lpx;
                            if (game.snake.waypoints.Count > 0) lpx = game.snake.waypoints[game.snake.waypoints.Count - 1];
                            else lpx = game.snake.head;
                            if (tx.x != lpx.x)
                            {
                                if (tx.x < lpx.x) tx.x++;
                                else tx.x--;
                            }
                            if (tx.y != lpx.y)
                            {
                                if (tx.y < lpx.y) tx.y++;
                                else tx.y--;
                            }
                        }
                    }
                    if (Console.KeyAvailable == true)
                    {
                        var key = Console.ReadKey(true).Key;
                        switch (key)
                        {
                            case (ConsoleKey.W):
                                {
                                    game.snake.turn = 0;
                                    Waypoint v = game.snake.head;
                                    game.snake.waypoints.Add(v);
                                }
                                break;
                            case (ConsoleKey.S):
                                {
                                    game.snake.turn = 2;
                                    Waypoint v = game.snake.head;
                                    game.snake.waypoints.Add(v);
                                }
                                break;
                            case (ConsoleKey.A):
                                {
                                    game.snake.turn = 3;
                                    Waypoint v = game.snake.head;
                                    game.snake.waypoints.Add(v);
                                }
                                break;
                            case (ConsoleKey.D):
                                {
                                    game.snake.turn = 1;
                                    Waypoint v = game.snake.head;
                                    game.snake.waypoints.Add(v);
                                }
                                break;
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
    }
}
