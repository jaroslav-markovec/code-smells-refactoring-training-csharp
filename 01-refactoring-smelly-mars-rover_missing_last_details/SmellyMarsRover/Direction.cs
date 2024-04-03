namespace SmellyMarsRover;

internal abstract record Direction
{
    private const string WEST = "W";
    private const string EAST = "E";
    private const string SOUTH = "S";
    private const string NORTH = "N";
    private readonly string _value;

    public Direction(string value)
    {
        _value = value;
    }

    public bool FacingNorth()
    {
        return _value.Equals(NORTH);
    }

    public bool FacingSouth()
    {
        return _value.Equals(SOUTH);
    }

    public bool FacingWest()
    {
        return _value.Equals(WEST);
    }

    public static Direction Create(string directionEncoding)
    {
        if (directionEncoding.Equals(NORTH))
        {
            return new North();
        }

        if (directionEncoding.Equals(SOUTH))
        {
            return new South();
        }

        if (directionEncoding.Equals(WEST))
            return new West();

        return new East();
    }

    public abstract Direction RotateLeft();

    public abstract Direction RotateRight();

    public abstract Coordinates Move(int displacement, Coordinates coordinates);

    private record East() : Direction(EAST)
    {
        public override Direction RotateLeft()
        {
            return Create(NORTH);
        }

        public override Direction RotateRight()
        {
            return Create(SOUTH);
        }

        public override Coordinates Move(int displacement, Coordinates coordinates)
        {
            return coordinates.MoveAlongXAxis(displacement);
        }
    }

    private record West() : Direction(WEST)
    {
        public override Direction RotateLeft()
        {
            return Create(SOUTH);
        }

        public override Direction RotateRight()
        {
            return Create(NORTH);
        }

        public override Coordinates Move(int displacement, Coordinates coordinates)
        {
            return coordinates.MoveAlongXAxis(-displacement);
        }
    }

    private record South() : Direction(SOUTH)
    {
        public override Direction RotateLeft()
        {
            return Create(EAST);
        }

        public override Direction RotateRight()
        {
            return Create(WEST);
        }

        public override Coordinates Move(int displacement, Coordinates coordinates)
        {
            return coordinates.MoveAlongYAxis(-displacement);
        }
    }

    private record North() : Direction(NORTH)
    {
        public override Direction RotateLeft()
        {
            return Create(WEST);
        }

        public override Direction RotateRight()
        {
            return Create(EAST);
        }

        public override Coordinates Move(int displacement, Coordinates coordinates)
        {
            return coordinates.MoveAlongYAxis(displacement);
        }
    }
}