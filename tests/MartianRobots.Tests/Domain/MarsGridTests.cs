using MartianRobots.Domain;
using Shouldly;

namespace MartianRobots.Tests.Domain
{
    public class MarsGridTests
    {
        [Fact]
        public void IsInside_ShouldRespectGridBoundaries()
        {
            // Arrange
            var grid = new MarsGrid(5, 3);

            // Act
            var bottomLeft = grid.IsInside(new Position(0, 0));
            var topRight = grid.IsInside(new Position(5, 3));
            var outsideRight = grid.IsInside(new Position(6, 3));
            var outsideLeft = grid.IsInside(new Position(-1, 0));

            // Assert
            bottomLeft.ShouldBeTrue();
            topRight.ShouldBeTrue();
            outsideRight.ShouldBeFalse();
            outsideLeft.ShouldBeFalse();
        }
    }
}
