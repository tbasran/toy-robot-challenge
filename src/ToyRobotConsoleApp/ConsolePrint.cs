using System;
using System.Diagnostics.CodeAnalysis;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;

namespace ToyRobotConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsolePrint : IPrint
    {
        public void Instructions()
        {
            Console.WriteLine(
                "This application is a simulation of a toy robot moving on a square table top, of dimensions 5 units x 5 units.");
            Console.WriteLine("There are no other obstructions on the table surface.");
            Console.WriteLine("The robot is free to roam around the surface of the table.");
            Console.WriteLine("The robot must be placed before it can roam.");
        }

        public void Commands()
        {
            Console.WriteLine("Enter one of the following commands:");
            Console.WriteLine(
                $" - {ToyRobotInputPlaceRule.Name} X,Y,F. X and Y must be a value between {Coordinate.MinValue} and {Coordinate.MaxValue}. F must be; {string.Join(',', Enum.GetNames(typeof(Direction)))}. For example, {ToyRobotInputPlaceRule.Name} 0,0,{Direction.NORTH}");
            Console.WriteLine($" - {ToyRobotInputMoveRule.Name}");
            Console.WriteLine($" - {ToyRobotInputLeftRule.Name}");
            Console.WriteLine($" - {ToyRobotInputRightRule.Name}");
            Console.WriteLine($" - {ToyRobotInputReportRule.Name}");
        }

        public void Custom(string text)
        {
            Console.WriteLine(text);
        }

        public void Exit()
        {
            Console.WriteLine("Press CTRL+C to exit the application");
        }
    }
}