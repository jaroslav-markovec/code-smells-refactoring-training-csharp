﻿using System;
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
                    if (IsFacingNorth())
                    {
                        Direction = "W";
                    }
                    else if (IsFacingSouth())
                    {
                        Direction = "E";
                    }
                    else if (IsFacingWest())
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
                    if (IsFacingNorth())
                    {
                        Direction = "E";

                    }
                    else if (IsFacingSouth())
                    {
                        Direction = "W";

                    }
                    else if (IsFacingWest())
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

                    if (IsFacingNorth())
                    {
                        _y += displacement;
                    }
                    else if (IsFacingSouth())
                    {
                        _y -= displacement;
                    }
                    else if (IsFacingWest())
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

        private bool IsFacingWest()
        {
            return _direction.value.Equals("W");
        }

        private bool IsFacingSouth()
        {
            return _direction.value.Equals("S");
        }

        private bool IsFacingNorth()
        {
            return _direction.value.Equals("N");
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

    internal record Direction(string value);
}