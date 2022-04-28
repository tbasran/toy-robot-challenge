using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public class ToyRobotInputRightRule : ToyRobotInputRegexRuleBase
    {
        public const string Name = "RIGHT";

        public ToyRobotInputRightRule() : base($"^{Name}$")
        {
        }

        public override void ExecuteCommand(IToyRobot toyRobot)
        {
            toyRobot.Right();
        }
    }
}