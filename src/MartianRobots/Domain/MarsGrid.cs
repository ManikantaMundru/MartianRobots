namespace MartianRobots.Domain
{
    public sealed class MarsGrid
    {
        private readonly HashSet<Position> _scents = [];

        public int MaxX { get; }
        public int MaxY { get; }

        public MarsGrid(int maxX, int maxY)
        {
            if (maxX is < 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(maxX));

            if (maxY is < 0 or > 50)
                throw new ArgumentOutOfRangeException(nameof(maxY));

            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsInside(Position position)
        {
            return position.X >= 0 &&
                   position.Y >= 0 &&
                   position.X <= MaxX &&
                   position.Y <= MaxY;
        }

        public bool HasScent(Position position)
        {
            return _scents.Contains(position);
        }

        public void AddScent(Position position)
        {
            _scents.Add(position);
        }
    }
}
