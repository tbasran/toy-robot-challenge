using System.Diagnostics.CodeAnalysis;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;

namespace ToyRobotConsoleApp
{
    [ExcludeFromCodeCoverage]
    public static class Program
    {
        private static void Main()
        {
            var input = new ConsoleInput();
            var print = new ConsolePrint();
            var rules = new IToyRobotInputRule[]
            {
                new ToyRobotInputLeftRule(),
                new ToyRobotInputMoveRule(),
                new ToyRobotInputPlaceRule(),
                new ToyRobotInputReportRule(print),
                new ToyRobotInputRightRule()
            };
            var toyRobot = new ToyRobot();
            var strategy = new ToyRobotInputStrategy(rules, toyRobot, print);

            Application.RunApp(input, strategy, print);
        }
    }
}