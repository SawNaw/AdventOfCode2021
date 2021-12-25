using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using FluentAssertions;
using System;
using Xunit;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class BinaryNumberTests
    {
        [Fact]
        public void GettingABit_ByIndex_Works()
        {
            string rowContent = "10110";
            var sut = new BinaryNumber(rowContent);

            sut.DigitAt(0).Should().Be(true);
            sut.DigitAt(1).Should().Be(false);
            sut.DigitAt(2).Should().Be(true);
            sut.DigitAt(3).Should().Be(true);
            sut.DigitAt(4).Should().Be(false);
        }

        [Fact]
        public void KnowsItOwnLength()
        {
            string rowContent = "10110";
            var sut = new BinaryNumber(rowContent);

            sut.Length.Should().Be(5);
        }

        [Fact]
        public void InvalidBinaryNumber_Throws()
        {
            string number = "10112";
            Action act = () => new BinaryNumber(number);

            act.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void EmptyInitialization_Throws()
        {
            string number = "    ";
            Action act = () => new BinaryNumber(number);

            act.Should().Throw<ArgumentNullException>();
        }
    }
}