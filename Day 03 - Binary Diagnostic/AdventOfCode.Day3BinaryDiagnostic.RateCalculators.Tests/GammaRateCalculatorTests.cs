using AdventOfCode.Day3BinaryDiagnostic.DataStructures;
using FluentAssertions;
using System.IO;
using Xunit;

namespace AdventOfCode.Day3BinaryDiagnostic.RateCalculators.Tests
{
    public class GammaRateCalculatorTests
    {
        [Fact]
        public void Calculate_ReturnsCorrectResult()
        {
            var report = new DiagnosticReport($"{Directory.GetCurrentDirectory()}\\TestFiles\\SampleInput.txt");
            var calculator = new RateCalculator(report);
            calculator.CalculateGammaRate().Should().Be(22);
        }
    }
}
