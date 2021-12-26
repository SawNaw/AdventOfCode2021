using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xunit;
using FluentAssertions;
using Moq;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class LifeSupportRatingCalculatorTests
    {
        [Theory]
        [InlineData(2, 3, 6)]
        [InlineData(4, 5, 20)]
        [InlineData(6, 7, 42)]
        public void Calculate_ReturnsProduct_OfOxygenAndCO2Ratings(int oxygenGeneratorRating, int CO2ScrubberRating, int expectedLifeSupportRating)
        {
            var ratingCalculator = new Mock<IOxygenCO2RatingCalculator>();
            ratingCalculator.Setup(r => r.CalculateOxygenGeneratorRating()).Returns(oxygenGeneratorRating);
            ratingCalculator.Setup(r => r.CalculateCO2ScrubberRating()).Returns(CO2ScrubberRating);

            var lifeSupportRatingCalculator = new LifeSupportRatingCalculator(ratingCalculator.Object);
            lifeSupportRatingCalculator.Calculate().Should().Be(expectedLifeSupportRating);
        }

        [Fact]
        public void Calculate_ReturnsCorrectResult_ForSampleInputFile()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new LifeSupportRatingCalculator(new OxygenCO2RatingCalculator(report));
            calculator.Calculate().Should().Be(230);
        }

        [Fact]
        public void Calculate_ReturnsCorrectResult_ForMyPersonalInputFile()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\MyPersonalInputFile.txt");
            var calculator = new LifeSupportRatingCalculator(new OxygenCO2RatingCalculator(report));
            calculator.Calculate().Should().Be(4481199);
        }
    }
}
