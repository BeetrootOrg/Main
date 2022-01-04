using System.Diagnostics;
using static System.Console;

namespace Course
{
    public enum Direction
    {
        Up,
        Down,
        Right,
        Left
    }
    
    class Program
    {
        private const int _mapWidth = 90;
        private const int _mapHeight = 30;

        private const int _frameMilliseconds = 200;

        private const ConsoleColor _borderColor = ConsoleColor.Gray;

        private const ConsoleColor _foodColor = ConsoleColor.Red;

        private const ConsoleColor _snakeColor = ConsoleColor.Green;

        private static readonly Random _random = new Random();

        static void Main()
        {
            SetWindowSize(_mapWidth, _mapHeight);
            SetBufferSize(_mapWidth, _mapHeight);
            CursorVisible = false;

            while (true)
            {
                StartGame();
                ReadKey();
            }
        }

        static void StartGame()
        {
            int score = 0;

            Clear();
            DrawBorder();

            Snake snake = new Snake(10, 5, _snakeColor);

            Pixel food = GenFood(snake);
            food.Draw();

            Direction currentMovement = Direction.Right;

            var sw = new Stopwatch();

            while (true)
            {
                sw.Restart();
                Direction oldMovement = currentMovement;

                while (sw.ElapsedMilliseconds <= _frameMilliseconds)
                {
                    if (currentMovement == oldMovement)
                        currentMovement = ReadMovement(currentMovement);
                }

                if (snake.Head.X == food.X && snake.Head.Y == food.Y)
                {
                    snake.Move(currentMovement, true);
                    food = GenFood(snake);
                    food.Draw();

                    score++;
                }
                else
                {
                    snake.Move(currentMovement);
                }

                if (snake.Head.X == _mapWidth - 1
                    || snake.Head.X == 0
                    || snake.Head.Y == _mapHeight - 1
                    || snake.Head.Y == 0
                    || snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
                    break;
            }

            snake.Clear();
            food.Clear();

            SetCursorPosition(_mapWidth / 3, _mapHeight / 2);
            WriteLine($"Game over, Score: {score}");
        }

        static void DrawBorder()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                new Pixel(i, 0, _borderColor, '#').Draw();
                new Pixel(i, _mapHeight - 1, _borderColor, '#').Draw();
            }

            for (int i = 0; i < _mapHeight; i++)
            {
                new Pixel(0, i, _borderColor, '#').Draw();
                new Pixel(_mapWidth - 1, i, _borderColor, '#').Draw();
            }
        }

        static Pixel GenFood(Snake snake)
        {
            Pixel food;

            do
            {
                food = new Pixel(_random.Next(1, _mapWidth - 1), _random.Next(1, _mapHeight - 1), _foodColor, 'O');
            } while (snake.Head.X == food.X && snake.Head.Y == food.Y ||
                     snake.Body.Any(b => b.X == food.X && b.Y == food.Y));

            return food;
        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!KeyAvailable)
                return currentDirection;

            ConsoleKey key = ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.W when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.A when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.S when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.D when currentDirection != Direction.Left => Direction.Right,
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }
    }
}
