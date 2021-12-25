using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AdventOfCode.Day17TrickShot.PositionData;

namespace AdventOfCode.Day17TrickShot.Tests
{
    public class PositionTests
    {
        [Fact]
        public void DistanceFrom_CorrectnessTests()
        {
            var p1 = new Position(-35.2, 74.12);
            var p2 = new Position(14.96, -89.21);

            p1.DistanceFrom(p2).Should().BeApproximately(170.858756D, 0.00001D);
        }
    }
}
