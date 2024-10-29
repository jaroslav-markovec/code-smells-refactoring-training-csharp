namespace SmellyMarsRover
{
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