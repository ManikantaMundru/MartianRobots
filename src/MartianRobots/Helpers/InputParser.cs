using MartianRobots.Domain;

namespace MartianRobots.Helpers
{
    public static class InputParser
    {
        public static MarsGrid ParseGrid(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2)
                throw new FormatException($"Invalid grid input: '{input}'.");

            var maxX = int.Parse(parts[0]);
            var maxY = int.Parse(parts[1]);

            return new MarsGrid(maxX, maxY);
        }

        public static Robot ParseRobot(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 3)
                throw new FormatException($"Invalid robot input: '{input}'.");

            var x = int.Parse(parts[0]);
            var y = int.Parse(parts[1]);
            var direction = DirectionExtensions.Parse(parts[2]);

            return new Robot(new Position(x, y), direction);
        }
    }
}
