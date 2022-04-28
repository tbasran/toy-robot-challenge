using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public class ToyRobotInputMoveRule : ToyRobotInputRegexRuleBase
    {
        public const string Name = "MOVE";

        public ToyRobotInputMoveRule() : base($"^{Name}$")
        {
        }

        public override void ExecuteCommand(IToyRobot toyRobot)
        {
            toyRobot.Move();
        }
    }
}