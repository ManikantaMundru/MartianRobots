using MartianRobots.Domain;

namespace MartianRobots.Commands
{
    public sealed class MoveForwardCommand : IRobotCommand
    {
        public char Code => 'F';

        public void Execute(Robot robot, MarsGrid grid)
        {
            robot.MoveForward(grid);
        }
    }
}
