using MartianRobots.Domain;

namespace MartianRobots.Commands
{
    public sealed class TurnLeftCommand : IRobotCommand
    {
        public char Code => 'L';

        public void Execute(Robot robot, MarsGrid grid)
        {
            robot.TurnLeft();
        }
    }
}
