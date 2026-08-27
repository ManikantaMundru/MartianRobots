using MartianRobots.Domain;
using MartianRobots.Helpers;

namespace MartianRobots.Processors
{
    public sealed class MartianRobotsProcessor(RobotCommandProcessor commandProcessor)
    {
        private readonly RobotCommandProcessor _commandProcessor = commandProcessor;

        public IReadOnlyList<Robot> Execute(IEnumerable<string> input)
        {
            var lines = input.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            if (lines.Length == 0)
                return [];

            var grid = InputParser.ParseGrid(lines[0]);
            var robots = new List<Robot>();

            for (var i = 1; i < lines.Length; i += 2)
            {
                if (i + 1 >= lines.Length)
                    throw new FormatException("Missing robot instructions.");

                var robot = InputParser.ParseRobot(lines[i]);
                var instructions = lines[i + 1];

                if (!grid.IsInside(robot.Position))
                    throw new FormatException("Robot starting position is outside the grid.");

                if (instructions.Length >= 100)
                    throw new FormatException("Instruction string must be less than 100 characters.");

                _commandProcessor.Execute(robot, grid, instructions);

                robots.Add(robot);
            }

            return robots;
        }
    }
}
