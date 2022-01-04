using static System.Console;

namespace Course
{
    public readonly struct Pixel
    {

        public Pixel(int x, int y, ConsoleColor color, char characterToUse = '█')
        {
            X = x;
            Y = y;
            Color = color;
            CharacterToUse = characterToUse;
        }

        public int X { get; }
        public int Y { get; }
        public ConsoleColor Color { get; }
        public char CharacterToUse { get; }

        public void Draw()
        {
            ForegroundColor = Color;
            SetCursorPosition(X , Y);
            Write(CharacterToUse);
        }

        public void Clear()
        {
            SetCursorPosition(X, Y);
            Write(' ');
        }
    }
}
