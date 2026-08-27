using System;
using System.Collections.Generic;
using System.Text;

namespace MartianRobots.Domain
{
    public sealed class Robot
    {
        public Position Position { get; private set; }

        public Direction Direction { get; private set; }

        public bool IsLost { get; private set; }

        public Robot(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }

        public void TurnRight()
        {
            if (IsLost)
                return;

            Direction = (Direction)(((int)Direction + 1) % 4);
        }

        public void TurnLeft()
        {
            if (IsLost)
                return;

            Direction = (Direction)(((int)Direction + 3) % 4);
        }

        public void MoveForward(MarsGrid grid)
        {
            if (IsLost)
                return;

            var nextPosition = GetNextPosition();

            // Move normally when the next position is still inside the grid.
            if (grid.IsInside(nextPosition))
            {
                Position = nextPosition;

                return;
            }

            // If another robot was already lost here, ignore this move.
            if (grid.HasScent(Position))
            {
                return;
            }

            // The robot is leaving the grid for the first time from this position.
            // Leave a scent so future robots can avoid being lost here.
            grid.AddScent(Position);

            IsLost = true;
        }

        private Position GetNextPosition()
        {
            return Direction switch
            {
                Direction.North => Position with { Y = Position.Y + 1 },
                Direction.East => Position with { X = Position.X + 1 },
                Direction.South => Position with { Y = Position.Y - 1 },
                Direction.West => Position with { X = Position.X - 1 },
                _ => throw new InvalidOperationException($"Unsupported direction {Direction}")
            };
        }

        public override string ToString()
        {
            var result = $"{Position.X} {Position.Y} {Direction.ToCode()}";

            return IsLost ? $"{result} LOST" : result;
        }
    }
}
