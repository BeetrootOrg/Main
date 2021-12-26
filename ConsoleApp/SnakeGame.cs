using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class SnakeGame
    {
        public class Point
        {
            public char [] X { get; set; }
            public char [] Y { get; set; }
            public char[,] Position { get; set; }
            public Point (int x, int y)
            {
                X = new char [x];
                Y = new char [y];
                Position = new char [y, x];
            }
        }
        public class Snack
        {
            public (int x, int y) _position;
            public char value;
            public Snack()
            {
                _position.x = 0;
                _position.y = 0;
                value = ' ';
            }
            public Snack(int x, int y, char val)
            {
                _position.x = x;
                _position.y = y;
                value = val;
            }
            public Snack(Snack s)
            {
                _position.x = s._position.x;
                _position.y = s._position.y;
                value = s.value;
            }
        }
        private int _axeX;
        private int _axeY;
        private Point _point;
        private (int x, int y) _headPosition;
        LinkedList <Snack> _stack;

        public SnakeGame()
        {
            _axeX = 50;
            _axeY = 20;
            _point = new Point(50, 20);
            FillField();
            _headPosition.x = _axeX / 2;
            _headPosition.y = _axeY / 2;
            _stack = new LinkedList<Snack>();
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '1'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '2'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '3'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '4'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '5'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '6'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, '7'));
            // TimerCallback tm = new TimerCallback(Count);
            // DoWorkEvery1Second(tm);
            DoWorkEvery1Second(new TimerCallback(SnackField));
        }
        public SnakeGame(int x, int y)
        {
            _axeX = x;
            _axeY = y;
            _point = new Point(x, y);
            FillField();
        }
        public void FillField()
        {
            for (int y = 0; y < _axeY; y++)
            {
                for (int x = 0; x < _axeX; x++)
                {
                    if ((y == 0) || (y == _axeY - 1))
                    {
                        _point.Position[y, x] = '-';
                    }
                    else if ((x == 0) || (x == _axeX - 1))
                    {
                        _point.Position[y, x] = '|';
                    }
                    else
                    {
                        _point.Position[y, x] = ' ';
                    }
                }
            }
        }
        public void SetPointInField(int y, int x, char data)
        {
            _point.Position[y, x] = data;
        }
        public void ShowField()
        {
            Console.Clear();
            Console.WriteLine("{0} x {1}", _point.X.Length, _point.Y.Length);
            for (int y = 0; y < _point.Y.Length; y++)
            {
                for (int x = 0; x < _point.X.Length; x++)
                {
                     Console.Write(_point.Position[y, x]);
                }
                Console.Write("\r\n");
            }
        }
        private void SnackField(object obj)
        {
            int i;
            Snack[] _stackCopy = new Snack[_stack.Count];
            Snack _head;

            _stack.CopyTo(_stackCopy);
            _stack.Clear();

            _head = new Snack(_stackCopy[_stackCopy.Length - 1]._position.x, _stackCopy[_stackCopy.Length - 1]._position.y, _stackCopy[_stackCopy.Length - 1].value);
            for (i = 0; i < _stackCopy.Length; i++)
            {
                SetPointInField(_stackCopy[i]._position.y, _stackCopy[i]._position.x, _stackCopy[i].value);
            }

            ShowField();
            SetPointInField(_stackCopy[0]._position.y, _stackCopy[0]._position.x, ' ');

            _head._position.x++;
            // _head._position.y++;

            for (i = 0; i < _stackCopy.Length-1; i++)
            {

                _stack.Push(new Snack(_stackCopy[i+1]._position.x, _stackCopy[i+1]._position.y, _stackCopy[i].value));
            }
            _stack.Push(new Snack(_head._position.x, _head._position.y, _head.value));
        }
        private static void DoWorkEvery1Second(TimerCallback callback)
        {
            using var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromSeconds(1));
            Thread.Sleep(TimeSpan.FromSeconds(5));
            Console.WriteLine("FINISHED");
        }
    }
}
