using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AdventOfCode.Day17TrickShot.ProbeLaunchSimulation;
using AdventOfCode.Day17TrickShot.TargetAreaProcessing;
using AdventOfCode.Day17TrickShot.Physics;

namespace AdventOfCode.Day17TrickShot.Tests.IntegrationTests
{
    /// <summary>
    /// Tests the four example scenarios given on the Advent of Code website:
    /// https://adventofcode.com/2021/day/17
    /// </summary>
    public class IntegrationTests
    {
        private const int maxSteps = 10; // the given examples don't require more than ten steps
        private TargetArea targetArea = new TargetArea(20, 30, -10, -5);

        [Theory]
        [InlineData(7, 2, 7)]  // using velocity [7, 2], probe should reach target area on step 7
        [InlineData(6, 3, 9)]  // using velocity [6, 3], probe should reach target area on step 9
        [InlineData(9, 0, 4)]  // using velocity [9, 0], probe should reach target area on step 4
        public void FirstThreeExamples_FromTheWebsite_Work(int xInitialVelocity, int yInitialVelocity, int indexOfTrueElement)
        {
            var initialVelocity = new Velocity(xInitialVelocity, yInitialVelocity);
            var launcher = new ProbeLaunchSimulator(initialVelocity, targetArea);

            for (int i = 1; i <= maxSteps; i++)
            {
                launcher.Step();
            }

            launcher.PositionHistory.PastPositions.ElementAt(indexOfTrueElement)
                                                  .IsInsideTargetArea
                                                  .Should()
                                                  .BeTrue();
        }

        [Fact]
        public void LastExample_FromTheWebsite_Works()
        {
            var initialVelocity = new Velocity(17, -4);
            var launcher = new ProbeLaunchSimulator(initialVelocity, targetArea);

            for (int i = 1; i <= maxSteps; i++)
            {
                launcher.Step();
            }

            launcher.PositionHistory.PastPositions
                                    .Should()
                                    .NotContain(pos => pos.IsInsideTargetArea == true);
        }

        [Fact]
        public void FinalAnswer_IsCorrect()
        {
            const int xMaxVelocity = 176;
            const int yMaxVelocity = 200;

            var targetArea = new TargetArea(119, 176, -141, -84);

            double greatestHeight = 0;
            var velocity = new Velocity(0, 0);

            for (int xVel = 0; xVel < xMaxVelocity; xVel++)
            {
                for (int yVel = 0; yVel < yMaxVelocity; yVel++)
                {
                    var launcher = new ProbeLaunchSimulator(new Velocity(xVel, yVel), targetArea);

                    launcher.StepMultiple(300); // if it doesn't hit after this many steps, assume miss
                    if (launcher.TargetAreaReached && launcher.HighestAltitudeReached > greatestHeight)
                    {
                        greatestHeight = launcher.HighestAltitudeReached;
                    }
                }
            }

            greatestHeight.Should().Be(9870);
        }

        [Fact]
        public void FinalAnswer_CheckTwo()
        {
            const int xMaxVelocity = 176;
            const int yMaxVelocity = 200;

            var targetArea = new TargetArea(20, 30, -10, -5);

            double greatestHeight = 0;
            double stepCounter = 0;
            var velocity = new Velocity(0, 0);

            for (int xVel = 0; xVel < xMaxVelocity; xVel++)
            {
                for (int yVel = 0; yVel < yMaxVelocity; yVel++)
                {
                    var launcher = new ProbeLaunchSimulator(new Velocity(xVel, yVel), targetArea);

                    launcher.StepUntilConfirmedHitOrMiss(); // if it doesn't hit after this many steps, assume miss
                    if (launcher.TargetAreaReached && launcher.HighestAltitudeReached > greatestHeight)
                    {
                        greatestHeight = launcher.HighestAltitudeReached;
                    }
                    if (launcher.StepCounter > stepCounter) stepCounter = launcher.StepCounter;
                }
            }

            greatestHeight.Should().Be(9870);
        }
    }
}
