using System.Collections.Generic;

namespace ToyRobotLib
{
    public class ToyRobot : IToyRobot
    {
        private readonly Dictionary<Direction, Direction> _leftLookup = new Dictionary<Direction, Direction>
        {
            { Direction.EAST, Direction.NORTH },
            { Direction.NORTH, Direction.WEST },
            { Direction.WEST, Direction.SOUTH },
            { Direction.SOUTH, Direction.EAST }
        };

        private readonly Dictionary<Direction, Coordinate> _moveLookup = new Dictionary<Direction, Coordinate>
        {
            { Direction.EAST, new Coordinate(1, 0) },
            { Direction.WEST, new Coordinate(-1, 0) },
            { Direction.NORTH, new Coordinate(0, 1) },
            { Direction.SOUTH, new Coordinate(0, -1) }
        };

        private readonly Dictionary<Direction, Direction> _rightLookup = new Dictionary<Direction, Direction>
        {
            { Direction.EAST, Direction.SOUTH },
            { Direction.SOUTH, Direction.WEST },
            { Direction.WEST, Direction.NORTH },
            { Direction.NORTH, Direction.EAST }
        };

        private Coordinate _coordinate;
        private Direction _facing;

        public void Place(int x, int y, Direction facing)
        {
            var coordinate = new Coordinate(x, y);
            if (!coordinate.IsValid()) return;
            _coordinate = new Coordinate(x, y);
            _facing = facing;
        }

        public void Move()
        {
            if (!IsPlaced()) return;
            var lookupCoordinate = _moveLookup[_facing];
            var coordinate = new Coordinate(lookupCoordinate.X + _coordinate.X, lookupCoordinate.Y + _coordinate.Y);

            if (!coordinate.IsValid()) return;

            _coordinate = coordinate;
        }

        public void Left()
        {
            if (!IsPlaced()) return;
            _facing = _leftLookup[_facing];
        }

        public void Right()
        {
            if (!IsPlaced()) return;
            _facing = _rightLookup[_facing];
        }

        public string Report()
        {
            return IsPlaced()
                ? $"{_coordinate.X},{_coordinate.Y},{_facing}"
                : "Place robot";
        }

        private bool IsPlaced()
        {
            return _coordinate != null;
        }
    }
}