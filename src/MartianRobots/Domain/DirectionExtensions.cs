namespace MartianRobots.Domain
{
    public static class DirectionExtensions
    {
        public static Direction Parse(string value)
        {
            return value switch
            {
                "N" => Direction.North,
                "E" => Direction.East,
                "S" => Direction.South,
                "W" => Direction.West,
                _ => throw new FormatException($"Invalid direction '{value}'.")
            };
        }

        public static string ToCode(this Direction direction)
        {
            return direction switch
            {
                Direction.North => "N",
                Direction.East => "E",
                Direction.South => "S",
                Direction.West => "W",
                _ => throw new InvalidOperationException($"Unsupported direction '{direction}'.")
            };
        }
    }
}
