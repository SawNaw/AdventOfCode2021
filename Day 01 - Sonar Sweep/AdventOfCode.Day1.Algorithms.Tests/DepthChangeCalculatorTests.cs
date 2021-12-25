using System.Collections.Generic;
using System.Linq;
using Xunit;
using FluentAssertions;

namespace AdventOfCode.Day1.Algorithms.Tests
{
    public class DepthChangeCalculatorTests
    {
        [Fact]
        public void NoMeasurement_Reports_NoPreviousMeasurement()
        {
            var m = new List<Measurement>();
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().BeEmpty();
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(99)]
        [InlineData(-1)]
        [InlineData(-100)]
        public void SingleMeasurement_Reports_NoPreviousMeasurement(int number)
        {
            var m = new List<Measurement>() { new Measurement(number) };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().BeEmpty();
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 999)]
        [InlineData(-4, -3)]
        [InlineData(-4, 0)]
        [InlineData(-4, 3)]
        public void OneIncrease_Is_ReportedCorrectly(int first, int second)
        {
            var m = new List<Measurement>() { new Measurement(first), new Measurement(second) };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(1);
            result.ChangeSequence.First().Should().Be(DepthChangeType.Increase);
        }

        [Theory]
        [InlineData(3, 1)]
        [InlineData(999, 2)]
        [InlineData(-3, -4)]
        [InlineData(0, -4)]
        [InlineData(3, -4)]
        public void OneDecrease_Is_ReportedCorrectly(int first, int second)
        {
            var m = new List<Measurement>() { new Measurement(first), new Measurement(second) };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(1);
            result.ChangeSequence.First().Should().Be(DepthChangeType.Decrease);
        }

        [Theory]
        [InlineData(3, 1, 0)]
        [InlineData(999, 2, 0)]
        [InlineData(-3, -4, -7)]
        [InlineData(0, -4, -9)]
        [InlineData(3, 0, -4)]
        public void TwoDecreases_Are_ReportedCorrectly(int first, int second, int third)
        {
            var m = new List<Measurement>() 
            { 
                new Measurement(first), 
                new Measurement(second), 
                new Measurement(third) 
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(2);
            result.ChangeSequence.Should().Equal(DepthChangeType.Decrease, DepthChangeType.Decrease);
        }

        [Theory]
        [InlineData(0, 1, 3)]
        [InlineData(1, 4, 999)]
        [InlineData(-99, -40, -33)]
        [InlineData(-44, 0, 21)]
        public void TwoIncreases_Are_ReportedCorrectly(int first, int second, int third)
        {
            var m = new List<Measurement>()
            {
                new Measurement(first),
                new Measurement(second),
                new Measurement(third)
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(2);
            result.ChangeSequence.Should().Equal(DepthChangeType.Increase, DepthChangeType.Increase);
        }

        [Theory]
        [InlineData(0, 1, -3)]
        [InlineData(1, 4, -999)]
        [InlineData(-99, -40, -111)]
        [InlineData(-44, 0, -21)]
        public void Increase_Then_Decrease_Is_ReportedCorrectly(int first, int second, int third)
        {
            var m = new List<Measurement>()
            {
                new Measurement(first),
                new Measurement(second),
                new Measurement(third)
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(2);
            result.ChangeSequence.Should().Equal(DepthChangeType.Increase, DepthChangeType.Decrease);
        }

        [Theory]
        [InlineData(0, 0, 0)]
        [InlineData(4, 4, 4)]
        [InlineData(-9, -9, -9)]
        public void NoChange_Is_ReportedCorrectly(int first, int second, int third)
        {
            var m = new List<Measurement>()
            {
                new Measurement(first),
                new Measurement(second),
                new Measurement(third)
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(2);
            result.ChangeSequence.Should().Equal(DepthChangeType.NoChange, DepthChangeType.NoChange);
        }

        [Fact]
        public void Specific_Sequence_Test_1()
        {
            var m = new List<Measurement>()
            {
                new Measurement(1),
                new Measurement(3),
                new Measurement(2),
                new Measurement(-7),
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(3);
            result.ChangeSequence.Should().Equal(DepthChangeType.Increase, DepthChangeType.Decrease, DepthChangeType.Decrease);
        }

        [Fact]
        public void Specific_Sequence_Test_2()
        {
            var m = new List<Measurement>()
            {
                new Measurement(1),
                new Measurement(-7),
                new Measurement(22),
                new Measurement(44),
                new Measurement(55),
                new Measurement(4),
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(5);
            result.ChangeSequence.Should().Equal(DepthChangeType.Decrease, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Decrease);
        }

        [Fact]
        public void Specific_Sequence_Test_3()
        {
            var m = new List<Measurement>()
            {
                new Measurement(1),
                new Measurement(-7),
                new Measurement(22),
                new Measurement(44),
                new Measurement(55),
                new Measurement(4),
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(5);
            result.ChangeSequence.Should().Equal(DepthChangeType.Decrease, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Increase, 
                                                 DepthChangeType.Decrease);
        }

        [Fact]
        public void Specific_Sequence_Test_4()
        {
            var m = new List<Measurement>()
            {
                new Measurement(1),
                new Measurement(-7),
                new Measurement(22),
                new Measurement(22),
                new Measurement(55),
                new Measurement(4),
                new Measurement(4),
                new Measurement(5),
            };
            var result = DepthChangeCalculator.GetDepthChanges(m);

            result.ChangeSequence.Should().HaveCount(7);
            result.ChangeSequence.Should().Equal(DepthChangeType.Decrease, 
                DepthChangeType.Increase, 
                DepthChangeType.NoChange, 
                DepthChangeType.Increase, 
                DepthChangeType.Decrease,
                DepthChangeType.NoChange,
                DepthChangeType.Increase);
        }
    }
}