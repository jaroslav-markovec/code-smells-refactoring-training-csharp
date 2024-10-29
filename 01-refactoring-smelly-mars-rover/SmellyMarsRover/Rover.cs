using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace SmellyMarsRover
{
    public class Rover
    {
        private string Direction
        {
            set
            {
                _direction = new Direction(value);
            }
        }


        private Direction _direction;
        private int _y;
        private int _x;

        public Rover(int x, int y, string direction)
        {
            Direction = direction;
            _y = y;
            _x = x;
        }

        public void Receive(string commandsSequence)
        {

            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover Left
                    if (_direction.IsFacingNorth())
                    {
                        Direction = "W";
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        Direction = "E";
                    }
                    else if (_direction.IsFacingWest())
                    {
                        Direction = "S";
                    }
                    else
                    {
                        Direction = "N";
                    }
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover Right
                    if (_direction.IsFacingNorth())
                    {
                        Direction = "E";

                    }
                    else if (_direction.IsFacingSouth())
                    {
                        Direction = "W";

                    }
                    else if (_direction.IsFacingWest())
                    {
                        Direction = "N";
                    }
                    else
                    {
                        Direction = "S";
                    }
                }
                else
                {
                    // Displace Rover
                    var displacement1 = -1;

                    if (command.Equals("f"))
                    {
                        displacement1 = 1;
                    }

                    var displacement = displacement1;

                    if (_direction.IsFacingNorth())
                    {
                        _y += displacement;
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _y -= displacement;
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _x -= displacement;
                    }
                    else
                    {
                        _x += displacement;
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Rover rover &&
                   EqualityComparer<Direction>.Default.Equals(_direction, rover._direction) &&
                   _y == rover._y &&
                   _x == rover._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _y, _x);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}, {nameof(_y)}: {_y}, {nameof(_x)}: {_x}";
        }

    }

    internal record Direction(string value)
    {
        internal bool IsFacingSouth()
        {
            return value.Equals("S");
        }

        internal bool IsFacingWest()
        {
            return value.Equals("W");
        }

        internal bool IsFacingNorth()
        {
            return value.Equals("N");
        }

        internal bool IsFacingEast()
        {
            return value.Equals("E");
        }

    };
}