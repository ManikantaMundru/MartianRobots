using MartianRobots.Domain;
using Shouldly;

namespace MartianRobots.Tests.Domain
{
    public class RobotTests
    {
        [Fact]
        public void TurnRight_ShouldChangeDirectionCorrectly()
        {
            // Arrange
            var robot = new Robot(new Position(1, 1), Direction.North);

            // Act
            robot.TurnRight();

            // Assert
            robot.Direction.ShouldBe(Direction.East);
        }

        [Fact]
        public void MoveForward_ShouldMoveRobotInCurrentDirection()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);
            var robot = new Robot(new Position(1, 1), Direction.North);

            // Act
            robot.MoveForward(grid);

            // Assert
            robot.Position.ShouldBe(new Position(1, 2));
            robot.IsLost.ShouldBeFalse();
        }

        [Fact]
        public void MoveForward_OutsideGrid_ShouldMarkRobotAsLost()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);
            var robot = new Robot(new Position(5, 3), Direction.East);

            // Act
            robot.MoveForward(grid);

            // Assert
            robot.IsLost.ShouldBeTrue();
            robot.Position.ShouldBe(new Position(5, 3));
        }

        [Fact]
        public void MoveForward_FromScentedPosition_ShouldIgnoreInstruction()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);
            var firstRobot = new Robot(new Position(5, 3), Direction.East);
            firstRobot.MoveForward(grid);

            var secondRobot = new Robot(new Position(5, 3), Direction.East);

            // Act
            secondRobot.MoveForward(grid);

            // Assert
            secondRobot.IsLost.ShouldBeFalse();
            secondRobot.Position.ShouldBe(new Position(5, 3));
        }
    }
}
