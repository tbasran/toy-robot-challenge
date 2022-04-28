using Moq;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.Test
{
    public class ApplicationTests
    {
        [Fact]
        public void RunApp_InputReadReturnsNull_ShouldNotExecuteCommand()
        {
            var input = new Mock<IInput>();
            input.Setup(s => s.Read()).Returns((string)null);
            var strategy = new Mock<IToyRobotInputStrategy>();
            var print = new Mock<IPrint>();

            Application.RunApp(input.Object, strategy.Object, print.Object);

            strategy.Verify(v => v.ExecuteCommand(It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void RunApp_InputReadReturnsOnce_ShouldExecuteCommandOnce()
        {
            var input = new Mock<IInput>();
            input.SetupSequence(s => s.Read())
                .Returns("FIRST_INPUT")
                .Returns((string)null);
            var strategy = new Mock<IToyRobotInputStrategy>();
            var print = new Mock<IPrint>();

            Application.RunApp(input.Object, strategy.Object, print.Object);

            strategy.Verify(v => v.ExecuteCommand(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void RunApp_InputReadReturnsTwice_ShouldExecuteCommandTwice()
        {
            var input = new Mock<IInput>();
            input.SetupSequence(s => s.Read())
                .Returns("FIRST_INPUT")
                .Returns("SECOND_INPUT")
                .Returns((string)null);
            var strategy = new Mock<IToyRobotInputStrategy>();
            var print = new Mock<IPrint>();

            Application.RunApp(input.Object, strategy.Object, print.Object);

            strategy.Verify(v => v.ExecuteCommand(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}