﻿using System;
using System.Collections.Generic;

namespace SmellyMarsRover
{
    public class Rover
    {
        private Direction _direction;
        private Coordinates _coordinates;

        public Rover(int x, int y, string direction)
        {
            _direction = Direction.Create(direction);
            SetCoordinates(x, y);
        }

        private void SetCoordinates(int x, int y)
        {
            _coordinates = new Coordinates(x, y);
        }

        public void Receive(string commandsSequence)
        {

            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    var direction = RotateLeft();

                    _direction = direction;
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover Right
                    if (_direction.IsFacingNorth())
                    {
                        _direction = Direction.Create("E");

                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _direction = Direction.Create("W");

                    }
                    else if (_direction.IsFacingWest())
                    {
                        _direction = Direction.Create("N");
                    }
                    else
                    {
                        _direction = Direction.Create("S");
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
                        _coordinates = _coordinates.MoveAlongYAxis(displacement);
                    }
                    else if (_direction.IsFacingSouth())
                    {
                        _coordinates = _coordinates.MoveAlongYAxis(-displacement);
                    }
                    else if (_direction.IsFacingWest())
                    {
                        _coordinates = _coordinates.MoveAlongXAxis(-displacement);
                    }
                    else
                    {
                        _coordinates = _coordinates.MoveAlongXAxis(displacement);
                    }
                }
            }
        }

        private Direction RotateLeft()
        {
            Direction direction;
            if (_direction.IsFacingNorth())
            {
                direction = Direction.Create("W");
            }
            else if (_direction.IsFacingSouth())
            {
                direction = Direction.Create("E");
            }
            else if (_direction.IsFacingWest())
            {
                direction = Direction.Create("S");
            }
            else
            {
                direction = Direction.Create("N");
            }

            return direction;
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}, {nameof(_coordinates)}: {_coordinates}";
        }

        public override bool Equals(object obj)
        {
            return obj is Rover rover &&
                   EqualityComparer<Direction>.Default.Equals(_direction, rover._direction) &&
                   EqualityComparer<Coordinates>.Default.Equals(_coordinates, rover._coordinates);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _coordinates);
        }
    }
}