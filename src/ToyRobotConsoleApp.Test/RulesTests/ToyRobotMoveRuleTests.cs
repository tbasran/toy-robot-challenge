using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test.RulesTests
{
    public class ToyRobotMoveRuleTests
    {
        private readonly IToyRobotInputRule _inputRule;

        public ToyRobotMoveRuleTests()
        {
            _inputRule = new ToyRobotInputMoveRule();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("MOVE", true)]
        [InlineData("move", true)]
        public void IsMatch_GivenInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            Assert.Equal(expected, _inputRule.IsMatch(input));
        }

        [Fact]
        public void ExecuteCommand_ShouldCallMove()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Move(), Times.Once);
        }
    }
}