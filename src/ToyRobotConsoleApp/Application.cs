using ToyRobotLib;

namespace ToyRobotConsoleApp
{
    public static class Application
    {
        public static void RunApp(IInput input, IToyRobotInputStrategy inputStrategy, IPrint print)
        {
            print.Instructions();
            print.Commands();
            print.Exit();

            var line = input.Read();
            while (line != null)
            {
                inputStrategy.ExecuteCommand(line);
                line = input.Read();
            }
        }
    }
}