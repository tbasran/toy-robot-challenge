using System.Text.RegularExpressions;
using ToyRobotLib;

namespace ToyRobotConsoleApp.Rules
{
    public abstract class ToyRobotInputRegexRuleBase : IToyRobotInputRule
    {
        private readonly string _regexPattern;
        protected string Input;

        protected ToyRobotInputRegexRuleBase(string regexPattern)
        {
            _regexPattern = regexPattern;
        }

        public abstract void ExecuteCommand(IToyRobot toyRobot);


        public bool IsMatch(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            if (!Regex.IsMatch(input, _regexPattern, RegexOptions.IgnoreCase)) return false;
            Input = input;
            return true;
        }
    }
}