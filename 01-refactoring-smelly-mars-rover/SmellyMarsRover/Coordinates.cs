namespace SmellyMarsRover
{
    internal record Coordinates(int x, int y)
    {
        internal Coordinates MoveAlongXAxis(int displacement)
        {
            return new Coordinates(this.x + displacement, this.y);
        }

        internal Coordinates MoveAlongYAxis(int displacement)
        {
            return new Coordinates(this.x, this.y + displacement);
        }
    }
}