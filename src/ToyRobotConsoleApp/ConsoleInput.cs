using System;
using System.Diagnostics.CodeAnalysis;
using ToyRobotLib;

namespace ToyRobotConsoleApp
{
    [ExcludeFromCodeCoverage]
    public class ConsoleInput : IInput
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}