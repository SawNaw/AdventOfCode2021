using Xunit;
using FluentAssertions;
using System;
using AdventOfCode.Day17TrickShot.TargetAreaProcessing;

namespace AdventOfCode.Day17TrickShot.Tests
{
    public class TargetAreaInputParserTests
    {
        [Fact]
        public void Parse_ReturnsMaxAndMinXYValues()
        {
            string targetAreaInputText = "     target area: x=20..30, y=-10..-5        ";
            var parseResult = TargetAreaInputParser.Parse(targetAreaInputText);

            parseResult.XMin.Should().Be(20);
            parseResult.XMax.Should().Be(30);
            parseResult.YMin.Should().Be(-10);
            parseResult.YMax.Should().Be(-5);
        }

        [Fact]
        public void Parse_ShouldFail_OnEmptyInput()
        {
            string targetAreaInputText = "      ";
            Action act = () => TargetAreaInputParser.Parse(targetAreaInputText);
            act.Should().Throw<InvalidOperationException>().WithMessage("Input is empty.");
        }
    }
}