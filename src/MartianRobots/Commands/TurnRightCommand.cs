using MartianRobots.Domain;

namespace MartianRobots.Commands
{
    public sealed class TurnRightCommand : IRobotCommand
    {
        public char Code => 'R';

        public void Execute(Robot robot, MarsGrid grid)
        {
            robot.TurnRight();
        }
    }
}
