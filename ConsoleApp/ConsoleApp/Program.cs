﻿using System;
using System.Text;

namespace ConsoleApp
{
    enum Direction
    {
        UP = 0,
        RIGHT = 1,
        DOWN = 2,
        LEFT = 4
    }

    class Program
    {
        static void Main()
        {
            var direction = Direction.DOWN;

            if (direction == Direction.DOWN)
            {
                Console.WriteLine("You go down");
            }

            direction = (Direction)4;
            Console.WriteLine(direction);

            direction = (Direction)5;
            Console.WriteLine(direction);

            direction = Direction.RIGHT;

            var x = 2;
            var nextX = direction switch
            {
                Direction.UP => x,
                Direction.RIGHT => x + 5,
                Direction.DOWN => x,
                Direction.LEFT => x - 5,
                _ => throw new ArgumentOutOfRangeException(nameof(direction))
            };
        }

        static void ToNeyYear()
        {
            var now = DateTime.Now;
            var ny = new DateTime(now.Year, 12, 31);
            Console.WriteLine($"To NY left {ny.Subtract(now).Days + 1}");
            Console.WriteLine($"From NY {now.DayOfYear}");
        }

        static bool TryAction(int num, out int i)
        {
            if (num % 3 == 0)
            {
                i = num * 5;
                return true;
            } 

            i = 0;
            return false;
        }

        static string Repeat(string str, int n)
        {
            var result = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                result.Append(str);
            }

            return result.ToString();
        }

        static void Sum()
        {
            bool success;
            int x;
            int y;

            do
            {
                var input = Console.ReadLine();
                success = int.TryParse(input, out x);
            } while (!success);

            x = 25;
            y = 20;

            var min = Math.Min(x, y);
            var max = Math.Max(x, y);

            var sum = 0;
            for (int i = min; i <= max; i++)
            {
                sum += i;
            }
        }
    }
}