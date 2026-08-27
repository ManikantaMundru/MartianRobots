using MartianRobots.Commands;
using MartianRobots.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Processors
{
    public sealed class RobotCommandProcessor(IEnumerable<IRobotCommand> commands)
    {
        private readonly IReadOnlyDictionary<char, IRobotCommand> _commands = commands.ToDictionary(x => x.Code);

        public void Execute(Robot robot, MarsGrid grid, string instructions)
        {
            foreach (var instruction in instructions)
            {
                if (robot.IsLost)
                    break;

                if (!_commands.TryGetValue(instruction, out var command))
                    throw new ArgumentException($"Unsupported instruction '{instruction}'.");

                command.Execute(robot, grid);
            }
        }
    }
}
