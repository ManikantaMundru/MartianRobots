using MartianRobots.Commands;
using MartianRobots.Processors;
using Shouldly;

namespace MartianRobots.Tests.Processor
{
    public class MartianRobotsProcessorTests
    {
        [Fact]
        public void Execute_WithSampleInput_ShouldProduceExpectedResults()
        {
            // Arrange
            IRobotCommand[] commands = [new TurnLeftCommand(), new TurnRightCommand(), new MoveForwardCommand()];
            var commandProcessor = new RobotCommandProcessor(commands);
            var processor = new MartianRobotsProcessor(commandProcessor);

            var input = new[]
            {
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "3 2 N",
                "FRRFLLFFRRFLL",
                "0 3 W",
                "LLFFFLFLFL"
            };

            // Act
            var robots = processor.Execute(input);

            // Assert
            robots[0].ToString().ShouldBe("1 1 E");
            robots[1].ToString().ShouldBe("3 3 N LOST");
            robots[2].ToString().ShouldBe("2 3 S");
        }
    }
}
