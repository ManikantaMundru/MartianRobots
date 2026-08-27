using MartianRobots.Domain;

namespace MartianRobots.Commands
{
    public interface IRobotCommand
    {
        char Code { get; }

        void Execute(Robot robot, MarsGrid grid);
    }
}
