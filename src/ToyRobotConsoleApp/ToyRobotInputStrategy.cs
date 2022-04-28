using System.Collections.Generic;
using System.Linq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;

namespace ToyRobotConsoleApp
{
    public class ToyRobotInputStrategy : IToyRobotInputStrategy
    {
        private readonly IPrint _print;

        private readonly IList<IToyRobotInputRule> _rules;
        private readonly IToyRobot _toyRobot;

        public ToyRobotInputStrategy(IList<IToyRobotInputRule> rules, IToyRobot toyRobot, IPrint print)
        {
            _rules = rules;
            _toyRobot = toyRobot;
            _print = print;
        }

        public void ExecuteCommand(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _print.Commands();
                return;
            }

            var rule = _rules.FirstOrDefault(s => s.IsMatch(input.Trim()));
            if (rule != null)
            {
                rule.ExecuteCommand(_toyRobot);
                return;
            }

            _print.Commands();
        }
    }
}