using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test.RulesTests
{
    public class ToyRobotLeftRuleTests
    {
        private readonly IToyRobotInputRule _inputRule;

        public ToyRobotLeftRuleTests()
        {
            _inputRule = new ToyRobotInputLeftRule();
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("LEFT", true)]
        [InlineData("left", true)]
        public void IsMatch_GivenInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            Assert.Equal(expected, _inputRule.IsMatch(input));
        }

        [Fact]
        public void ExecuteCommand_ShouldCallLeft()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Left(), Times.Once);
        }
    }
}