using System;

namespace SmellyMarsRover
{
    public class Rover
    {
        private Direction _direction;
        private Coordinates _coordinates;

        public Rover(int x, int y, string direction)
        {
            _direction = new Direction(direction);
            _coordinates = new Coordinates(x, y);
        }

        public void Receive(string commandsSequence)
        {
            for (var i = 0; i < commandsSequence.Length; ++i)
            {
                var command = commandsSequence.Substring(i, 1);

                if (command.Equals("l"))
                {
                    // Rotate Rover left
                    if (_direction.FacingNorth())
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.FacingSouth())
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.FacingWest())
                    {
                        _direction = new Direction("S");
                    }
                    else
                    {
                        _direction = new Direction("N");
                    }
                }
                else if (command.Equals("r"))
                {
                    // Rotate Rover
                    if (_direction.FacingNorth())
                    {
                        _direction = new Direction("E");
                    }
                    else if (_direction.FacingSouth())
                    {
                        _direction = new Direction("W");
                    }
                    else if (_direction.FacingWest())
                    {
                        _direction = new Direction("N");
                    }
                    else
                    {
                        _direction = new Direction("S");
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

                    if (_direction.FacingNorth())
                    {
                        _coordinates = _coordinates.MoveAlongYAxis(displacement);
                    }
                    else if (_direction.FacingSouth())
                    {
                        _coordinates = _coordinates.MoveAlongYAxis(-displacement);
                    }
                    else if (_direction.FacingWest())
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

        protected bool Equals(Rover other)
        {
            return Equals(_direction, other._direction) && Equals(_coordinates, other._coordinates);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Rover)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _coordinates);
        }

        public override string ToString()
        {
            return $"{nameof(_direction)}: {_direction}, {nameof(_coordinates)}: {_coordinates}";
        }
    }
}