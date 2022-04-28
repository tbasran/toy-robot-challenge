using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public interface IToyRobotInputRule
    {
        void ExecuteCommand(IToyRobot toyRobot);
        bool IsMatch(string input);
    }
}