using System;
using System.Collections.Generic;
using Moq;
using ToyRobotConsoleApp.Rules;
using ToyRobotLib;
using Xunit;

namespace ToyRobotConsoleApp.IntegrationTest
{
    public class ProgramTests
    {
        private readonly Mock<IInput> _input;
        private readonly ToyRobotInputStrategy _inputStrategy;
        private readonly List<string> _outputList;
        private readonly Mock<IPrint> _print;

        public ProgramTests()
        {
            _input = new Mock<IInput>();
            _print = new Mock<IPrint>();
            _outputList = new List<string>();
            _print.Setup(s => s.Custom(It.IsAny<string>()))
                .Callback((string output) => _outputList.Add(output));

            var rules = new IToyRobotInputRule[]
            {
                new ToyRobotInputLeftRule(),
                new ToyRobotInputMoveRule(),
                new ToyRobotInputPlaceRule(),
                new ToyRobotInputReportRule(_print.Object),
                new ToyRobotInputRightRule()
            };
            _inputStrategy = new ToyRobotInputStrategy(rules, new ToyRobot(), _print.Object);
        }

        [Fact]
        public void RunApp_MoveNorthOnceScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 0,0,NORTH")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "0,1,NORTH" }, _outputList);
        }

        [Fact]
        public void RunApp_TurnLeftScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 0,0,NORTH")
                .Returns("LEFT")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "0,0,WEST" }, _outputList);
        }

        [Fact]
        public void RunApp_MoveEastTwiceAndOnceNorthScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 1,2,EAST")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("LEFT")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "3,3,NORTH" }, _outputList);
        }

        [Fact]
        public void RunApp_IgnoreMoveWestScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 0,0,WEST")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "0,0,WEST" }, _outputList);
        }

        [Fact]
        public void RunApp_360Scenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 0,0,EAST")
                .Returns("RIGHT")
                .Returns("RIGHT")
                .Returns("RIGHT")
                .Returns("RIGHT")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "1,0,EAST" }, _outputList);
        }

        [Fact]
        public void RunApp_WhiteSpaceInputScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns(" ")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(Array.Empty<string>(), _outputList);
            _print.Verify(v => v.Commands(), Times.Exactly(2));
        }

        [Fact]
        public void RunApp_CommandNotFoundScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("COMMAND_NOT_FOUND")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(Array.Empty<string>(), _outputList);
            _print.Verify(v => v.Commands(), Times.Exactly(2));
        }

        [Fact]
        public void RunApp_MoveAroundThePerimeterWithoutFallingOffScenario()
        {
            _input.SetupSequence(s => s.Read())
                .Returns("PLACE 0,0,EAST")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns("LEFT")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns("LEFT")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns("LEFT")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("MOVE")
                .Returns("REPORT")
                .Returns((string)null);

            Application.RunApp(_input.Object, _inputStrategy, _print.Object);

            Assert.Equal(new[] { "4,0,EAST", "4,4,NORTH", "0,4,WEST", "0,0,SOUTH" }, _outputList);
        }
    }
}