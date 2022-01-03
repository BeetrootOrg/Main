using System;
using System.Collections.Generic;

namespace Course
{
    public class Snake
    {
        private readonly ConsoleColor _snakeColor;

        public Snake(int initialX,
            int initialY,
            ConsoleColor snakeColor,
            int bodyLength = 3)
        {
            _snakeColor = snakeColor;

            Head = new Pixel(initialX, initialY, _snakeColor);

            for (int i = bodyLength; i >= 0; i--)
            {
                Body.Enqueue(new Pixel(Head.X - i - 1, initialY, _snakeColor));
            }

            Draw();
        }

        public Pixel Head { get; private set; }

        public Queue<Pixel> Body { get; } = new Queue<Pixel>();

        public void Move(Direction direction, bool eat = false)
        {
            Clear();

            Body.Enqueue(new Pixel(Head.X, Head.Y, _snakeColor));
            if (!eat)
                Body.Dequeue();

            Head = direction switch
            {
                Direction.Right => new Pixel(Head.X + 1, Head.Y, _snakeColor),
                Direction.Left => new Pixel(Head.X - 1, Head.Y, _snakeColor),
                Direction.Up => new Pixel(Head.X, Head.Y - 1, _snakeColor),
                Direction.Down => new Pixel(Head.X, Head.Y + 1, _snakeColor),
                _ => Head
            };

            Draw();
        }

        public void Draw()
        {
            Head.Draw();

            foreach (Pixel pixel in Body)
            {
                pixel.Draw();
            }
        }

        public void Clear()
        {
            Head.Clear();

            foreach (Pixel pixel in Body)
            {
                pixel.Clear();
            }
        }
    }
}
