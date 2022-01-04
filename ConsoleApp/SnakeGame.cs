using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    enum Move
    {
        UP = 0, 
        DOWN = 1, 
        LEFT = 2, 
        RIGHT = 3,
        INITIAL = 4
    }
    public class Log
    {
        public int Up { get; set; }
        public int Down { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public Log()
        {
            Up = 0;
            Down = 0;
            Left = 0;
            Right = 0;
        }
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
        private Log _log;
        private ConsoleKeyInfo ck;
        private Move _beforeLastModeMove;
        private Move _lastModeMove;
        private Move _setModeMove;
        private Move _modeMove;
        private int _axeX;
        private int _axeY;
        private int _maxX;
        private int _maxY;
        private Point _point;
        private (int x, int y) _headPosition;
        private Snack[] _food;
        private int _foodLength { set; get; }
        private LinkedList <Snack> _stack;

        public SnakeGame(int xSize, int ySize)
        {
            _axeX = xSize;
            _axeY = ySize;
            _maxX = (_axeX - 2);
            _maxY = (_axeY - 2);
            _lastModeMove = Move.INITIAL;
            _setModeMove = Move.RIGHT;
            _modeMove = Move.RIGHT;
            _point = new Point(_axeX, _axeY);
            _food = new Snack[_axeY];
            _foodLength = 0;
            _log = new Log();
            FillField();
            _headPosition.x = 20;
            _headPosition.y = _axeY / 2;
            _stack = new LinkedList<Snack>();
            
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, 'k'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, 'c'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, 'a'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, 'n'));
            _headPosition.x++;
            _stack.Push(new Snack(_headPosition.x, _headPosition.y, 's'));
            _headPosition.x++;

            ShowField();
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
                _generateAndSetFood(y);
            }
        }
        private void _generateAndSetFood(int index)
        {
            if((index < 1) || (index > (_maxY)))
            {
                return;
            }

            Random x, r;
            x = new Random();
            r = new Random();

            int rX = x.Next(1, _maxX);
            char rMove = (char)r.Next((int)'0', (int)'9');
            _food[index] = new Snack(rX, index, rMove);
            _point.Position[index, rX] = rMove;
        }
        public void ShowField()
        {
            Console.Clear();            
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
            if (_stack.Count <= 0) { return; }

            _stackCopy = new Snack[_stack.Count];

            _head = new Snack(0, 0, ' ');
            _head = _stack.Peek();
            if (_food[_head._position.y] != null)
            {
                if ((_food[_head._position.y]._position.x == _head._position.x) &&
                    (_food[_head._position.y]._position.y == _head._position.y))
                {
                    _stack.Push(new Snack(_head._position.x, _head._position.y, _food[_head._position.y].value));
                    _foodLength++;
                    _food[_head._position.y] = null;
                    return;
                }
            }

            _stack.CopyTo(_stackCopy);
            _head = new Snack(_stackCopy[_stackCopy.Length - 1]._position.x, _stackCopy[_stackCopy.Length - 1]._position.y, _stackCopy[_stackCopy.Length - 1].value);

            try
            {
                if (_moveTo(_head, ref _stackCopy) != true)
                {
                    return;
                }

                Console.SetCursorPosition(_stackCopy[0]._position.x, _stackCopy[0]._position.y);
                Console.Write(' ');
                Console.SetCursorPosition(_head._position.x, _head._position.y);
                Console.Write(_head.value);

                _stack.Clear();
                for (i = 0; i < _stackCopy.Length - 1; i++)
                {
                    _stack.Push(new Snack(_stackCopy[i + 1]._position.x, _stackCopy[i + 1]._position.y, _stackCopy[i].value));
                    Console.SetCursorPosition(_stackCopy[i + 1]._position.x, _stackCopy[i + 1]._position.y);
                    Console.Write(_stackCopy[i].value);
                }
                _stack.Push(new Snack(_head._position.x, _head._position.y, _head.value));
                ShowDebugData(_stackCopy, _head);
            }
            catch (Exception ex)
            {
                ShowDebugData(_stackCopy, _head);
                Console.WriteLine(ex.ToString());
            }
        }

        private void ShowDebugData(Snack[] _stackCopy, Snack _head)
        {
            Console.SetCursorPosition(0, _axeY+1);
            Console.WriteLine("{0} x {1} : {2} x {3}  Mode: {4}   ", _point.X.Length, _point.Y.Length, _head._position.x, _head._position.y, _modeMove);
            Console.Write("Snack Data: \"");
            for (int i = _stackCopy.Length - 1; i >= 0; i--)
            {
                Console.Write(_stackCopy[i].value);
            }
            Console.Write("\", Length: {0}    \r\n\r\n", _stackCopy.Length);
        }

        public void SetNewDirection(object obj)
        {
            Random r = new Random();
            Move rMove = (Move)r.Next(0, 4);
            _setModeMove = rMove;
        }
        private bool _moveTo(Snack _head, ref Snack[] stackCopy)
        {
            bool _enableMove = false;

            switch (_setModeMove)
            {
                case Move.UP:
                    {
                        _modeMove = Move.UP;
                        _enableMove = _handlerMoveUp(ref _head, ref stackCopy);
                        if (_enableMove != true)
                        {
                            _modeMove = Move.DOWN;
                            _enableMove = _handlerMoveDown(ref _head, ref stackCopy);
                            if (_enableMove != true)
                            {
                                if(_head._position.x > (_maxX / 2))
                                {
                                    _modeMove = Move.LEFT;
                                    _enableMove = _handlerMoveLeft(ref _head, ref stackCopy);
                                }
                                else
                                {
                                    _modeMove = Move.RIGHT;
                                    _enableMove = _handlerMoveRight(ref _head, ref stackCopy);
                                }                               
                                
                            }                            
                        }
                        break;
                    }
                case Move.DOWN:
                    {
                        _modeMove = Move.DOWN;
                        _enableMove = _handlerMoveDown(ref _head, ref stackCopy);
                        if (_enableMove != true)
                        {
                            _modeMove = Move.UP;
                            _enableMove = _handlerMoveUp(ref _head, ref stackCopy);
                            if (_enableMove != true)
                            {
                                if (_head._position.x > (_maxX / 2))
                                {
                                    _modeMove = Move.LEFT;
                                    _enableMove = _handlerMoveLeft(ref _head, ref stackCopy);
                                }
                                else
                                {
                                    _modeMove = Move.RIGHT;
                                    _enableMove = _handlerMoveRight(ref _head, ref stackCopy);
                                }

                            }
                        }
                        break;
                    }
                case Move.LEFT:
                    {
                        _modeMove = Move.LEFT;
                        _enableMove = _handlerMoveLeft(ref _head, ref stackCopy);
                        if (_enableMove != true)
                        {
                            _modeMove = Move.RIGHT;
                            _enableMove = _handlerMoveRight(ref _head, ref stackCopy);
                            if (_enableMove != true)
                            {
                                if (_head._position.y > (_maxY / 2))
                                {
                                    _modeMove = Move.UP;
                                    _enableMove = _handlerMoveUp(ref _head, ref stackCopy);
                                }
                                else
                                {
                                    _modeMove = Move.DOWN;
                                    _enableMove = _handlerMoveDown(ref _head, ref stackCopy);
                                }
                            }
                        }
                        break;
                    }
                case Move.RIGHT:
                    {
                        _modeMove = Move.RIGHT;
                        _enableMove = _handlerMoveRight(ref _head, ref stackCopy);
                        if (_enableMove != true)
                        {
                            _modeMove = Move.LEFT;
                            _enableMove = _handlerMoveLeft(ref _head, ref stackCopy);
                            if (_enableMove != true)
                            {
                                if (_head._position.y > (_maxY / 2))
                                {
                                    _modeMove = Move.UP;
                                    _enableMove = _handlerMoveUp(ref _head, ref stackCopy);
                                }
                                else
                                {
                                    _modeMove = Move.DOWN;
                                    _enableMove = _handlerMoveDown(ref _head, ref stackCopy);
                                }
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
            return _enableMove;
        }

        private bool _handlerMoveRight(ref Snack _head, ref Snack[] stackCopy)
        {
            bool _enableMove = false;

            _log.Right++;
            if (_head._position.y == 1)
            {
                if (_head._position.x < _maxX)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.RIGHT) != true)
                    {
                        _head._position.x++;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.y = 2;
                    _saveLog();
                    _modeMove = Move.DOWN;
                    _enableMove = true;
                }
            }
            else if (_head._position.y == _maxY)
            {
                if (_head._position.x < _maxX)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.RIGHT) != true)
                    {
                        _head._position.x++;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.y = _maxY - 1;
                    _saveLog();
                    _modeMove = Move.UP;
                    _enableMove = true;
                }
            }
            else if ((_head._position.y > 1) && (_head._position.y < _maxY))
            {
                if ((_detectSnackBody(ref _head, ref stackCopy, Move.RIGHT) != true)  && (_head._position.x < _maxX))
                {
                    _head._position.x++;
                    _enableMove = true;
                }
            }
            else
            {
                _head._position.y++;
                _saveLog();
                _modeMove = Move.DOWN;
                _enableMove = true;
            }
            
            return _enableMove;
        }

        private bool _handlerMoveLeft(ref Snack _head, ref Snack[] stackCopy)
        {
            bool _enableMove = false;

            _log.Left++;
            if (_head._position.y == 1)
            {
                if (_head._position.x > 1)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.LEFT) != true)
                    {
                        _head._position.x--;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.y = 2;
                    _saveLog();
                    _modeMove = Move.DOWN;
                    _enableMove = true;
                }
            }
            else if (_head._position.y == _maxY)
            {
                if (_head._position.x > 1)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.LEFT) != true)
                    {
                        _head._position.x--;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.y = _maxY - 1;
                    _saveLog();
                    _modeMove = Move.UP;
                    _enableMove = true;
                }
            }
            else if ((_head._position.y > 1) && (_head._position.y < _maxY))
            {
                if ((_detectSnackBody(ref _head, ref stackCopy, Move.LEFT) != true) && (_head._position.x > 1))
                {
                    _head._position.x--;
                    _enableMove = true;
                }
            }
            else
            {
                _head._position.y++;
                _saveLog();
                _modeMove = Move.DOWN;
                _enableMove = true;
            }
            return _enableMove;
        }
        private bool _handlerMoveDown(ref Snack _head, ref Snack[] stackCopy)
        {
            bool _enableMove = false;

            _log.Down++;
            if (_head._position.x == 1)
            {
                if (_head._position.y < _maxY)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.DOWN) != true)
                    {
                        _head._position.y++;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.x = 2;
                    _saveLog();
                    _modeMove = Move.RIGHT;
                    _enableMove = true;
                }
            }
            else if (_head._position.x == _maxX)
            {
                if (_head._position.y < _maxY)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.DOWN) != true)
                    {
                        _head._position.y++;
                        _enableMove = true;
                    }
                }
                else
                {
                    _head._position.x = _maxX - 1;
                    _beforeLastModeMove = _lastModeMove;
                    _lastModeMove = _modeMove;
                    _modeMove = Move.LEFT;
                    _enableMove = true;
                }
            }
            else if ((_head._position.x > 1) && (_head._position.x < _maxX))
            {
                if ((_detectSnackBody(ref _head, ref stackCopy, Move.DOWN) != true) && (_head._position.y < _maxY))
                {
                    _head._position.y++;
                    _enableMove = true;
                }
            }
            else
            {
                _head._position.x++;
                _saveLog();
                _modeMove = Move.LEFT;
                _enableMove = true;
            }
            return _enableMove;
        }
        private bool _handlerMoveUp(ref Snack _head, ref Snack[] stackCopy)
        {
            bool _enableMove = false;
            _log.Up++;
            if (_head._position.x == 1) // moving on left side
            {
                if (_head._position.y > 1)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.UP) != true)
                    {
                        _head._position.y--;
                        _enableMove = true;
                    }
                }
                else
                {
                    // need to detect...
                    _head._position.x = 2;
                    _saveLog();
                    _modeMove = Move.RIGHT;
                    _enableMove = true;
                }
            }
            else if (_head._position.x == _maxX) // moving on right side
            {
                if (_head._position.y > 1)
                {
                    if (_detectSnackBody(ref _head, ref stackCopy, Move.UP) != true)
                    {
                        _head._position.y--;
                        _enableMove = true;
                    }
                }
                else
                {
                    // need to detect...
                    _head._position.x = _maxX - 1;
                    _saveLog();
                    _modeMove = Move.LEFT;
                    _enableMove = true;
                }
            }
            else if ((_head._position.x > 1) && (_head._position.x < _maxX))
            {
                if ((_detectSnackBody(ref _head, ref stackCopy, Move.UP) != true) && (_head._position.y > 1))
                {
                    _head._position.y--;
                    _enableMove = true;
                }
            }
            else
            {
                _head._position.x++;
                _saveLog();
                _modeMove = Move.RIGHT;
                _enableMove = true;
            }
            return _enableMove;
        }
        private bool _detectSnackBody(ref Snack _head, ref Snack[] stackCopy, Move rMove)
        {
            int index = stackCopy.Length - 2;
            int i = (stackCopy.Length - 6) > 4 ? stackCopy.Length - 2 : 4;

            switch (rMove)
            {
                case Move.UP:
                    do
                    {
                        if ((_head._position.x == stackCopy[index]._position.x) && ((_head._position.y - 1) == stackCopy[index]._position.y))
                        {
                            return true;
                        }
                        index--;
                        i--;
                    } while (i > 0);
                    break;
                case Move.DOWN:
                    do
                    {
                        if ((_head._position.x == stackCopy[index]._position.x) && ((_head._position.y + 1) == stackCopy[index]._position.y))
                        {
                            return true;
                        }
                        index--;
                        i--;
                    } while (i > 0);
                    break;
                case Move.LEFT:
                    do
                    {
                        if (((_head._position.x - 1) == stackCopy[index]._position.x) && (_head._position.y == stackCopy[index]._position.y))
                        {
                            return true;
                        }
                        index--;
                        i--;
                    } while (i > 0);
                    break;
                case Move.RIGHT:
                    do
                    {
                        if (((_head._position.x + 1) == stackCopy[index]._position.x) && (_head._position.y == stackCopy[index]._position.y))
                        {
                            return true;
                        }
                        index--;
                        i--;
                    } while (i > 0);
                    break;
                default:                    
                    break;
            }
            return false;
        }

        private void _saveLog()
        {
            _beforeLastModeMove = _lastModeMove;
            _lastModeMove = _modeMove;
        }
    }
}
