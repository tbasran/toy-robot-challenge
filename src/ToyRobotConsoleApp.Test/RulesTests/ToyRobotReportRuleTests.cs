using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test.RulesTests
{
    public class ToyRobotReportRuleTests
    {
        private readonly IToyRobotInputRule _inputRule;
        private readonly Mock<IPrint> _print;

        public ToyRobotReportRuleTests()
        {
            _print = new Mock<IPrint>();
            _inputRule = new ToyRobotInputReportRule(_print.Object);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("REPORT", true)]
        [InlineData("report", true)]
        public void IsMatch_GivenInput_ShouldReturnExpectedResult(string input, bool expected)
        {
            Assert.Equal(expected, _inputRule.IsMatch(input));
        }

        [Fact]
        public void ExecuteCommand_ShouldCallReport()
        {
            var toyRobotMock = new Mock<IToyRobot>();
            const string reportOutput = "REPORT";
            toyRobotMock.Setup(s => s.Report()).Returns(reportOutput);
            _inputRule.ExecuteCommand(toyRobotMock.Object);
            toyRobotMock.Verify(v => v.Report(), Times.Once);
            _print.Verify(v => v.Custom(reportOutput), Times.Once);
        }
    }
}