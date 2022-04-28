namespace ToyRobotLib
{
    public class Coordinate
    {
        public const int MinValue = 0;
        public const int MaxValue = 4;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; }
        public int Y { get; }

        public bool IsValid()
        {
            return X >= MinValue && X <= MaxValue && Y >= MinValue && Y <= MaxValue;
        }
    }
}