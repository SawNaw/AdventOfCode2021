using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using System.IO;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class OxygenGeneratorRatingTests
    {
        [Fact]
        public void Calculate_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new RatingCalculator(report);
            calculator.CalculateOxygenGeneratorRating().Should().Be(23);
        }
    }
}
