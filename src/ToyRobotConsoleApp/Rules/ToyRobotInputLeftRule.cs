using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public class ToyRobotInputLeftRule : ToyRobotInputRegexRuleBase
    {
        public const string Name = "LEFT";

        public ToyRobotInputLeftRule() : base($"^{Name}$")
        {
        }

        public override void ExecuteCommand(IToyRobot toyRobot)
        {
            toyRobot.Left();
        }
    }
}