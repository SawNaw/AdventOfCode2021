using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using Moq;
using AdventOfCode.Day17TrickShot.ProbeLaunchSimulation;
using AdventOfCode.Day17TrickShot.Physics;
using AdventOfCode.Day17TrickShot.PositionData;
using AdventOfCode.Day17TrickShot.TargetAreaProcessing;

namespace AdventOfCode.Day17TrickShot.Tests
{
    public class ProbeLaunchSimulatorTests
    {
        [Fact]
        public void Step_ChangesPosition_BasedOnVelocity()
        {
            var launcher = new ProbeLaunchSimulator(new Velocity(2, 3), new Mock<ITargetArea>().Object);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(2);
            launcher.CurrentPosition.Y.Should().Be(3);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(5);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(6);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(6);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(5);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(3);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(0);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(-4);

            launcher.Step();
            launcher.CurrentPosition.X.Should().Be(3);
            launcher.CurrentPosition.Y.Should().Be(-9);
        }

        [Theory]
        [InlineData(2, 3, 1, 2)]
        [InlineData(-2, 1, -1, 0)]
        [InlineData(0, 2, 0, 1)]
        public void Step_AppliesDrag(int xInitial, int yInitial, int xNew, int yNew)
        {
            var launcher = new ProbeLaunchSimulator(new Velocity(xInitial, yInitial), new Mock<ITargetArea>().Object);
            launcher.Step();
            launcher.CurrentVelocity.X.Should().Be(xNew);
            launcher.CurrentVelocity.Y.Should().Be(yNew);
        }

        [Fact]
        public void Step_AppliesDrag_ForMultipleSteps()
        {
            const int xInitial = 2;
            const int yInitial = 3;

            var launcher = new ProbeLaunchSimulator(new Velocity(xInitial, yInitial), new Mock<ITargetArea>().Object);

            launcher.Step();

            launcher.CurrentVelocity.X.Should().Be(1);
            launcher.CurrentVelocity.Y.Should().Be(2);

            launcher.Step();

            launcher.CurrentVelocity.X.Should().Be(0);
            launcher.CurrentVelocity.Y.Should().Be(1);

            launcher.Step();

            launcher.CurrentVelocity.X.Should().Be(0);
            launcher.CurrentVelocity.Y.Should().Be(0);
        }

        [Fact]
        public void Step_Updates_PositionHistory_WithUpperAndLowerBounds()
        {

            var launcher = new ProbeLaunchSimulator(new Velocity(2, 3), new Mock<ITargetArea>().Object);

            launcher.PositionHistory.LowestX.Should().Be(0);
            launcher.PositionHistory.LowestY.Should().Be(0);
            launcher.PositionHistory.HighestX.Should().Be(0);
            launcher.PositionHistory.HighestY.Should().Be(0);

            launcher.Step();

            launcher.PositionHistory.LowestX.Should().Be(0);
            launcher.PositionHistory.LowestY.Should().Be(0);
            launcher.PositionHistory.HighestX.Should().Be(2);
            launcher.PositionHistory.HighestY.Should().Be(3);

            launcher.Step();

            launcher.PositionHistory.LowestX.Should().Be(0);
            launcher.PositionHistory.LowestY.Should().Be(0);
            launcher.PositionHistory.HighestX.Should().Be(3);
            launcher.PositionHistory.HighestY.Should().Be(5);
        }

        [Fact]
        public void Step_Records_PositionHistory()
        {
            const int xInitial = 2;
            const int yInitial = 3;

            var launcher = new ProbeLaunchSimulator(new Velocity(xInitial, yInitial), new Mock<ITargetArea>().Object);
            
            var initialHistory = launcher.PositionHistory.PastPositions;

            initialHistory.Should().ContainSingle(pos => pos.Position.X == 0 && pos.Position.Y == 0); 

            launcher.Step();

            var historyAfterOneStep = launcher.PositionHistory.PastPositions.ToList();
            historyAfterOneStep.Should().HaveCount(2);
            historyAfterOneStep[0].Should().Equals(new Position(0, 0));
            historyAfterOneStep[1].Should().Equals(new Position(2, 3));

            launcher.Step();

            var historyAfterTwoSteps = launcher.PositionHistory.PastPositions.ToList();

            historyAfterTwoSteps.Should().HaveCount(3);
            historyAfterTwoSteps[0].Should().Equals(new Position(0, 0));
            historyAfterTwoSteps[1].Should().Equals(new Position(2, 3));
            historyAfterTwoSteps[2].Should().Equals(new Position(3, 5));

            launcher.Step();

            var historyAfterThreeSteps = launcher.PositionHistory.PastPositions.ToList();

            historyAfterThreeSteps.Should().HaveCount(4);
            historyAfterThreeSteps[0].Should().Equals(new Position(0, 0));
            historyAfterThreeSteps[1].Should().Equals(new Position(2, 3));
            historyAfterThreeSteps[2].Should().Equals(new Position(3, 5));
            historyAfterThreeSteps[3].Should().Equals(new Position(3, 6));
        }

        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(99, 0, 0)]
        [InlineData(99, -3, 0)]
        public void StepMultiple_RecordsHighestAltitudeReached(int xVelocity, int yVelocity, int expectedHighestAltitude)
        {
            var launcher = new ProbeLaunchSimulator(new Velocity(xVelocity, yVelocity), new Mock<ITargetArea>().Object);
            launcher.StepMultiple(7);

            launcher.HighestAltitudeReached.Should().Be(expectedHighestAltitude);
        }
    }
}
