using Xunit;

namespace ToyRobotLib.Test
{
    public class CoordinateTests
    {
        [Fact]
        public void Constructor_sets_X_property()
        {
            var result = new Coordinate(3, 4);
            Assert.Equal(3, result.X);
        }

        [Fact]
        public void Constructor_sets_Y_property()
        {
            var result = new Coordinate(3, 4);
            Assert.Equal(4, result.Y);
        }

        [Theory]
        [InlineData(-1, 0, false)]
        [InlineData(0, -1, false)]
        [InlineData(0, 0, true)]
        [InlineData(4, 4, true)]
        [InlineData(5, 4, false)]
        [InlineData(4, 5, false)]
        public void IsValid_given_coordinates_should_return_expected(int x, int y, bool expected)
        {
            var coordinate = new Coordinate(x, y);
            Assert.Equal(expected, coordinate.IsValid());
        }
    }
}