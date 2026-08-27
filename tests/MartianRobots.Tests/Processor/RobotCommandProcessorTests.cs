using MartianRobots.Commands;
using MartianRobots.Domain;
using MartianRobots.Processors;
using Shouldly;

namespace MartianRobots.Tests.Processor
{
    public class RobotCommandProcessorTests
    {
        [Fact]
        public void Execute_ShouldProcessRobotInstructions()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);
            var robot = new Robot(new Position(1, 1), Direction.East);
            var processor = CreateProcessor();

            // Act
            processor.Execute(robot, grid, "RFRF");

            // Assert
            robot.Position.ShouldBe(new Position(0, 0));
            robot.Direction.ShouldBe(Direction.West);
            robot.IsLost.ShouldBeFalse();
        }

        [Fact]
        public void Execute_WithUnsupportedInstruction_ShouldThrow()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);
            var robot = new Robot(new Position(1, 1), Direction.North);
            var processor = CreateProcessor();

            // Act
            var action = () => processor.Execute(robot, grid, "X");

            // Assert
            action.ShouldThrow<ArgumentException>();
        }

        private static RobotCommandProcessor CreateProcessor()
        {
            IRobotCommand[] commands = [new TurnLeftCommand(), new TurnRightCommand(), new MoveForwardCommand()];
            return new RobotCommandProcessor(commands);
        }
    }
}