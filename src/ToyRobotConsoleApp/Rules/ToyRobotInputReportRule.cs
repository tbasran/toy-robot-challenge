using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public class ToyRobotInputReportRule : ToyRobotInputRegexRuleBase
    {
        public const string Name = "REPORT";
        private readonly IPrint _print;

        public ToyRobotInputReportRule(IPrint print) : base($"^{Name}$")
        {
            _print = print;
        }

        public override void ExecuteCommand(IToyRobot toyRobot)
        {
            _print.Custom(toyRobot.Report());
        }
    }
}