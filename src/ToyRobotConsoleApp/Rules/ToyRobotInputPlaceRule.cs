using System;
using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public class ToyRobotInputPlaceRule : ToyRobotInputRegexRuleBase
    {
        public const string Name = "PLACE";

        public ToyRobotInputPlaceRule() : base(
            $"^{Name} [{Coordinate.MinValue}-{Coordinate.MaxValue}],[{Coordinate.MinValue}-{Coordinate.MaxValue}],({Direction.EAST}|{Direction.WEST}|{Direction.NORTH}|{Direction.SOUTH})$")
        {
        }

        public override void ExecuteCommand(IToyRobot toyRobot)
        {
            if (string.IsNullOrWhiteSpace(Input)) return;
            var spaceSplit = Input.Split(' ');
            var commaSplit = spaceSplit[1].Split(',');
            var x = int.Parse(commaSplit[0]);
            var y = int.Parse(commaSplit[1]);
            var facing = Enum.Parse<Direction>(commaSplit[2], true);
            toyRobot.Place(x, y, facing);
        }
    }
}