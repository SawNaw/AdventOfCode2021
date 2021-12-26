using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using FluentAssertions;
using System.IO;
using Xunit;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class OxygenCO2RatingCalculatorTests
    {
        [Fact]
        public void CalculateOxygenGeneratorRating_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new OxygenCO2RatingCalculator(report);
            calculator.CalculateOxygenGeneratorRating().Should().Be(23);
        }

        [Fact]
        public void CalculateCO2ScrubberRating_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new OxygenCO2RatingCalculator(report);
            calculator.CalculateCO2ScrubberRating().Should().Be(10);
        }
    }
}
