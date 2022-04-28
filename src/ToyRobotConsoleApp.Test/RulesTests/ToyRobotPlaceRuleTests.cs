using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test.RulesTests
{
    public class ToyRobotPlaceRuleTests
    {
        private readonly IToyRobotInputRule _inputRule;

        public ToyRobotPlaceRuleTests()
        {
            _inputRule = new ToyRobotInputPlaceRule();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("PLACE 0,0,NORTH", true)]
        [InlineData("PLACE 0,0,SOUTH", true)]
        [InlineData("PLACE 0,0,EAST", true)]
        [InlineData("PLACE 0,0,WEST", true)]
        [InlineData("place 0,0,west", true)]
        [InlineData("PLACE -1,-1,WEST", false)]
        [InlineData("PLACE 4,4,WEST", true)]
        [InlineData("PLACE 5,5,WEST", false)]
        [InlineData("PLACE4,4,WEST", false)]
        [InlineData("PLACE 44WEST", false)]
        public void IsMatch_GivenInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            Assert.Equal(expected, _inputRule.IsMatch(input));
        }

        [Fact]
        public void ExecuteCommand_InputNotValidatedBeforeExecuteCommand_ShouldNotCallPlace()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Place(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<Direction>()), Times.Never);
        }

        [Fact]
        public void ExecuteCommand_ShouldCallReport()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            const string input = "PLACE 0,4,SOUTH";
            _inputRule.IsMatch(input);
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Place(0, 4, Direction.SOUTH), Times.Once);
        }
    }
}