namespace SmellyMarsRover;

internal record Direction
{
    private readonly string _value;

    public Direction(string value)
    {
        _value = value;
    }
    
    public bool FacingNorth()
    {
        return _value.Equals("N");
    }

    public bool FacingSouth()
    {
        return _value.Equals("S");
    }

    public bool FacingWest()
    {
        return _value.Equals("W");
    }
}