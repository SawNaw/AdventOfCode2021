using Xunit;
using AdventOfCode.Day2.Algorithms;
using FluentAssertions;

namespace AdventOfCode.Day2.Tests
{
    public class SubmarineTests
    {
        [Fact]
        public void Forward_IncreasesHorizontalPosition_BySpecifiedUnits()
        {
            var sut = new Submarine();
            sut.Forward(2);
            sut.CurrentPosition.HorizontalPosition.Should().Be(2);
            sut.CurrentPosition.Depth.Should().Be(0);
        }

        [Fact]
        public void Down_IncreasesDepth_BySpecifiedUnits()
        {
            var sut = new Submarine();
            sut.Down(2);
            sut.CurrentPosition.HorizontalPosition.Should().Be(0);
            sut.CurrentPosition.Depth.Should().Be(2);
        }

        [Fact]
        public void Up_DecreasesDepth_BySpecifiedUnits()
        {
            var sut = new Submarine();
            sut.Up(2);
            sut.CurrentPosition.HorizontalPosition.Should().Be(0);
            sut.CurrentPosition.Depth.Should().Be(-2);
        }
    }
}