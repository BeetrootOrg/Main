using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    enum Move
    {
        UP, 
        DOWN, 
        LEFT, 
        RIGHT,
        INITIAL
    }
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
        private ConsoleKeyInfo ck;
        private Move _LastModeMove;
        private Move _modeMove;
        private int _axeX;
        private int _axeY;
        private int _maxX;
        private int _maxY;
        private Point _point;
        private (int x, int y) _headPosition;
        private LinkedList <Snack> _stack;

        public SnakeGame()
        {
            _axeX = 50;
            _axeY = 20;
            _maxX = (_axeX - 2);
            _maxY = (_axeY - 2);
            _LastModeMove = Move.INITIAL;
            _modeMove = Move.RIGHT;
            _point = new Point(50, 20);
            FillField();
            _headPosition.x = 41; // _axeX / 2;
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

            //// Delegat for Timer
            //// TimerCallback timeCB = new TimerCallback(SetDirection);
            //// using Timer time = new Timer(timeCB, null, 0, 1000);
            //// DoWorkReadConsoleKeyEvery200mSecond(new TimerCallback(SetDirection));

            //////TimerCallback timeCB = new TimerCallback(SnackField);
            //////using Timer time = new Timer(timeCB, null, 0, 200);
            //DoWorkEvery1Second(new TimerCallback(SnackField));
        }
        public SnakeGame(int x, int y)
        {
            _axeX = x;
            _axeY = y;
            _LastModeMove = Move.INITIAL;
            _modeMove = Move.RIGHT;
            _point = new Point(x, y);
            FillField();
        }
        public void SetDirection(object obj)
        {
            /*if(obj == null)
            {
                return;
            }*/
            ConsoleKeyInfo ck = Console.ReadKey();
            switch (ck.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    // ...
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    // ...
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    // ...
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    //Exit();
                    break;


                case ConsoleKey.UpArrow:
                    if (_modeMove != Move.DOWN) { _modeMove = Move.UP; }
                    break;
                case ConsoleKey.DownArrow:
                    if (_modeMove != Move.UP) { _modeMove = Move.DOWN; }
                    break;
                case ConsoleKey.LeftArrow:
                    if (_modeMove != Move.RIGHT) { _modeMove = Move.LEFT; }
                    break;
                case ConsoleKey.RightArrow:
                    if (_modeMove != Move.LEFT) { _modeMove = Move.RIGHT; }
                    break;



                default:
                    break;
            }
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
        public void ShowField(Snack _head)
        {
            Console.Clear();
            Console.WriteLine("{0} x {1}, Head X:{2} Y:{3} Value:{4} lASTMode:{5} Mode:{6}", _point.X.Length, _point.Y.Length, _head._position.x, _head._position.y, _head.value, _LastModeMove, _modeMove);
            for (int y = 0; y < _point.Y.Length; y++)
            {
                for (int x = 0; x < _point.X.Length; x++)
                {
                     Console.Write(_point.Position[y, x]);
                }
                Console.Write("\r\n");
            }
        }
        public void SnackField(object obj)
        {
            int i;
            Snack[] _stackCopy;
            Snack _head;

            if(_stack.Count <= 0)
            {
                return;
            }

            _stackCopy = new Snack[_stack.Count];
            _stack.CopyTo(_stackCopy);
            _stack.Clear();

            _head = new Snack(_stackCopy[_stackCopy.Length - 1]._position.x, _stackCopy[_stackCopy.Length - 1]._position.y, _stackCopy[_stackCopy.Length - 1].value);
            for (i = 0; i < _stackCopy.Length; i++)
            {
                SetPointInField(_stackCopy[i]._position.y, _stackCopy[i]._position.x, _stackCopy[i].value);
            }

            // ShowField(ref _head);
            // SetPointInField(_stackCopy[0]._position.y, _stackCopy[0]._position.x, ' ');

            _moveTo(_head);

            ShowField(_head);
            SetPointInField(_stackCopy[0]._position.y, _stackCopy[0]._position.x, ' ');

            for (i = 0; i < _stackCopy.Length - 1; i++)
            {

                _stack.Push(new Snack(_stackCopy[i + 1]._position.x, _stackCopy[i + 1]._position.y, _stackCopy[i].value));
            }
            _stack.Push(new Snack(_head._position.x, _head._position.y, _head.value));
        }

        private void _moveTo(Snack _head)
        {
            switch (_modeMove)
            {
                case Move.UP:
                    _handlerMoveUp(_head);
                    break;
                case Move.DOWN:
                    _handlerMoveDown(_head);
                    break;
                case Move.LEFT:
                    _handlerMoveLeft(_head);
                    break;
                case Move.RIGHT:
                    _handlerMoveRight(_head);
                    break;
                default:
                    break;
            }
        }

        private void _handlerMoveRight(Snack _head)
        {
            if (_head._position.y == 1)
            {
                if (_head._position.x < _maxX)
                {
                    _head._position.x++;
                }
                else
                {
                    _head._position.y = 2;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.DOWN;
                }
            }
            else if (_head._position.y == _maxY)
            {
                if (_head._position.x < _maxX)
                {
                    _head._position.x++;
                }
                else
                {
                    _head._position.y = _maxY - 1;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.UP;
                }
            }
            else if (((_head._position.y > 1) && (_head._position.y < _maxX)) && (_head._position.x < _maxX))
            {
                _head._position.x++;
            }
            else
            {
                _head._position.y++;
                _LastModeMove = _modeMove;
                _modeMove = Move.DOWN;
            }
        }

        private void _handlerMoveLeft(Snack _head)
        {
            if (_head._position.y == 1)
            {
                if (_head._position.x > 1)
                {
                    _head._position.x--;
                }
                else
                {
                    _head._position.y = 2;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.DOWN;
                }
            }
            else if (_head._position.y == _maxY)
            {
                if (_head._position.x > 1)
                {
                    _head._position.x--;
                }
                else
                {
                    _head._position.y = _maxY - 1;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.UP;
                }
            }
            else if (((_head._position.y > 1) && (_head._position.y < _maxX)) && (_head._position.x > 1))
            {
                _head._position.x--;
            }
            else
            {
                _head._position.y++;
                _LastModeMove = _modeMove;
                _modeMove = Move.DOWN;
            }
        }

        private void _handlerMoveDown(Snack _head)
        {
            if (_head._position.x == 1)
            {
                if (_head._position.y < _maxY)
                {
                    _head._position.y++;
                }
                else
                {
                    _head._position.x = 2;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.RIGHT;
                }
            }
            else if (_head._position.x == _maxX)
            {
                if (_head._position.y < _maxY)
                {
                    _head._position.y++;
                }
                else
                {
                    _head._position.x = _maxX - 1;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.LEFT;
                }
            }
            else if (((_head._position.x > 1) && (_head._position.x < _maxX)) && (_head._position.y < _maxY))
            {
                _head._position.y++;
            }
            else
            {
                _head._position.x++;
                _LastModeMove = _modeMove;
                _modeMove = Move.RIGHT;
            }
        }

        private void _handlerMoveUp(Snack _head)
        {
            if (_head._position.x == 1)
            {
                if (_head._position.y > 1)
                {
                    _head._position.y--;
                }
                else
                {
                    _head._position.x = 2;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.RIGHT;
                }
            }
            else if (_head._position.x == _maxX)
            {
                if (_head._position.y > 1)
                {
                    _head._position.y--;
                }
                else
                {
                    _head._position.x = _maxX - 1;
                    _LastModeMove = _modeMove;
                    _modeMove = Move.LEFT;
                }
            }
            else if (((_head._position.x > 1) && (_head._position.x < _maxX)) && (_head._position.y > 1))
            {
                _head._position.y--;
            }
            else
            {
                _head._position.x++;
                _LastModeMove = _modeMove;
                _modeMove = Move.RIGHT;
            }
        }

        private static void DoWorkEvery1Second(TimerCallback callback)
        {
            using var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(200));
            Thread.Sleep(TimeSpan.FromSeconds(50));
            Console.WriteLine("FINISHED");
        }
        private static void DoWorkReadConsoleKeyEvery200mSecond(TimerCallback callback)
        {
             var timer = new Timer(callback, null, Timeout.Infinite, 0);
            timer.Change(TimeSpan.Zero, TimeSpan.FromMilliseconds(1000));
            Thread.Sleep(TimeSpan.FromSeconds(50));
            Console.WriteLine("FINISHED");
        }
    }
}
