using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AdventOfCode.Day17TrickShot.PositionData;
using AdventOfCode.Day17TrickShot.TargetAreaProcessing;

namespace AdventOfCode.Day17TrickShot.Tests
{
    public class TargetAreaTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(-2, 2)]
        [InlineData(3, -5)]
        public void ContainsPosition_ReturnsTrue_ForPositions_InsideArea(int x, int y)
        {
            var area = new TargetArea(-4, 4, -6, 6);
            var position = new Position(x, y);
            area.ContainsPosition(position).Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 6)]
        [InlineData(0, -6)]
        [InlineData(-4, 0)]
        [InlineData(4, 0)]
        public void ContainsPosition_ReturnsTrue_ForPositions_OnBoundary(int x, int y)
        {
            var area = new TargetArea(-4, 4, -6, 6);
            var position = new Position(x, y);
            area.ContainsPosition(position).Should().BeTrue();
        }

        [Theory]
        [InlineData(5, 6)]
        [InlineData(-5, -6)]
        [InlineData(-4, 7)]
        [InlineData(4, -7)]
        public void ContainsPosition_ReturnsFalse_ForPositions_OnBoundary(int x, int y)
        {
            var area = new TargetArea(-4, 4, -6, 6);
            var position = new Position(x, y);
            area.ContainsPosition(position).Should().BeFalse();
        }
    }
}
