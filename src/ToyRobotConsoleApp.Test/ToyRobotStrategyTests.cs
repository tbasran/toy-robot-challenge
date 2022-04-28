using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test
{
    public class ToyRobotStrategyTests
    {
        private readonly Mock<IPrint> _print;
        private readonly Mock<IToyRobotInputRule> _ruleOne;
        private readonly Mock<IToyRobotInputRule> _ruleTwo;
        private readonly Mock<IToyRobot> _toyRobot;
        private readonly IToyRobotInputStrategy _toyRobotInputStrategy;

        public ToyRobotStrategyTests()
        {
            _ruleOne = new Mock<IToyRobotInputRule>(MockBehavior.Strict);
            _ruleTwo = new Mock<IToyRobotInputRule>(MockBehavior.Strict);
            _toyRobot = new Mock<IToyRobot>(MockBehavior.Strict);
            _print = new Mock<IPrint>(MockBehavior.Strict);
            _toyRobotInputStrategy = new ToyRobotInputStrategy(new[] { _ruleOne.Object, _ruleTwo.Object },
                _toyRobot.Object,
                _print.Object);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ExecuteCommand_GivenInputIsNullOrWhiteSpace_ShouldPrintCommands(string input)
        {
            _print.Setup(s => s.Commands());
            _toyRobotInputStrategy.ExecuteCommand(input);
            _print.Verify(v => v.Commands(), Times.Once);
        }

        [Fact]
        public void ExecuteCommand_RuleOneIsAMatch_ShouldExecuteCommandOnRuleOne()
        {
            const string input = "RULE_ONE";
            _ruleOne.Setup(s => s.IsMatch(input)).Returns(true);
            _ruleOne.Setup(s => s.ExecuteCommand(_toyRobot.Object));
            _toyRobotInputStrategy.ExecuteCommand(input);

            _ruleOne.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Once);
            _ruleTwo.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Never);
        }

        [Fact]
        public void ExecuteCommand_RuleTwoIsAMatch_ShouldExecuteCommandOnRuleTwo()
        {
            const string input = "RULE_TWO";
            _ruleOne.Setup(s => s.IsMatch(It.IsAny<string>())).Returns(false);
            _ruleTwo.Setup(s => s.IsMatch(input)).Returns(true);
            _ruleTwo.Setup(s => s.ExecuteCommand(_toyRobot.Object));
            _toyRobotInputStrategy.ExecuteCommand(input);

            _ruleOne.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Never);
            _ruleTwo.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Once);
        }

        [Fact]
        public void ExecuteCommand_NoRulesMatch_ShouldPrintCommands()
        {
            const string input = "NO_MATCH";
            _print.Setup(s => s.Commands());
            _ruleOne.Setup(s => s.IsMatch(It.IsAny<string>())).Returns(false);
            _ruleTwo.Setup(s => s.IsMatch(It.IsAny<string>())).Returns(false);
            _toyRobotInputStrategy.ExecuteCommand(input);

            _ruleOne.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Never);
            _ruleTwo.Verify(v => v.ExecuteCommand(_toyRobot.Object), Times.Never);
            _print.Verify(v => v.Commands(), Times.Once);
        }
    }
}