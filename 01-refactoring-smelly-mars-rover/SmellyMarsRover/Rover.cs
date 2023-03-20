using System;

namespace SmellyMarsRover
{
    public class Rover {

        private String _direction;
        private int _y;
        private int _x;

        public Rover(int x, int y, String direction) {
            this._direction = direction;
            this._y = y;
            this._x = x;
        }

        public void Receive(String commandsSequence) {
            for (int i = 0; i < commandsSequence.Length; ++i) {
                String command = commandsSequence.Substring(i,  1);

                if (command.Equals("l") || command.Equals("r")) {

                    // Rotate Rover
                    if (_direction.Equals("N")) {
                        if (command.Equals("r")) {
                            _direction = "E";
                        } else {
                            _direction = "W";
                        }
                    } else if (_direction.Equals("S")) {
                        if (command.Equals("r")) {
                            _direction = "W";
                        } else {
                            _direction = "E";
                        }
                    } else if (_direction.Equals("W")) {
                        if (command.Equals("r")) {
                            _direction = "N";
                        } else {
                            _direction = "S";
                        }
                    } else {
                        if (command.Equals("r")) {
                            _direction = "S";
                        } else {
                            _direction = "N";
                        }
                    }
                } else {

                    // Displace Rover
                    int displacement1 = -1;

                    if (command.Equals("f")) {
                        displacement1 = 1;
                    }
                    int displacement = displacement1;

                    if (_direction.Equals("N")) {
                        _y += displacement;
                    } else if (_direction.Equals("S")) {
                        _y -= displacement;
                    } else if (_direction.Equals("W")) {
                        _x -= displacement;
                    } else {
                        _x += displacement;
                    }
                }
            }
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Rover)obj);
        }
        
        private bool Equals(Rover other)
        {
            return _direction == other._direction && _y == other._y && _x == other._x;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_direction, _y, _x);
        }

        public override string ToString()
        {
            return "Rover{" +
                "direction='" + _direction + '\'' +
                ", y=" + _y +
                ", x=" + _x +
                '}';
        }
    }
}