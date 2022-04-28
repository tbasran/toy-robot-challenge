using Xunit;

namespace ToyRobotLib.Test
{
    // ignore coverage
    public class ToyRobotTests
    {
        private readonly IToyRobot _toyRobot;

        public ToyRobotTests()
        {
            _toyRobot = new ToyRobot();
        }

        [Fact]
        public void Report_NotPlaced_ShouldReturnPlaceRobotMessage()
        {
            var result = _toyRobot.Report();
            Assert.Equal("Place robot", result);
        }

        [Fact]
        public void Report_Placed_ShouldReturnCoordinatesAndFacing()
        {
            _toyRobot.Place(0, 0, Direction.NORTH);
            var result = _toyRobot.Report();
            Assert.Equal("0,0,NORTH", result);
        }

        [Theory]
        [InlineData(5, 0)]
        [InlineData(0, 5)]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        public void Place_GivenInvalidCoordinate_ShouldIgnoreCommand(int x, int y)
        {
            _toyRobot.Place(x, y, Direction.NORTH);
            var result = _toyRobot.Report();
            Assert.Equal("Place robot", result);
        }

        [Theory]
        [InlineData(4, 4, Direction.NORTH, "4,4,NORTH")]
        [InlineData(0, 0, Direction.WEST, "0,0,WEST")]
        public void Place_GivenValidCoordinates_ShouldReturnExpectedReport(int x, int y, Direction facing,
            string expected)
        {
            _toyRobot.Place(x, y, facing);
            var result = _toyRobot.Report();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Left_NotPlaced_ShouldNotThrow()
        {
            _toyRobot.Left();
        }

        [Theory]
        [InlineData(Direction.EAST, Direction.NORTH)]
        [InlineData(Direction.NORTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.EAST)]
        public void Left_GivenFacingDirection_ShouldReturnExpectedDirection(Direction facing, Direction expected)
        {
            _toyRobot.Place(3, 4, facing);
            _toyRobot.Left();
            var result = _toyRobot.Report();
            Assert.Equal($"3,4,{expected}", result);
        }

        [Fact]
        public void Right_NotPlaced_ShouldNotThrow()
        {
            _toyRobot.Right();
        }

        [Theory]
        [InlineData(Direction.EAST, Direction.SOUTH)]
        [InlineData(Direction.SOUTH, Direction.WEST)]
        [InlineData(Direction.WEST, Direction.NORTH)]
        [InlineData(Direction.NORTH, Direction.EAST)]
        public void Right_GivenFacingDirection_ShouldReturnExpectedDirection(Direction facing, Direction expected)
        {
            _toyRobot.Place(3, 4, facing);
            _toyRobot.Right();
            var result = _toyRobot.Report();
            Assert.Equal($"3,4,{expected}", result);
        }

        [Fact]
        public void Move_NotPlaced_ShouldNotThrow()
        {
            _toyRobot.Move();
        }

        [Theory]
        [InlineData(Direction.EAST, 0, 0, "1,0,EAST")]
        [InlineData(Direction.EAST, 3, 0, "4,0,EAST")]
        [InlineData(Direction.EAST, 4, 0, "4,0,EAST")]
        [InlineData(Direction.SOUTH, 0, 4, "0,3,SOUTH")]
        [InlineData(Direction.SOUTH, 0, 1, "0,0,SOUTH")]
        [InlineData(Direction.SOUTH, 0, 0, "0,0,SOUTH")]
        [InlineData(Direction.WEST, 4, 0, "3,0,WEST")]
        [InlineData(Direction.WEST, 1, 0, "0,0,WEST")]
        [InlineData(Direction.WEST, 0, 0, "0,0,WEST")]
        [InlineData(Direction.NORTH, 0, 0, "0,1,NORTH")]
        [InlineData(Direction.NORTH, 0, 3, "0,4,NORTH")]
        [InlineData(Direction.NORTH, 0, 4, "0,4,NORTH")]
        public void Move_GivenFacingDirectionAndCoordinates_ShouldReturnExpectedReport(Direction facing, int x, int y,
            string expected)
        {
            _toyRobot.Place(x, y, facing);
            _toyRobot.Move();
            var result = _toyRobot.Report();
            Assert.Equal(expected, result);
        }
    }
}