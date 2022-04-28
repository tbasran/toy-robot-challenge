using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test.RulesTests
{
    public class ToyRobotRightRuleTests
    {
        private readonly IToyRobotInputRule _inputRule;

        public ToyRobotRightRuleTests()
        {
            _inputRule = new ToyRobotInputRightRule();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("RIGHT", true)]
        [InlineData("right", true)]
        public void IsMatch_GivenInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            Assert.Equal(expected, _inputRule.IsMatch(input));
        }

        [Fact]
        public void ExecuteCommand_ShouldCallRight()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Right(), Times.Once);
        }
    }
}